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
            int [,] map = new int [5,9];

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
            Pieces black_piece_1 = new Pieces("BP1", new int[] {0,0});
            Pieces black_piece_2 = new Pieces("BP2", new int[] {0,4});
            Pieces black_piece_3 = new Pieces("BP3", new int[] {0,8});

            for(int i=2; i<7; i+=2)
            {
                map[1,i] = 2;
            }
            Pieces black_piece_4 = new Pieces("BP4", new int[] {1,2});
            Pieces black_piece_5 = new Pieces("BP5", new int[] {1,4});
            Pieces black_piece_6 = new Pieces("BP6", new int[] {1,6});

            //White starting position

            for(int i=0; i<9; i+=4)
            {
                map[4,i] = 3;
            }
            Pieces white_piece_1 = new Pieces("WP1", new int[] {4,0});
            Pieces white_piece_2 = new Pieces("WP2", new int[] {4,4});
            Pieces white_piece_3 = new Pieces("WP3", new int[] {4,8});

            for(int i=2; i<7; i+=2)
            {
                map[3,i] = 3;
            }            
            Pieces white_piece_4 = new Pieces("WP4", new int[] {3,2});
            Pieces white_piece_5 = new Pieces("WP5", new int[] {3,4});
            Pieces white_piece_6 = new Pieces("WP6", new int[] {3,6});

            //Draws the board on the console
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
            GameLoop(map, player1, black_piece_1, black_piece_2, black_piece_3,
            black_piece_4, black_piece_5, black_piece_6);
            
        }

        //Method to mantain the game working
        static void GameLoop(int [,] map, string Player1, Pieces black_piece_1, 
        Pieces black_piece_2, Pieces black_piece_3, Pieces black_piece_4, 
        Pieces black_piece_5, Pieces black_piece_6)
        {
            bool loop = true;
            do
            {
                //Board()
                /*Checks what was the player choice for the starting color and
                and write a text saying ho's going to play that turn*/

                if (Player1 == "W")
                {

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("White, it's your turn:");
                    Console.WriteLine("-----------------------------------");

                    //Calls the method for the white turn
                    white_turn(map, Player1);
                    
                    //Condition to see if the player with the white pieces won
                    if (Player1 == "WIN")
                    {
                        Console.WriteLine("White wins !!!");
                        Console.WriteLine("Game Over");
                        break;
                    }
                }
                else if (Player1 == "B")
                {

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Black, it's your turn:");
                    Console.WriteLine("-----------------------------------");
                    
                    //Calls the method for the black turn
                    black_turn(map, Player1, black_piece_1, black_piece_2, 
                    black_piece_3,black_piece_4, black_piece_5, black_piece_6);

                    //Condition to see if the player with the black pieces won
                    if (Player1 == "WIN")
                    {
                        Console.WriteLine("Black wins !!!");
                        Console.WriteLine("Game Over");
                        break;
                    }
                }
            } while (loop);
        }

        //Method to make all the black turn process steps
        static string black_turn(int [,] map, string player, 
        Pieces black_piece_1, Pieces black_piece_2, Pieces black_piece_3, 
        Pieces black_piece_4, Pieces black_piece_5, Pieces black_piece_6) 
        {
            /* 
            Need to create a class for the black pieces (maybe, it depends if 
            the class for the pieces is specified or not), then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */

            //Variables of the method
            bool chosen_piece = false;
            string piecechosen;
            int the_piece = 0;

            //Draws the board on the console
            Board(map);

            /*Checks which black pieces are alive and asks the player which one
            he wants to move*/
            Console.WriteLine("Which black piece are you going to move?");
            Console.Write("|");

            if (black_piece_1.GetAlive())
            {
                Console.Write($" {black_piece_1.GetName()} |");
            }
            if (black_piece_2.GetAlive())
            {
                Console.Write($" {black_piece_2.GetName()} |");
            }
            if (black_piece_3.GetAlive())
            {
                Console.Write($" {black_piece_3.GetName()} |");
            }
            if (black_piece_4.GetAlive())
            {
                Console.Write($" {black_piece_4.GetName()} |");
            }
            if (black_piece_5.GetAlive())
            {
                Console.Write($" {black_piece_5.GetName()} |");
            }
            if (black_piece_6.GetAlive())
            {
                Console.Write($" {black_piece_6.GetName()} |");
            }

            Console.WriteLine("");

            //Reads the input of the player
            piecechosen = Console.ReadLine();

            //Checks if the input is valid, if not, the user needs to try again
            while(chosen_piece != true)
            {
                switch (piecechosen)
                {
                    case "BP1":
                        chosen_piece = true;
                        the_piece = 1;
                        break;
                    
                    case "BP2":
                        chosen_piece = true;
                        the_piece = 2;
                        break;
                    
                    case "BP3":
                        chosen_piece = true;
                        the_piece = 3;
                        break;
                    
                    case "BP4":
                        chosen_piece = true;
                        the_piece = 4;
                        break;
                    
                    case "BP5":
                        chosen_piece = true;
                        the_piece = 5;
                        break;

                    case "BP6":
                        chosen_piece = true;
                        the_piece = 6;
                        break;
                    
                    case "Quit":
                        
                        break;
                    
                    default:
                        Console.WriteLine("That's not a valid option");
                        piecechosen = Console.ReadLine();
                        break;
                }

                player = blackmovement(map, player, the_piece, black_piece_1, 
                black_piece_2, black_piece_3, black_piece_4, black_piece_5, 
                black_piece_6);

                
            }

            return player;
        }

        //Method that will make the black pieces move in the game
        static string blackmovement( int [,] map, string player, int the_piece,
        Pieces black_piece_1, Pieces black_piece_2, Pieces black_piece_3, 
        Pieces black_piece_4, Pieces black_piece_5, Pieces black_piece_6) 
        {
            //Variables of the method
            int [] pos = new int[2];
            int possible_mov = 0;
            
            //Gets the position in the board of the piece chosen by the player
            if(the_piece == 1)
            {
                pos = black_piece_1.GetPos();
            }
            if(the_piece == 2)
            {
                pos = black_piece_2.GetPos();
            }
            if(the_piece == 3)
            {
                pos = black_piece_3.GetPos();
            }
            if(the_piece == 4)
            {
                pos = black_piece_4.GetPos();
            }
            if(the_piece == 5)
            {
                pos = black_piece_5.GetPos();
            }
            if(the_piece == 6)
            {
                pos = black_piece_6.GetPos();
            }

            /*Will analyze the surroundings of the selected piece and say
            what's the movements the player can do*/
            Console.WriteLine("Doable Movements :");

            //Analyze the line in x coordinates
            for(int x=-1; x<2; x++)
            {
                //Analyze the line in y coordinates
                for(int y =-2; y<3; y+= 2)
                {
                    /*Checks if the closest spaces to the chosen piece are
                    in the board*/
                    if((pos[0]+x > -1) && (pos[0]+x < 5) && (pos[1]+y > -1) 
                    && (pos[1]+y < 9))
                    {
                        //Checks if the chosen pice is in the backline 
                        if ((map[pos[0]+x,pos[1]+y] == 4) && ((pos[0] == 0) ||
                        (pos[0] == 4)))
                        {
                            /*Checks if there is any enemy piece in the
                            back line*/
                            if (map[pos[0]+x,pos[1]+(y*2)] == 3 && 
                            (pos[1]+(y*4) > -1) && (pos[1]+(y*4) < 9))
                            {
                                /*Checks if there is any free space after the
                                enemy, so the player can eat the enemy piece*/
                                if (map[pos[0]+x,pos[1]+(y*4)] == 1)
                                {
                                    Console.WriteLine(
                                    $"{pos[0]+x}, {pos[1]+(y*4)}");
                                    map[pos[0]+x,pos[1]+(y*4)] = 5;
                                    possible_mov += 1;
                                }
                            }
                            /*Checks if there is any free space to move the
                            piece in the back line*/
                            if (map[pos[0]+x,pos[1]+(y*2)] == 1)
                            {
                                Console.WriteLine(
                                $"{pos[0]+x}, {pos[1]+(y*2)}");
                                map[pos[0]+x,pos[1]+(y*2)] = 5;
                                possible_mov += 1;
                            }
                        }
                        /*Checks if its a white piece and if the surrounding
                        is in the board*/
                        else if ((map[pos[0]+x,pos[1]+y] == 3) && 
                        ((pos[0]+(x*2) > -1) && (pos[0]+(x*2) < 5) && 
                        (pos[1]+(y*2) > -1) && (pos[1]+(y*2) < 9)))
                        {
                            /*Checks if that surrounding is free so the player
                            can eat the white piece*/
                            if (map[pos[0]+(x*2),pos[1]+(y*2)] == 1)
                            {
                                Console.WriteLine(
                                $"{pos[0]+(x*2)}, {pos[1]+(y*2)}");
                                map[pos[0]+(x*2),pos[1]+(y*2)] = 5;
                                possible_mov += 1;
                            }
                        }
                        /*Checks if there is any free space in the rest of the
                        lines*/
                        else if (map[pos[0]+x,pos[1]+(y)] == 1)
                        {
                            Console.WriteLine($"{pos[0]+x}, {pos[1]+y}");
                            map[pos[0]+x,pos[1]+y] = 5;
                            possible_mov += 1;
                        }

                    }
                }
            }
            
            /*string coord = Console.ReadLine();
            if(coord == "2, 4" || coord == "2,4")
            {
                pos = 
                //escrever o q aconteceu
            }*/

            player = "W";


            return player;
        }




        static void white_turn(int [,] map, string Player)//WIP (string)
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
