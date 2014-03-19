
namespace PopCorn
{
    using System;
    using System.Linq;

    class Menu
    {
        Game game = new Game();
        Score score = new Score();
        private int ArrowXCoord = Console.WindowWidth / 2-8;
        private int ArrowYCoord = 5;
        private int maxYCoord = 8;
        private int minYCoord = 5;
        private string arrow = "==>";
        private int currentArrow = 1;
        public void PrintMenu()
        {
            
            //HappyFace();
            PrintArrow();
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Console.WindowWidth / 2-12, 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("JUST POPCORN GAME 2013");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 5);
            Console.Write("New Game");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 6);
            Console.Write("High Score");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 7);
            Console.Write("Help");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 8);
            Console.Write("Exit");
            Console.ResetColor();
            MoveArrow();
            
        }
        private void MoveArrow()
        {
            
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();   
                
                if (key.Key == ConsoleKey.UpArrow && ArrowYCoord > minYCoord)
                {
                    currentArrow--;
                    MoveArrowUp();
                    Console.SetCursorPosition(0, 0);
                }
                if (key.Key == ConsoleKey.DownArrow && ArrowYCoord < maxYCoord)
                {

                    MoveArrowDown();
                    currentArrow++;
                    Console.SetCursorPosition(0, 0);
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    
                    Console.Beep(440, 150);
                    int commands = ArrowYCoord;
                    switch (commands)
                    {
                        case 5: Console.Clear(); PrintDifficultyMenu(); break;
                        case 6: Console.Clear(); score.PrintHighScore(); break;
                        case 7: Console.Clear(); Help(); break;
                        case 8: Environment.Exit(0); break;
                        default:
                            break;
                    }
                }
                
            }
        }
        private void PrintDifficultyMenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choose difficulty");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 5);
            Console.Write("EASY");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 6);
            Console.Write("MEDIUM");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 7);
            Console.Write("HARD");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 8);
            Console.Write("INSANE");
            Console.ResetColor();
            MoveDifficultyArrow();
        }
        private int MoveDifficultyArrow()
        {
            int threadValue;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && ArrowYCoord > minYCoord)
                {
                    currentArrow--;
                    MoveArrowUp();
                    Console.SetCursorPosition(0, 0);
                }
                if (key.Key == ConsoleKey.DownArrow && ArrowYCoord < maxYCoord)
                {

                    MoveArrowDown();
                    currentArrow++;
                    Console.SetCursorPosition(0, 0);
                }
                if (key.Key == ConsoleKey.Enter)
                {

                    Console.Beep(440, 150);
                    int commands = ArrowYCoord;
                    switch (commands)
                    {
                        case 5: Console.Clear(); threadValue = 90; game.Engine(threadValue); break;
                        case 6: Console.Clear(); threadValue = 70; game.Engine(threadValue); break;
                        case 7: Console.Clear(); threadValue = 50; game.Engine(threadValue); break;
                        case 8: Console.Clear(); threadValue = 40; game.Engine(threadValue); break;
                        default:
                            break;
                    }
                }

            }
        }
        private void Help()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2-10, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("HELLO POP CORN PLAYER");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 23, 3);
            Console.Write("Follow the simple instructions and play the game!");
            Console.SetCursorPosition(7 , 5);
            Console.Write("1 - use left arrow for move the pan in left direction   ---- <-");
            Console.SetCursorPosition(7, 6);
            Console.Write("2 - use right arrow for move the pan in right direction ---- ->");
            Console.SetCursorPosition(7, 7);
            Console.Write("3 - On the top left corner you can see your current points");
            Console.SetCursorPosition(7, 8);
            Console.Write("4 - On the top right corner you can see your lives");
            Console.SetCursorPosition(7, 9);
            Console.Write("5 - The ball is move on the field you must try to catch it with the pan");
            Console.SetCursorPosition(7, 10);
            Console.Write("6 - If the ball hit a brick you will gain 10 points");
            Console.SetCursorPosition(7, 11);
            Console.Write("7 - Some bricks gives 100 bonus points");
            Console.SetCursorPosition(7, 12);
            Console.Write("8 - If you miss to catch the ball your lives decrease");
            Console.SetCursorPosition(7, 13);
            Console.Write("9 - if you run out of lives your Game Is Over!!!");
            Console.SetCursorPosition(6, 14);
            Console.Write("10 - Destroy all bricks on the field and win the GAME!");
            Console.SetCursorPosition(28, 18);
            Console.Write("MIGHTY MOUSE WISH YOU A NICE GAME :)");
            Console.SetCursorPosition(26, 22);

            Console.Write("Press enter to go back in the menu");
            ConsoleKeyInfo key = Console.ReadKey();
            Menu menu = new Menu();
            Console.ResetColor();
            if (key.Key == ConsoleKey.Enter)
            {
                
                Console.Clear();
                menu.PrintMenu();
            }


        }
        

        private void PrintArrow()
        {
            for (int i = ArrowXCoord; i < arrow.Length+ArrowXCoord; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(i, ArrowYCoord);
                Console.Write(arrow[i-ArrowXCoord]);
                Console.ResetColor();
            }
        }
        private void MoveArrowDown()
        {
            Console.Beep(320,150);
            ArrowYCoord++;
            Console.SetCursorPosition(ArrowXCoord, ArrowYCoord);
            PrintArrow();
            Console.SetCursorPosition(ArrowXCoord, ArrowYCoord-1);
            Console.Write(' ');
            Console.SetCursorPosition(ArrowXCoord+1, ArrowYCoord-1);
            Console.Write(' ');
            Console.SetCursorPosition(ArrowXCoord + 2, ArrowYCoord-1);
            Console.Write(' ');     
        }
        private void MoveArrowUp()
        {
            Console.Beep(320, 150);
            ArrowYCoord--;
            Console.SetCursorPosition(ArrowXCoord, ArrowYCoord);
            PrintArrow();
            Console.SetCursorPosition(ArrowXCoord, ArrowYCoord + 1);
            Console.Write(' ');
            Console.SetCursorPosition(ArrowXCoord + 1, ArrowYCoord+1);
            Console.Write(' ');
            Console.SetCursorPosition(ArrowXCoord + 2, ArrowYCoord+1);
            Console.Write(' ');
        }
        
            private void HappyFace()
            {
                
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(". .");
                Console.WriteLine(" ) ");
                Console.WriteLine("###");
                for (int i = 0; i < 38; i++)
                {
                    
                    Console.MoveBufferArea(i, i, 3, 3, i + 1, i + 1);
                    Console.Beep((i + 10) * 100, 100);
                }
                Console.SetCursorPosition(0, 23);
                Console.ResetColor();
            }

            
    }
}
