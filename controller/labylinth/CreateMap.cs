using System;
using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;
using partting_server.lib;


namespace partting_server.controller
{

    public class CreateMap
    {
        public const int LEFT = 0;
        public const int RIGHT = 1;
        public const int UP = 2;
        public const int DOWN = 3;
        public int columns; //배열의 행에 해당함
        public int rows; // 배열의 열에 해당함
        private static Random random = new Random();

        private int[,,] grid; //미로를 만들기 위한 격자 생성 {left,right,up,down}
        private string[,] Spawn; //유닛 오브젝트의 위치를 지정하기 위한 배열 생성
        private int[,] patrolPoint;
        private int initcolumn; // 행에 대한 미로찾기를 위한 처음의 시작값
        private int initrow;  // 열에 대한 미로찾기를 위한 처음의 시작값
        private int trapCount; //함정 오브젝트의 수량 제한
        private HashSet<string> visitCell = new HashSet<string>();
        public CreateMap(int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
            this.initcolumn = random.Next(0, columns);
            this.initrow = random.Next(0, rows);
            this.trapCount = (int)(columns * rows * 4 / 10);
            CreateGrid(this.columns, this.rows);
            HuntAndKill();
            SetPatrolPoint(5);
            SetTrap(trapCount);
            Connection.Send(Common.getResponseFormat("createMap", this.ToString()));
        }
        public CreateMap(int size) : this(size, size) { }
        void CreateGrid(int columns, int rows) // 그리드를 쉽게 호출하기 위해 함수로 정의
        {
            grid = new int[columns, rows, 4]; //행과 열을 설정하여 미로를 위한 격자를 초기화함
            Spawn = new string[columns, rows];
            patrolPoint = new int[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < grid.GetLength(2); k++)
                        grid[i, j, k] = 0;
                    Spawn[i, j] = "";
                    patrolPoint[i, j] = 0;
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
            Walk(initcolumn, initrow);
            while (!Hunt()) ;
        }

        void Walk(int column, int row)
        {
            visitCell.Add(PointToString(column, row)); // 현재 행과 열에 대해 방문한 grid를 저장한다. / 랜덤한 방향으로 나아가기 위한 첫번째 cell을 방문한 것으로 처리한다.
            int[] notVisitedArray = GetNotVisitedNeighbors(column, row); // 방문하지 않은 grid들을 가져온다.
            if (notVisitedArray.Length <= 0)
                return;
            int direction = random.Next(0, notVisitedArray.Length); // 방문하지 않은 grid들(notVisitedArray) 중에서 
            DestroyWall(column, row, notVisitedArray[direction]);
            direction = notVisitedArray[direction];
            // 위쪽방향 확인
            switch (direction)
            {
                case LEFT:
                    DestroyWall(column, row - 1, RIGHT);
                    Walk(column, row - 1);
                    break;
                case RIGHT:
                    DestroyWall(column, row + 1, LEFT);
                    Walk(column, row + 1);
                    break;
                case UP:
                    DestroyWall(column - 1, row, DOWN);
                    Walk(column - 1, row);
                    break;
                case DOWN:
                    DestroyWall(column + 1, row, UP);
                    Walk(column + 1, row);
                    break;
                default:
                    break;
            }
        }
        bool Hunt() //방문하지 않은 길을 찾기 위함
        {
            IEnumerator<string> visitCellEnum = visitCell.GetEnumerator();
            while (visitCellEnum.MoveNext())
            {

                string[] columnAndCol = visitCellEnum.Current.Split(",");
                int column = int.Parse(columnAndCol[0]);
                int row = int.Parse(columnAndCol[1]);
                if (GetNotVisitedNeighbors(column, row).Length > 0) //해당 배열의 방문여부 확인 후 방문 했다면  계속 방문하지 않았다면 walk 실행
                {
                    Walk(column, row);
                    return false;
                }
            }

            return true;
        }
        void DestroyWall(int column, int row, int direction) //벽제거(사냥)을 위한 함수
        {
            switch (direction)
            {
                case LEFT:
                    grid[column, row, LEFT] = 0;
                    break;
                case RIGHT:
                    grid[column, row, RIGHT] = 0;
                    break;
                case UP:
                    grid[column, row, UP] = 0;
                    break;
                case DOWN:
                    grid[column, row, DOWN] = 0;
                    break;
            }

        }
        public bool IsVisited(int column, int row)
        {

            if ((0 > column || column >= columns) || (0 > row || row >= rows))
                return true;
            return visitCell.Contains(PointToString(column, row));
        }

        public bool IsVisitedNeighbors(int currentcolumn, int currentrow)
        {
            {
                int columnSub = 1;
                int rowSub = 1;
                for (int i = 0; i < 2; i++)
                {
                    columnSub *= -1;
                    for (int j = 0; j < 2; j++)
                    {
                        rowSub *= -1;
                        if (!IsVisited(currentcolumn + columnSub, currentrow + rowSub))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public int[] GetNotVisitedNeighbors(int currentcolumn, int currentrow)
        {
            List<int> notVisitedArray = new List<int>();
            if (!IsVisited(currentcolumn, currentrow - 1))
                notVisitedArray.Add(LEFT);
            if (!IsVisited(currentcolumn, currentrow + 1))
                notVisitedArray.Add(RIGHT);
            if (!IsVisited(currentcolumn- 1, currentrow ))
                notVisitedArray.Add(UP);
            if (!IsVisited(currentcolumn + 1, currentrow))
                notVisitedArray.Add(DOWN);
            return notVisitedArray.ToArray();
        }
        string PointToString(int column, int row)
        {
            return String.Format("{0},{1}", column, row);
        }
        void SetTrap(int count)
        {
            for (int i = 0; i < count; i++)
            {
                // 함정을 랜덤으로 생성하는 역할
                int column = random.Next(1, (rows - 2));
                int row = random.Next(1, (columns - 2));
                int Rand = random.Next(0, 2);
                //Player Respon구간은 각 모서리의 2*2구간만큼 랜덤 리스폰 구상중
                //AI Respon구간은 정 중앙의 3*3구간의 랜덤 리스폰 구상중
                if (Spawn[column, row].Equals("")) // ResponCheck를 통해 해당 배열구간에 다른 오브젝트의 여부를 확인 추후(AI,Player)를 추가하여 함정 설치
                {
                    if (Rand == 0)
                    { //가시함정 오브젝트
                        Spawn[column, row] = "SpikeTrap";
                    }
                    if (Rand == 1)
                    {//바닥함정 오브젝트
                        Spawn[column, row] = "HoleTrap";
                    }
                }
            }
        }
        void SetPatrolPoint(int count)
        {

            for (int i = 0; i < count; i++)
            {
                // 함정을 랜덤으로 생성하는 역할
                int column = random.Next(1, (rows - 2));
                int row = random.Next(1, (columns - 2));
                
                patrolPoint[column, row]=1;
            }
        }
        public override string ToString()
        {
            string response = JsonConvert.SerializeObject(new { labylinthArray = grid,patrolPoint=patrolPoint, trap = Spawn, clearItem = new { x= 12, y=  4 } });
            Console.WriteLine(response);
            return response;
        }
    }
}

