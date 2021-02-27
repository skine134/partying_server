using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using log4net;
using partting_server.controller;
using partting_server.util;

// State object for reading client data asynchronously
public class StateObject
{
    // Size of receive buffer.  
    public const int BufferSize = 1024*1024;

    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];

    // Received data string.
    public StringBuilder sb = new StringBuilder();

    // Client socket.
    public Socket workSocket = null;
}

namespace partting_server.lib
{

    public class Connection
    {

        // Thread signal.  
        public static AutoResetEvent allDone =
            new AutoResetEvent(false);
        public static AutoResetEvent sendDone =
            new AutoResetEvent(false);
        public static AutoResetEvent receiveDone =
            new AutoResetEvent(false);
        private static Socket handler;
        private static ILog log = Logger.GetLogger();

        // -------- Receive Method ---------
        public static void waittingRequest()
        {
            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  
            // IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
            IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1045);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Send(Common.getErrorFormat("50000"));
            }

            Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            try
            {

                // Signal the main thread to continue.  
                allDone.Set();
                Socket listener = (Socket)ar.AsyncState;
                handler = listener.EndAccept(ar);
                Common.FindHandler(handler);
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }

            catch (SocketException se)
            {
                log.Error(se.Message);
                new ConnectedExit(null, handler);
                return;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Send(Common.getErrorFormat("50000"));
            }
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            try
            {
                // Retrieve the state object and the handler socket  
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                int bytesRead = 0;
                // Read data from the client socket.
                bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.UTF8.GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read
                    // more data.  
                    content = state.sb.ToString();
                    if (content.IndexOf("<EOF>") > -1)
                    {
                        // All the data has been read from the
                        // client. Display it on the console.  
                        string[] receiveDatas = content.Split("<EOF>");
                        // client에게 packet을 send하기 위한 Send()함수가 매개변수로 handler를 필요로 함
                        foreach(string receiveData in receiveDatas)
                            if (!receiveData.Equals(""))
                                try
                                {
                                    log.Info(String.Format("req {0}", content));
                                    RequestController.CallApi(receiveData, handler);
                                }
                                catch (Exception e)
                                {
                                    log.Error(e.Message);
                                    Send(Common.getErrorFormat("50000"));
                                }

                    }
                }
                state.sb.Clear();
                receiveDone.Set();
                if (!handler.Connected)
                    return;
                state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
                receiveDone.WaitOne();
            }
            catch (SocketException se)
            {
                log.Error(se.Message);
                new ConnectedExit(null, handler);
                return;
            }
            catch (ObjectDisposedException oe)
            {
                log.Error(oe.Message);
                return;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Send(Common.getErrorFormat("50000"));
            }
        }


        // ---------- Send Method --------------
        public static void Send(String sendData)
        {

            try
            {
                string data = sendData + "<EOF>";
                log.Info(String.Format("res {0}", data));
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.UTF8.GetBytes(data);
                // Begin sending the data to the remote device.
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);
                sendDone.WaitOne();
            }
            catch (SocketException se)
            {
                log.Error(se.Message);
                new ConnectedExit(null, handler);
                return;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                new ConnectedExit(null, handler);
                return;
            }
        }
        public static void Send(String sendData, String[] userList)
        {
            try
            {
                string data = sendData + "<EOF>";
                log.Info(String.Format("res {0}", data));
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.UTF8.GetBytes(data);
                // Begin sending the data to the remote device.  
                foreach (string userUuid in userList)
                {
                    Socket handler = Info.MultiUserHandler[userUuid];
                    handler.BeginSend(byteData, 0, byteData.Length, 0,
                        new AsyncCallback(SendCallback), handler);
                    sendDone.WaitOne();
                }
            }
            catch (SocketException se)
            {
                log.Error(se.Message);
                new ConnectedExit(null, handler);
                return;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Send(Common.getErrorFormat("50000"));
            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;
                //TODO 클라이언트측에서 이전 전송 정보를 받는 문제 수정 필요.
                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                sendDone.Set();
            }
            catch (SocketException se)
            {
                log.Error(se.Message);
                new ConnectedExit(null, handler);
                return;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Send(Common.getErrorFormat("50000"));
            }
        }
    }
}