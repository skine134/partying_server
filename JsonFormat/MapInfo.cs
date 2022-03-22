using partying_server.util;

namespace partying_server.JsonFormat
{
    public class MapInfo
    {
        public int[,,] labylinthArray;
        public CellInfo[] patrolPoints;
        public CellInfo[] trap;
        public CellInfo[] playerLocs;
        public Division2 clearItem;
    }
}