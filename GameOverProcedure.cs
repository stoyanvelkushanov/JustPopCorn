
namespace PopCorn
{
    using System;
    using System.Media;

    class GameOverProcedure
    {
        LivesContainer currentLives = new LivesContainer();
        Score scr = new Score();
        Game game = new Game();
        private string nick = string.Empty;
        public void GameEnd(int score,int remeiningBricks,int lives,int threadValue)
        {
            Console.Clear();
            //the is two way to finish the game 
            //first way - if our lives end
            if (lives == 0 && remeiningBricks > 0)
            {
                SoundPlayer gameOverSound = new SoundPlayer("../../Sounds/gameover.wav");
                using (gameOverSound)
                {
                    gameOverSound.Play();
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(Console.WindowWidth / 2-5 , 1);
                Console.Write("GAME OVER");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 3);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 5);
                Console.Write("You have reached the result of: {0} points", score);
                
                Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 8);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 10);
                Console.Write("Please enter your nick name: ");
                Console.ResetColor();
                
            }
                //second way - if we destroy all bricks
            else if (lives > 0 && remeiningBricks == 0)
            {
                SoundPlayer winningSound = new SoundPlayer("../../Sounds/winning.wav");
                using (winningSound)
                {
                    winningSound.Play();
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(Console.WindowWidth / 2-5, 1);
                Console.Write("GAME OVER");       
                Console.SetCursorPosition(Console.WindowWidth / 2 - 25, 3);
                Console.Write("CONGRATILATIONS!!! ALL THE BRICKS HAD DESTROYED!!!");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 5);
                Console.Write("You have reached the result of: {0} points", score);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 7);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 8);
                Console.Write("Please enter your nick name: ");
                Console.CursorVisible = true;
                Console.ResetColor();
                
            }
            //store the result in a text file
            scr.SaveScore(score);
            scr.PrintHighScore();
        }
    }
}
