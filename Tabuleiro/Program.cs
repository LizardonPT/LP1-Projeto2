using System;

namespace Tabuleiro
{
    class Program
    {
        static void Main(string[] args)
        {
            //Map creation
            //Black = 0 e White = 1

            int [,] map = new int [9,5];
            
            //Black starting position
            for(int i=0; i<9; i+=4)
            {
                map[i,0] = 0;
            }
            for(int i=2; i<6; i+=2)
            {
                map[i,1] = 0;
            }

            //White starting position
            for(int i=2; i<6; i+=2)
            {
                map[i,3] = 1;
            }
            for(int i=0; i<9; i+=4)
            {
                map[i,4] = 1;
            }
            
            //Casas inexistentes (valor = -1)
            for(int i=0; i<9; i+=1)
            {
                if(i != 0 || i != 4 || i != 8)
                {
                    map[i,0] = -1;
                }
            }

            for(int i=0; i<9; i+=1)
            {
                if(i != 2 || i != 4 || i != 6)
                {
                    map[i,1] = -1;
                }
            }

            for(int i=0; i<9; i+=1)
            {
                if(i != 4)
                {
                    map[i,2] = -1;
                }
            }

            for(int i=0; i<9; i+=1)
            {
                if(i != 2 || i != 4 || i != 6)
                {
                    map[i,3] = -1;
                }
            }

            for(int i=0; i<9; i+=1)
            {
                if(i != 0 || i != 4 || i != 8)
                {
                    map[i,4] = -1;
                }
            }
            Board(map);

        }
        
        //To draw the board
        static void Board(int [,] map)
        {
            for(int x=0; x<9; x++)
            {
                for(int y=0; y<5; y++)
                {
                    if(map[x,y] == 0)
                    {
                        Console.Write("B");
                    }

                    else if(map[x,y] == 1)
                    {
                        Console.Write("W");
                    }

                    else if(map[x,y] == -1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
