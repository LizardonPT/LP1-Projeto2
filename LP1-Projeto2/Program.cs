using System;
using System.Reflection;

namespace LP1_Projeto2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Variabels 
            string menu_awnser;
            int menu_action = 0;
            bool color_selection = true;
            string player1 = "z";

            // Menu

            while (true)
            {
                Console.WriteLine("Welcome to Felli : The Game");
                Console.WriteLine("          Play             ");
                Console.WriteLine("          Rules            ");
                Console.WriteLine("          Quit             ");


                menu_awnser = Console.ReadLine();
                MenuOption option = (MenuOption)Enum.Parse(typeof(MenuOption),
                menu_awnser, true);

                /*
                    Depending of what the player choses, the game may start
                    , show the rules or quit the program.
                    The player can also quit at any moment of the game.
                */
                switch (option)
                {
                    case MenuOption.Play:
                        menu_action = 1;
                        break;
                    case MenuOption.Rules:
                        menu_action = 2;
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("Quitting the game ...");
                        Console.WriteLine("----------------------------------");
                        return;
                }

                // The game starts

                if (menu_action == 1)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("May the game begin !");
                    Console.WriteLine("-----------------------------------");
                    break;
                }

                // Shows the rules

                else if (menu_action == 2)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.Write("Each player chooses a color ");
                    Console.WriteLine("and you most decide who starts.");
                    Console.Write("You can move only one piece per turn,");
                    Console.Write("it can be moved in one non occupied");
                    Console.Write("space or it can leap over an enemy piece,");
                    Console.WriteLine("eliminating it in the process.");
                    Console.Write("To win, you must elimate all the enemies");
                    Console.WriteLine("pieces or block them.");
                    Console.WriteLine("-----------------------------------");
                }

            }

            //Map creation
            //Black = 2 e White = 3
            /* 
            4 is for the backline that are longer, it will simplify the work
            for the movement
            */

            int [,] map = new int [5,9];
            
            //Fill the board
            
            for(int i=0; i<9; i++)
            {
                map[0,i] = 4;
                map[4,i] = 4;
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

            //Players choose who starts
            while (color_selection)
            {
                Console.WriteLine("Choose Starting Color");
                Console.WriteLine("(Black or White)");
                string player_color = Console.ReadLine();
                ColorList color1 = (ColorList)Enum.Parse(typeof(ColorList), 
                player_color, true);

                if (color1 == ColorList.Black)
                {
                    player1 = "B";
                    color_selection = false;
                }
                else if (color1 == ColorList.White)
                {
                    player1 = "W";
                    color_selection = false;
                }
                else
                {
                    Console.WriteLine("Invalid Color");
                }
            }

            //The game itself WIP
            GameLoop(map, player1);
            
        }

        static void GameLoop(int [,] map, string Player1)
        {
            bool loop = true;
            do
            {
                //Board()

                if (Player1 == "W")
                {

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("White, it's your turn:");
                    Console.WriteLine("-----------------------------------");

                    white_turn(map, Player1);
                    if (Player1 == "WIN")
                    {
                        Console.WriteLine("White wins !!!");
                        Console.WriteLine("Game Over");
                        break;
                    }
                }
                else
                {

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Black, it's your turn:");
                    Console.WriteLine("-----------------------------------");

                    black_turn(map, Player1);
                    if (Player1 == "WIN")
                    {
                        Console.WriteLine("Black wins !!!");
                        Console.WriteLine("Game Over");
                        break;
                    }
                }
            } while (loop);
        }

        static string black_turn(int [,] map, string player) //WIP (string)
        {
            /* 
            Need to create a class for the black pieces (maybe, it depends if 
            the class for the pieces is specified or not), then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */
            return;
        }

        static string white_turn(int [,] map, string Player)//WIP (string)
        {
            /* 
            Need to create a class for the white pieces (maybe, it depends if 
            the class for the pieces is specified or not), then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */
            return;
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
