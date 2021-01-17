using System;
using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;
using partting_server.lib;


namespace patting_server.controller.labylinth
{
    public class MapInfo
    {
        public int[,,] wallInfo;
        public int[,] patrolpointInfo;
        public string[,] trapInfo;
        public Point clearItemLocation;
        public MapInfo(int[,,] wallInfo, int[,] patrolpointInfo, string[,] trapInfo, Point clearItemLocation)
        {
            this.wallInfo = wallInfo;
            this.patrolpointInfo = patrolpointInfo;
            this.trapInfo = trapInfo;
            this.clearItemLocation = clearItemLocation;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { labylinthArray = wallInfo, patrolpoint = patrolpointInfo, trap = trapInfo, clearItem = clearItemLocation });
        }
    }

    public class CreateMap
    {
        public const int LEFT = 0;
        public const int RIGHT = 1;
        public const int UP = 2;
        public const int DOWN = 3;
        public const int Rows = 20; //배열의 행에 해당함
        public const int Columns = 20; // 배열의 열에 해당함
        private static Random random = new Random();

        private int[,,] grid; //미로를 만들기 위한 격자 생성 {left,right,up,down}
        private string[,] Spawn; //유닛 오브젝트의 위치를 지정하기 위한 배열 생성
        private int initRow = random.Next(0, Rows); // 행에 대한 미로찾기를 위한 처음의 시작값
        private int initColumn = random.Next(0, Columns); // 열에 대한 미로찾기를 위한 처음의 시작값
        private int trapCount = 15; //함정 오브젝트의 수량 제한
        private HashSet<string> visitCell = new HashSet<string>();

        public CreateMap(int Rows, int Columns)
        {
            CreateGrid(Rows, Columns);
            HuntAndKill();
            SetTrap(trapCount);
            MapInfo mapInfo = new MapInfo(grid,new int[0,0],Spawn,new Point(initRow,initColumn));
            Connection.Send(mapInfo.ToString());
        }
        void CreateGrid(int rows, int columns) // 그리드를 쉽게 호출하기 위해 함수로 정의
        {
            grid = new int[rows, columns, 4]; //행과 열을 설정하여 미로를 위한 격자를 초기화함
            Spawn = new string[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < grid.GetLength(2); k++)
                        grid[i, j, k] = 0;
                    Spawn[i, j] = "";
                    if (j == 0)
                        grid[i, j, LEFT] = 1;
                    grid[i, j, RIGHT] = 1;
                    if (i == 0)
                        grid[i, j, UP] = 1;
                    grid[i, j, DOWN] = 1;
                }
            }
        }

        void HuntAndKill()
        {
            Walk(initRow, initColumn);
            while (Hunt()) ;
        }

        void Walk(int row, int column)
        {
            visitCell.Add(PointToString(row, column)); // 현재 행과 열에 대해 방문한 grid를 저장한다. / 랜덤한 방향으로 나아가기 위한 첫번째 cell을 방문한 것으로 처리한다.
            int[] notVisitedArray = GetNotVisitedNeighbors(row, column); // 방문하지 않은 grid들을 가져온다.
            if (notVisitedArray.Length <= 0)
                return;
            int direction = random.Next(0, notVisitedArray.Length); // 방문하지 않은 grid들(notVisitedArray) 중에서 
            DestroyWall(row, column, notVisitedArray[direction]);
            // 위쪽방향 확인
            switch (notVisitedArray[direction])
            {
                case LEFT:
                    DestroyWall(row - 1, column, RIGHT);
                    Walk(row - 1, column);
                    break;
                case RIGHT:
                    DestroyWall(row + 1, column, LEFT);
                    Walk(row + 1, column);
                    break;
                case UP:
                    DestroyWall(row, column - 1, DOWN);
                    Walk(row, column - 1);
                    break;
                case DOWN:
                    DestroyWall(row, column + 1, UP);
                    Walk(row, column + 1);
                    break;
                default:
                    break;
            }
        }
        bool Hunt() //방문하지 않은 길을 찾기 위함
        {
            IEnumerator<string> visitCellEnum = visitCell.GetEnumerator();
            do
            {

                string[] rowAndCol = visitCellEnum.Current.Split(",");
                int row = int.Parse(rowAndCol[0]);
                int column = int.Parse(rowAndCol[1]);
                if (GetNotVisitedNeighbors(row, column).Length > 0) //해당 배열의 방문여부 확인 후 방문 했다면  계속 방문하지 않았다면 walk 실행
                {
                    Walk(row, column);
                    return false;
                }
            } while (visitCellEnum.MoveNext());

            return true;
        }
        void DestroyWall(int row, int column, int direction) //벽제거(사냥)을 위한 함수
        {
            switch (direction)
            {
                case LEFT:
                    grid[row, column, LEFT] = 0;
                    break;
                case RIGHT:
                    grid[row, column, RIGHT] = 0;
                    break;
                case UP:
                    grid[row, column, UP] = 0;
                    break;
                case DOWN:
                    grid[row, column, DOWN] = 0;
                    break;
            }

        }
        public bool IsVisited(int row, int column)
        {

            if ((0 > row || row >= Rows) || (0 > column || column >= Columns))
                return true;
            return visitCell.Contains(PointToString(row, column));
        }

        public bool IsVisitedNeighbors(int currentRow, int currentColumn)
        {
            {
                int rowSub = 1;
                int columnSub = 1;
                for (int i = 0; i < 2; i++)
                {
                    rowSub *= -1;
                    for (int j = 0; j < 2; j++)
                    {
                        columnSub *= -1;
                        if (!IsVisited(currentRow + rowSub, currentColumn + columnSub))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public int[] GetNotVisitedNeighbors(int currentRow, int currentColumn)
        {
            List<int> notVisitedArray = new List<int>();
            if (!IsVisited(currentRow - 1, currentColumn))
                notVisitedArray.Add(LEFT);
            if (!IsVisited(currentRow + 1, currentColumn))
                notVisitedArray.Add(RIGHT);
            if (!IsVisited(currentRow, currentColumn - 1))
                notVisitedArray.Add(UP);
            if (!IsVisited(currentRow, currentColumn + 1))
                notVisitedArray.Add(UP);
            return notVisitedArray.ToArray();
        }
        string PointToString(int row, int column)
        {
            return String.Format("{0},{1}", row, column);
        }
        void SetTrap(int count)
        {
            for (int i = 0; i < count; i++)
            {
                // 함정을 랜덤으로 생성하는 역할
                int row = random.Next(1, (Columns - 2));
                int column = random.Next(1, (Rows - 2));
                int Rand = random.Next(0, 2);
                //Player Respon구간은 각 모서리의 2*2구간만큼 랜덤 리스폰 구상중
                //AI Respon구간은 정 중앙의 3*3구간의 랜덤 리스폰 구상중
                if (!Spawn[row, column].Equals("")) // ResponCheck를 통해 해당 배열구간에 다른 오브젝트의 여부를 확인 추후(AI,Player)를 추가하여 함정 설치
                {
                    if (Rand == 0)
                    { //가시함정 오브젝트
                        Spawn[row, column] = "SpikeTrap";
                    }
                    if (Rand == 1)
                    {//바닥함정 오브젝트
                        Spawn[row, column] = "HoleTrap";
                    }
                }
            }
        }
    }
}

