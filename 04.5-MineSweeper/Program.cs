namespace MineSweeper
{
    class MineSweeper
    {
        static void Main(string[] args)
        {
            string[,] map ={
                {"*","","","",""},
                {"","","","*",""},
                {"","","*","","*"},
                {"","","","",""},
            };
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    if (map[y, x] == "*")
                    {

                    }
                    else
                    {
                        int dem_so_bom = 0;

                        int[,] xung_quanh = {
                            {y-1,x-1},{y-1,x+0},{y-1,x+1},
                            {y+0,x-1}          ,{y+0,x+1},
                            {y+1,x-1},{y+1,x+0},{y+1,x+1}
                        };
                        for (int i = 0; i < xung_quanh.GetLength(0); i++)
                        {
                            if (xung_quanh[i, 0] < 0 || xung_quanh[i, 1] < 0
                            || xung_quanh[i, 0] >= map.GetLength(0) || xung_quanh[i, 1] >= map.GetLength(1))
                            {

                            }
                            else
                            {
                                if (map[xung_quanh[i, 0], xung_quanh[i, 1]] == "*")
                                {
                                    dem_so_bom++;
                                }
                            }
                        }
                        map[y, x] = dem_so_bom.ToString();
                    }
                }
            }
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);

                }
                Console.WriteLine();
            }

        }

    }
}