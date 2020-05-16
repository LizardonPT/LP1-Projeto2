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
            string player = "z";
            int [,] map = new int [5,9];

            Pieces black_piece_1 = new Pieces("BP1", new int[] {0,0});
            Pieces black_piece_2 = new Pieces("BP2", new int[] {0,4});
            Pieces black_piece_3 = new Pieces("BP3", new int[] {0,8});
            Pieces black_piece_4 = new Pieces("BP4", new int[] {1,2});
            Pieces black_piece_5 = new Pieces("BP5", new int[] {1,4});
            Pieces black_piece_6 = new Pieces("BP6", new int[] {1,6});

            Pieces white_piece_1 = new Pieces("WP1", new int[] {4,0});
            Pieces white_piece_2 = new Pieces("WP2", new int[] {4,4});
            Pieces white_piece_3 = new Pieces("WP3", new int[] {4,8});
            Pieces white_piece_4 = new Pieces("WP4", new int[] {3,2});
            Pieces white_piece_5 = new Pieces("WP5", new int[] {3,4});
            Pieces white_piece_6 = new Pieces("WP6", new int[] {3,6});

            // Menu

            while (true)
            {
                Console.WriteLine("Welcome to Felli : The Game");
                Console.WriteLine("          Play             ");
                Console.WriteLine("          Rules            ");
                Console.WriteLine("          Quit             ");
                Console.WriteLine("(Please type the pretended option)");
                Console.WriteLine("----------------------------------");

                menu_awnser = Console.ReadLine();
                MenuEnum option; 
                if(Enum.TryParse( menu_awnser, true, out option ))
                {
                    /*
                    Depending of what the player choses, the game may start
                    , show the rules or quit the program.
                    The player can also quit at any moment of the game.
                    */
                    switch (option)
                    {
                        case MenuEnum.Play:
                            menu_action = 1;
                            break;
                        case MenuEnum.Rules:
                            menu_action = 2;
                            break;
                        case MenuEnum.Quit:
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Quitting the game ...");
                            Console.WriteLine("------------------------------");
                            return;

                    }
                 
                }
                else
                {
                    Console.WriteLine("Unvalid option please try again.");
                    continue;
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
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Player 1 Chooses a color and plays first.");
                    Console.Write("Each player can only move 1 piece per turn\n" +
                        "piece can only be moved to a vacant\nadjacent point or " +
                        "jumping through\nan adjacent adversary piece into a vacant" +
                        " point\ncapturing the adversary piece in the process.\n");
                    Console.WriteLine("To win, one of the players must have\nthe adversary " +
                        "pieces captured or immobilized");
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

            //Draws the board on the console
            Board(map, player, ref black_piece_1, ref black_piece_2, 
            ref black_piece_3, ref black_piece_4, ref black_piece_5, 
            ref black_piece_6,ref white_piece_1, ref white_piece_2, 
            ref white_piece_3, ref white_piece_4, ref white_piece_5, 
            ref white_piece_6);

            //Players choose who starts
            while (color_selection)
            {
                Console.WriteLine("Choose Starting Color");
                Console.WriteLine("(Black or White)");
                string player_color = Console.ReadLine();
                ColorEnum color1 = (ColorEnum)Enum.Parse(typeof(ColorEnum), 
                player_color, true);

                if (color1 == ColorEnum.Black)
                {
                    player = "B";
                    color_selection = false;
                }
                else if (color1 == ColorEnum.White)
                {
                    player = "W";
                    color_selection = false;
                }
                else
                {
                    Console.WriteLine("Invalid Color");
                }
            }

            //The game itself WIP
            GameLoop(map, player, ref black_piece_1, ref black_piece_2, 
            ref black_piece_3, ref black_piece_4, ref black_piece_5, 
            ref black_piece_6, ref white_piece_1, ref white_piece_2, 
            ref white_piece_3, ref white_piece_4, ref white_piece_5, 
            ref white_piece_6);
            
        }

        //Method to mantain the game working
        static void GameLoop(int [,] map, string Player, 
        ref Pieces black_piece_1, ref Pieces black_piece_2, 
        ref Pieces black_piece_3, ref Pieces black_piece_4, 
        ref Pieces black_piece_5, ref Pieces black_piece_6,
        ref Pieces white_piece_1, ref Pieces white_piece_2, 
        ref Pieces white_piece_3, ref Pieces white_piece_4, 
        ref Pieces white_piece_5, ref Pieces white_piece_6)
        {
            bool winning = false;
            bool loop = true;
            do
            {
                Board(map, Player, ref black_piece_1, ref black_piece_2, 
                ref black_piece_3, ref black_piece_4, ref black_piece_5, 
                ref black_piece_6,ref white_piece_1, ref white_piece_2, 
                ref white_piece_3, ref white_piece_4, ref white_piece_5, 
                ref white_piece_6);
                /*Checks what was the player choice for the starting color and
                and write a text saying ho's going to play that turn*/

                if (Player == "QUIT")
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                if (Player == "W")
                {
                    //Condition to see if the player with the black pieces won

                    winning = (BlackWinVerification(ref white_piece_1,
                    ref white_piece_2, ref white_piece_3, ref white_piece_4,
                    ref white_piece_5, ref white_piece_6));

                    if (winning)
                    {
                        Console.WriteLine("Game Over");
                        break;
                    }

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("White, it's your turn:");
                    Console.WriteLine("-----------------------------------");

                    //Calls the method for the white turn
                    Player = WhiteTurn(ref map, Player, ref white_piece_1,
                    ref white_piece_2, ref white_piece_3, ref white_piece_4,
                    ref white_piece_5, ref white_piece_6);

                    
                    //Condition to see if the player with the white pieces won
                    
                }
                else if (Player == "B")
                {
                    //Condition to see if the player with the white pieces won

                    winning = WhiteWinVerification(ref black_piece_1, 
                    ref black_piece_2, ref black_piece_3, ref black_piece_4, 
                    ref black_piece_5, ref black_piece_6);

                    if (winning)
                    {
                            Console.WriteLine("Game Over");
                            break;
                    }

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Black, it's your turn:");
                    Console.WriteLine("-----------------------------------");
                    
                    //Calls the method for the black turn
                    Player = BlackTurn(ref map, Player,ref black_piece_1,
                    ref black_piece_2, ref black_piece_3, ref black_piece_4, 
                    ref black_piece_5, ref black_piece_6);

                    //Condition to see if the player with the black pieces won

                }

            } while (loop);
        }

        //Method to make all the black turn process steps
        static string BlackTurn(ref int [,] map, string player, 
        ref Pieces black_piece_1, ref Pieces black_piece_2, 
        ref Pieces black_piece_3, ref Pieces black_piece_4, 
        ref Pieces black_piece_5, ref Pieces black_piece_6)
        {
            /* 
            Need to create a class for the black pieces (maybe, it depends if 
            the class for the pieces is specified or not), then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */

            //Variables of the method
            bool chosen_piece = false;
            string input;
            int the_piece;

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
            input = Console.ReadLine();

            //Checks if the input is valid, if not, the user needs to try again
            while(chosen_piece != true)
            {
                switch (input.ToUpper())
                {
                    case "BP1":
                        if (black_piece_1.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 1;
                            player = BlackMovement(ref map, player, the_piece, 
                            ref black_piece_1, ref black_piece_2, 
                            ref black_piece_3, ref black_piece_4, 
                            ref black_piece_5, ref black_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            input = Console.ReadLine();
                            break;
                        }
                    
                    case "BP2":
                        if (black_piece_2.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 2;
                            player = BlackMovement(ref map, player, the_piece, 
                            ref black_piece_1, ref black_piece_2, 
                            ref black_piece_3, ref black_piece_4, 
                            ref black_piece_5, ref black_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            input = Console.ReadLine();
                            break;
                        }
                    
                    case "BP3":
                        if (black_piece_3.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 3;
                            player = BlackMovement(ref map, player, the_piece, 
                            ref black_piece_1, ref black_piece_2, 
                            ref black_piece_3, ref black_piece_4, 
                            ref black_piece_5, ref black_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            input = Console.ReadLine();
                            break;
                        }
                    
                    case "BP4":
                        if (black_piece_4.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 4;
                            player = BlackMovement(ref map, player, the_piece, 
                            ref black_piece_1, ref black_piece_2, 
                            ref black_piece_3, ref black_piece_4, 
                            ref black_piece_5, ref black_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            input = Console.ReadLine();
                            break;
                        }
                    
                    case "BP5":
                        if (black_piece_5.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 5;
                            player = BlackMovement(ref map, player, the_piece, 
                            ref black_piece_1, ref black_piece_2, 
                            ref black_piece_3, ref black_piece_4, 
                            ref black_piece_5, ref black_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            input = Console.ReadLine();
                            break;
                        }

                    case "BP6":
                        if (black_piece_6.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 6;
                            player = BlackMovement(ref map, player, the_piece, 
                            ref black_piece_1, ref black_piece_2, 
                            ref black_piece_3, ref black_piece_4, 
                            ref black_piece_5, ref black_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            input = Console.ReadLine();
                            break;
                        }
                    
                    case "QUIT":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Quiting the game...");
                        Console.WriteLine("-------------------");
                        player = "QUIT";
                        return player;
                    
                    default:
                        Console.WriteLine("That's not a valid option");
                        input = Console.ReadLine();
                        break;
                }

            }

            return player;
        }

        //Method that will make the black pieces move in the game
        static string BlackMovement(ref int [,] map, string player, 
        int the_piece, ref Pieces black_piece_1, ref Pieces black_piece_2, 
        ref Pieces black_piece_3, ref Pieces black_piece_4, 
        ref Pieces black_piece_5, ref Pieces black_piece_6) 
        {
            //Variables of the method
            int [] pos = new int[2];
            int possible_mov = 0;
            bool answer = true;
            
            //Gets the position in the board of the piece chosen by the player

            if(the_piece == 1)
            {
                pos = black_piece_1.GetPos();
            }
            else if(the_piece == 2)
            {
                pos = black_piece_2.GetPos();
            }
            else if(the_piece == 3)
            {
                pos = black_piece_3.GetPos();
            }
            else if(the_piece == 4)
            {
                pos = black_piece_4.GetPos();
            }
            else if(the_piece == 5)
            {
                pos = black_piece_5.GetPos();
            }
            else if(the_piece == 6)
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
                                    map[pos[0]+(x),pos[1]+(y*2)] = 6;
                                    map[pos[0]+x,pos[1]+(y*4)] = 7;
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
                                map[pos[0]+(x),pos[1]+(y)] = 6;
                                map[pos[0]+(x*2),pos[1]+(y*2)] = 7;
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

            //Checks if the player chooses a piece with a possible movement
            if(possible_mov == 0)
            {
                Console.Write("You can't move that one... Try another one.\n");
                return player;
            }

            else
            {   
                while(answer)
                {
                    //Will demand position x and y for the movement of the piece
                    Console.Write("x = ");
                    string coordx = Console.ReadLine();
                    Console.Write("y = ");
                    string coordy = Console.ReadLine();
                    int coordxnumb = int.Parse(coordx);
                    int coordynumb = int.Parse(coordy);

                    //Check if the input is in one of the said cases
                    if((coordxnumb > -1) && (coordxnumb < 5) && 
                    (coordynumb > -1) && (coordynumb < 9))
                    {
                        if((map[coordxnumb,coordynumb] == 5) ||
                        (map[coordxnumb,coordynumb] == 7))
                        {
                            if (map[coordxnumb, coordynumb] == 5)
                            {
                                for(int x=0; x<5; x++)
                                {
                                    for(int y=0; y<9; y++)
                                    { 
                                        if(map[x,y] == 6)
                                        {
                                            map[x,y] = 3;
                                        }
                                    }
                                }
                            }

                            /*This will put to date the position of the piece
                            in the graphic board*/

                            map[pos[0],pos[1]] = 1;
                            pos[0] = coordxnumb;
                            pos[1] = coordynumb;
                            map[coordxnumb, coordynumb] = 2;

                            /*This will put to date the position of the piece
                            itself*/

                            if(the_piece == 1)
                            {
                                black_piece_1.SetPos(pos);
                            }
                            else if(the_piece == 2)
                            {
                                black_piece_2.SetPos(pos);
                            }
                            else if(the_piece == 3)
                            {
                                black_piece_3.SetPos(pos);
                            }
                            else if(the_piece == 4)
                            {
                                black_piece_4.SetPos(pos);
                            }
                            else if(the_piece == 5)
                            {
                                black_piece_5.SetPos(pos);
                            }
                            else if(the_piece == 6)
                            {
                                black_piece_6.SetPos(pos);
                            }

                            player = "W";
                            answer = false;
                            
                        }

                        else
                        {
                            Console.Write("That's not a valid option... "); 
                            Console.WriteLine("Use one of the options");
                        }
                        
                    }

                    else
                    {
                        Console.Write("That's not a valid option... "); 
                        Console.WriteLine("Use one of the options");
                    }
                }
                
            }

            return player;
        }


        static string WhiteTurn(ref int[,] map, string player, 
            ref Pieces white_piece_1, ref Pieces white_piece_2, 
            ref Pieces white_piece_3, ref Pieces white_piece_4,
            ref Pieces white_piece_5, ref Pieces white_piece_6) //WIP string
        {
            /* 
            Need to create a class for the white pieces (maybe, it depends if 
            the class for the pieces is specified or not), then do the possible
            movement choices and then check the win conditions. We return the
            color_turn to change the turn.
            */

            //Variables of the method
            bool chosen_piece = false;
            string piecechosen;
            int the_piece;

            /*Checks which black pieces are alive and asks the player which one
            he wants to move*/
            Console.WriteLine("Which white piece are you going to move?");
            Console.Write("|");

            if (white_piece_1.GetAlive())
            {
                Console.Write($" {white_piece_1.GetName()} |");
            }
            if (white_piece_2.GetAlive())
            {
                Console.Write($" {white_piece_2.GetName()} |");
            }
            if (white_piece_3.GetAlive())
            {
                Console.Write($" {white_piece_3.GetName()} |");
            }
            if (white_piece_4.GetAlive())
            {
                Console.Write($" {white_piece_4.GetName()} |");
            }
            if (white_piece_5.GetAlive())
            {
                Console.Write($" {white_piece_5.GetName()} |");
            }
            if (white_piece_6.GetAlive())
            {
                Console.Write($" {white_piece_6.GetName()} |");
            }

            Console.WriteLine("");

            //Reads the input of the player
            piecechosen = Console.ReadLine();

            //Checks if the input is valid, if not, the user needs to try again
            while (chosen_piece != true)
            {
                switch (piecechosen.ToUpper())
                {
                    case "WP1":
                        if (white_piece_1.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 1;
                            player = WhiteMovement(ref map, player, the_piece,
                            ref white_piece_1, ref white_piece_2,
                            ref white_piece_3, ref white_piece_4,
                            ref white_piece_5, ref white_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            piecechosen = Console.ReadLine();
                            break;
                        }

                    case "WP2":
                        if (white_piece_2.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 2;
                            player = WhiteMovement(ref map, player, the_piece,
                            ref white_piece_1, ref white_piece_2,
                            ref white_piece_3, ref white_piece_4,
                            ref white_piece_5, ref white_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            piecechosen = Console.ReadLine();
                            break;
                        }

                    case "WP3":
                        if (white_piece_3.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 3;
                            player = WhiteMovement(ref map, player, the_piece,
                            ref white_piece_1, ref white_piece_2,
                            ref white_piece_3, ref white_piece_4,
                            ref white_piece_5, ref white_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            piecechosen = Console.ReadLine();
                            break;
                        }

                    case "WP4":
                        if (white_piece_4.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 4;
                            player = WhiteMovement(ref map, player, the_piece,
                            ref white_piece_1, ref white_piece_2,
                            ref white_piece_3, ref white_piece_4,
                            ref white_piece_5, ref white_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            piecechosen = Console.ReadLine();
                            break;
                        }

                    case "WP5":
                        if (white_piece_5.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 5;
                            player = WhiteMovement(ref map, player, the_piece,
                            ref white_piece_1, ref white_piece_2,
                            ref white_piece_3, ref white_piece_4,
                            ref white_piece_5, ref white_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            piecechosen = Console.ReadLine();
                            break;
                        }

                    case "WP6":
                        if (white_piece_6.GetAlive())
                        {
                            chosen_piece = true;
                            the_piece = 6;
                            player = WhiteMovement(ref map, player, the_piece,
                            ref white_piece_1, ref white_piece_2,
                            ref white_piece_3, ref white_piece_4,
                            ref white_piece_5, ref white_piece_6);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option");
                            piecechosen = Console.ReadLine();
                            break;
                        }

                    case "QUIT":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Quiting the game...");
                        Console.WriteLine("-------------------");
                        chosen_piece = true;
                        player = "QUIT";
                        break;

                    default:
                        Console.WriteLine("That's not a valid option");
                        piecechosen = Console.ReadLine();
                        break;
                }

            }

            return player;
        }

        //Method that will make the black pieces move in the game
        static string WhiteMovement(ref int[,] map, string player, 
        int the_piece, ref Pieces white_piece_1, ref Pieces white_piece_2,
        ref Pieces white_piece_3, ref Pieces white_piece_4,
        ref Pieces white_piece_5, ref Pieces white_piece_6)
        {
            //Variables of the method
            int[] pos = new int[2];
            int possible_mov = 0;
            bool answer = true;

            //Gets the position in the board of the piece chosen by the player

            if (the_piece == 1)
            {
                pos = white_piece_1.GetPos();
            }
            else if (the_piece == 2)
            {
                pos = white_piece_2.GetPos();
            }
            else if (the_piece == 3)
            {
                pos = white_piece_3.GetPos();
            }
            else if (the_piece == 4)
            {
                pos = white_piece_4.GetPos();
            }
            else if (the_piece == 5)
            {
                pos = white_piece_5.GetPos();
            }
            else if (the_piece == 6)
            {
                pos = white_piece_6.GetPos();
            }

            /*Will analyze the surroundings of the selected piece and say
            what's the movements the player can do*/

            Console.WriteLine("Doable Movements :");

            //Analyze the line in x coordinates
            for (int x = -1; x < 2; x++)
            {
                //Analyze the line in y coordinates
                for (int y = -2; y < 3; y += 2)
                {
                    /*Checks if the closest spaces to the chosen piece are
                    in the board*/
                    if ((pos[0] + x > -1) && (pos[0] + x < 5) && 
                    (pos[1] + y > -1) && (pos[1] + y < 9))
                    {
                        //Checks if the chosen pice is in the backline 
                        if ((map[pos[0] + x, pos[1] + y] == 4) && 
                        ((pos[0] == 0) || (pos[0] == 4)))
                        {
                            /*Checks if there is any enemy piece in the
                            back line*/
                            if (map[pos[0] + x, pos[1] + (y * 2)] == 2 &&
                            (pos[1] + (y * 4) > -1) && (pos[1] + (y * 4) < 9))
                            {
                                /*Checks if there is any free space after the
                                enemy, so the player can eat the enemy piece*/
                                if (map[pos[0] + x, pos[1] + (y * 4)] == 1)
                                {
                                    Console.WriteLine(
                                    $"{pos[0] + x}, {pos[1] + (y * 4)}");
                                    map[pos[0] + (x), pos[1] + (y * 2)] = 6;
                                    map[pos[0] + x, pos[1] + (y * 4)] = 7;
                                    possible_mov += 1;
                                }
                            }
                            /*Checks if there is any free space to move the
                            piece in the back line*/
                            if (map[pos[0] + x, pos[1] + (y * 2)] == 1)
                            {
                                Console.WriteLine(
                                $"{pos[0] + x}, {pos[1] + (y * 2)}");
                                map[pos[0] + x, pos[1] + (y * 2)] = 5;
                                possible_mov += 1;
                            }
                        }
                        /*Checks if its a white piece and if the surrounding
                        is in the board*/
                        else if ((map[pos[0] + x, pos[1] + y] == 2) &&
                        ((pos[0] + (x * 2) > -1) && (pos[0] + (x * 2) < 5) &&
                        (pos[1] + (y * 2) > -1) && (pos[1] + (y * 2) < 9)))
                        {
                            /*Checks if that surrounding is free so the player
                            can eat the white piece*/
                            if (map[pos[0] + (x * 2), pos[1] + (y * 2)] == 1)
                            {
                                Console.WriteLine(
                                $"{pos[0] + (x * 2)}, {pos[1] + (y * 2)}");
                                map[pos[0] + (x), pos[1] + (y)] = 6;
                                map[pos[0] + (x * 2), pos[1] + (y * 2)] = 7;
                                possible_mov += 1;
                            }
                        }
                        /*Checks if there is any free space in the rest of the
                        lines*/
                        else if (map[pos[0] + x, pos[1] + (y)] == 1)
                        {
                            Console.WriteLine($"{pos[0] + x}, {pos[1] + y}");
                            map[pos[0] + x, pos[1] + y] = 5;
                            possible_mov += 1;
                        }
                    }
                }
            }

            //Checks if the player chooses a piece with a impossible movement
            if (possible_mov == 0)
            {
                Console.Write("You can't move that one... Try another one.\n");
                return player;
            }

            else
            {
                while (answer)
                {
                    //Will demand position x and y for the movement of the piece
                    Console.Write("x = ");
                    string coordx = Console.ReadLine();
                    Console.Write("y = ");
                    string coordy = Console.ReadLine();
                    int coordxnumb = int.Parse(coordx);
                    int coordynumb = int.Parse(coordy);

                    //Check if the input is in one of the said cases
                    if ((coordxnumb > -1) && (coordxnumb < 5) &&
                    (coordynumb > -1) && (coordynumb < 9))
                    {
                        if ((map[coordxnumb, coordynumb] == 5) ||
                        (map[coordxnumb, coordynumb] == 7))
                        {

                            if (map[coordxnumb, coordynumb] == 5)
                            {
                                for(int x=0; x<5; x++)
                                {
                                    for(int y=0; y<9; y++)
                                    {
                                        if(map[x,y] == 6)
                                        {
                                            map[x,y] = 2;
                                        }
                                    }
                                }
                            }

                            /*This will put to date the position of the piece
                            in the graphic board*/

                            map[pos[0], pos[1]] = 1;
                            pos[0] = coordxnumb;
                            pos[1] = coordynumb;
                            map[coordxnumb, coordynumb] = 3;

                            /*This will put to date the position of the piece
                            itself*/

                            if (the_piece == 1)
                            {
                                white_piece_1.SetPos(pos);
                            }
                            else if (the_piece == 2)
                            {
                                white_piece_2.SetPos(pos);
                            }
                            else if (the_piece == 3)
                            {
                                white_piece_3.SetPos(pos);
                            }
                            else if (the_piece == 4)
                            {
                                white_piece_4.SetPos(pos);
                            }
                            else if (the_piece == 5)
                            {
                                white_piece_5.SetPos(pos);
                            }
                            else if (the_piece == 6)
                            {
                                white_piece_6.SetPos(pos);
                            }
                            
                            answer = false;
                            player = "B";
                        }

                        else
                        {
                            Console.Write("That's not a valid option... ");
                            Console.WriteLine("Use one of the options");
                        }

                    }

                    else
                    {
                        Console.Write("That's not a valid option... ");
                        Console.WriteLine("Use one of the options");
                    }
                }

            }

            return player;
        }

        //To draw the board
        static void Board(int [,] map, string player,
        ref Pieces black_piece_1, ref Pieces black_piece_2, 
        ref Pieces black_piece_3, ref Pieces black_piece_4, 
        ref Pieces black_piece_5, ref Pieces black_piece_6,
        ref Pieces white_piece_1, ref Pieces white_piece_2, 
        ref Pieces white_piece_3, ref Pieces white_piece_4, 
        ref Pieces white_piece_5, ref Pieces white_piece_6)
        {
            //Variable
            int [] analyze = new int [2];
            int [] pos;
            int i = 0;

            //Write the board
            for(int x=0; x<7; x++)
            {
                if(x == 0)
                {
                    Console.Write("  012345678");
                }
                if(x == 1)
                {
                    Console.Write(" ----------");
                }
                for(int y=0; y<11; y++)
                {
                    if((x == 0) || (x == 1))
                    {
                        break;
                    }
                    else if ((y == 0) && (x > 0))
                    {
                        Console.Write(i);
                        i++;
                    }
                    else if ((y == 1) && (x > 0))
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        //This is a black piece case
                        if(map[x-2,y-2] == 2)
                        {
                            Console.Write("B");
                        }

                        //This is a white piece case
                        else if(map[x-2,y-2] == 3)
                        {
                            Console.Write("W");
                        }

                        //This was a possible position for the chosen piece  
                        else if((map[x-2,y-2] == 5) || (map[x-2,y-2] == 7))
                        {
                            map[x-2,y-2] = 1;
                            Console.Write("+");
                        }
                        
                        //This is the position of a dead piece
                        else if(map[x-2,y-2] == 6)
                        {
                            map[x-2,y-2] = 1;
                            Console.Write("+");
                            analyze[0] = x;
                            analyze[1] = y;

                            //This part will "delete" the piece from the choose list
                            pos = black_piece_1.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                black_piece_1.SetAlive(false);
                            }
                            pos = black_piece_2.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                black_piece_2.SetAlive(false);
                            }
                            pos = black_piece_3.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                black_piece_3.SetAlive(false);
                            }
                            pos = black_piece_4.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                black_piece_4.SetAlive(false);
                            }
                            pos = black_piece_5.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                black_piece_5.SetAlive(false);
                            }
                            pos = black_piece_6.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                black_piece_6.SetAlive(false);
                            }
                            pos = white_piece_1.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                white_piece_1.SetAlive(false);
                            }
                            pos = white_piece_2.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                white_piece_2.SetAlive(false);
                            }
                            pos = white_piece_3.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                white_piece_3.SetAlive(false);
                            }
                            pos = white_piece_4.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                white_piece_4.SetAlive(false);
                            }
                            pos = white_piece_5.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                white_piece_5.SetAlive(false);
                            }
                            pos = white_piece_6.GetPos();
                            if((pos[0] == analyze[0]) && 
                            (pos[1] == analyze[1]))
                            {
                                white_piece_6.SetAlive(false);
                            }
                        }

                        //This is a free case
                        else if(map[x-2,y-2] == 1)
                        {
                            Console.Write("+");
                        }

                        //This is a non playable case from the board
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine("");
            }
        }
        

        static bool BlackWinVerification(ref Pieces white_piece_1,
        ref Pieces white_piece_2, ref Pieces white_piece_3,
        ref Pieces white_piece_4, ref Pieces white_piece_5,
        ref Pieces white_piece_6)
        {
            if ((white_piece_1.GetAlive()) || (white_piece_2.GetAlive()) || 
            (white_piece_3.GetAlive()) || (white_piece_4.GetAlive()) || 
            (white_piece_5.GetAlive()) || (white_piece_6.GetAlive()))
            {
                return false;
            }
            else
            {
                Console.Write("Black Wins!");
                return true;
            }
        }

        static bool WhiteWinVerification(ref Pieces black_piece_1, 
        ref Pieces black_piece_2, ref Pieces black_piece_3, 
        ref Pieces black_piece_4, ref Pieces black_piece_5, 
        ref Pieces black_piece_6)
        {
            if ((black_piece_1.GetAlive()) || (black_piece_2.GetAlive()) || 
            (black_piece_3.GetAlive()) || (black_piece_4.GetAlive()) || 
            (black_piece_5.GetAlive()) || (black_piece_6.GetAlive()))
            {
                return false;
            }
            else
            {
                Console.Write("Black Wins!");
                return true;
            }
        }
    }
}