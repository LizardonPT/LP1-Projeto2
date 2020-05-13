using System;
using System.Reflection;

namespace LP1_Projeto2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Variabels 
            string color_turn;
            string menu_awnser;
            int menu_action = 0;
            bool color_selection = true;
            string player1, player2;

            // Menu

            while (true)
            {
                Console.WriteLine("Welcome to Felli : The Game");
                Console.WriteLine("          Play             ");
                Console.WriteLine("          Rules            ");
                Console.WriteLine("          Quit             ");


                menu_awnser = Console.ReadLine();
                MenuOption option = (MenuOption)Enum.Parse(typeof(MenuOption), menu_awnser, true);

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
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Quitting the game ...");
                        Console.WriteLine("-----------------------------------");
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
                    Console.Write("Each player chooses a color");
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

            //Create the board (WIP) and show it


            //Players choose who starts
            while (color_selection)
            {
                Console.WriteLine("Choose Starting Color");
                Console.WriteLine("(Black or White)");
                string player_color = Console.ReadLine();
                ColorList color1 = (ColorList)Enum.Parse(typeof(ColorList), player_color, true);

                if (color1 == ColorList.Black)
                {
                    player1 = "B";
                }
                else if (color1 == ColorList.White)
                {
                    player1 = "W";
                }
                else
                {
                    Console.WriteLine("Invalid Color");
                }
            }

            //The game itself WIP
            GameLoop(player1);
            
        }

        static string black_turn() //WIP
        {
            /* 
            Need to create a class for the black pieces, then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */
            return color_turn;
        }

        static string white_turn()//WIP
        {
            /* 
            Need to create a class for the white pieces (maybe, it depends if 
            the class for the pieces is specified or not), then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */
            return color_turn;
        } 
        static void GameLoop(string Player1)
        {
            bool loop = true;
            do
            {
                //Board()

                if (Player1 == "W")
                    white_turn();
                else
                    black_turn();
                //Board()

                //Verificar se ganhou


            } while (loop);
        }
    }
}
