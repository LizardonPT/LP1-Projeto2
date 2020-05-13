using System;

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

                if (color1 == ColorList.Black || color1 == ColorList.White)
                    color_selection = false;
                else
                    Console.WriteLine("Invalid Color");
            }

            //The game itself
            while (true)
            {
                if (color_turn == "B")
                {
                    color_turn = black_turn();

                    if (color_turn = "WIN")
                    {
                        Console.WriteLine("Black player win !!!");
                        Console.WriteLine("Game Over");
                        break;
                    }
                }
                if (color_turn == "W")
                {
                    color_turn = white_turn();

                    if (color_turn = "WIN")
                    {
                        Console.WriteLine("White player win !!!");
                        Console.WriteLine("Game Over");
                        break;
                    }
                }
            }
        }

        static string black_turn()
        {
            /* 
            Need to create a class for the black pieces, then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */
            return color_turn;
        }

        static string white_turn()
        {
            /* 
            Need to create a class for the white pieces (maybe, it depends if 
            the class for the pieces is specified or not), then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */
            return color_turn;
        }
    }
}
