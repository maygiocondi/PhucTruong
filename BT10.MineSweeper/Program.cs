string[,] map ={
                {"*","","","",""},
                {"","","","*",""},
                {"","","*","","*"},
                {"","","","",""},
            };
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == "*")
                    {

                    }
                    else
                    {
                        string phia_tren_trai = map[x - 1, y - 1];
                        string phia_tren = map[x, y - 1];
                        string phia_tren_phai = map[x+1,y-1];
                    }
                }
            }