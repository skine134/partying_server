namespace partying_server.util
{
    public class CellInfo
    {
        public int col, row;
        public object data;
        public CellInfo(int col,int row,object data){
            this.col=col;
            this.row=row;
            this.data=data;
        }
        public CellInfo():this(0,0,null){}
    }
}