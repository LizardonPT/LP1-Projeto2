using System;

namespace Tabuleiro
{
    class Program
    {
        static void Main(string[] args)
        {
            //Map creation
            //Black = 2 e White = 3
            /* 
            4 is for the backline that are longer, it will simplify the work
            for the movement
            */

            int [,] map = new int [5,9];
            
            //Fill the board
            for (int e=0; e<5;e++)
            {
                for(int i=0; i<9; i++)
                {
                    if((e == 0) || (e==4))
                    {
                        map[e,i] = 4;
                    }
                    else
                    {
                        map[e,i] = 0;
                    }
                }
            }

            //Unoccupied case

            map [2,4] = 1;

            //Black starting position

            for(int i=0; i<9; i+=4)
            {
                map[0,i] = 2;
            }
            for(int i=2; i<7; i+=2)
            {
                map[1,i] = 2;
            }

            //White starting position

            for(int i=0; i<9; i+=4)
            {
                map[4,i] = 3;
            }
            for(int i=2; i<7; i+=2)
            {
                map[3,i] = 3;
            }            
            Board(map);

        }
        
        //To draw the board
        static void Board(int [,] map)
        {
            for(int x=0; x<5; x++)
            {
                for(int y=0; y<9; y++)
                {
                    if(map[x,y] == 2)
                    {
                        Console.Write("B");
                    }

                    else if(map[x,y] == 3)
                    {
                        Console.Write("W");
                    }

                    else if(map[x,y] == 1)
                    {
                        Console.Write("_");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
