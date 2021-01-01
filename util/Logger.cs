using System;
using System.IO;

namespace patting_server.util
{
    public class Logger
    {
        public static string GetDateTime(){
            DateTime NowDate = DateTime.Now;
            return NowDate.ToString("yyyy-MM-dd HH:mm:ss")+":"+NowDate.Millisecond.ToString("000");
        }
        
        public static void Log(string str){
            string StartUpPath = System.IO.Directory.GetCurrentDirectory();
            string FilePath= StartUpPath+@"\Logs\Log"+DateTime.Today.ToString("yyyyMMdd")+".log";
            string DirPath = StartUpPath+@"\Logs";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            try{
                if(di.Exists != true){
                    Directory.CreateDirectory(DirPath);}
                
                if(fi.Exists != true){
                    using (StreamWriter sw = new StreamWriter(FilePath)){
                        temp = string.Format("[{0}] : {1}", GetDateTime(), str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else{
                    using (StreamWriter sw = File.AppendText(FilePath)){
                        temp = string.Format("[{0}] : {1}", GetDateTime(), str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}