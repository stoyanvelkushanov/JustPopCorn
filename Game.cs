

namespace PopCorn
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Media;

    class Game
    {
        static Score currentGameScore = new Score();
        static SoundPlayer player = new SoundPlayer("../../Sounds/Utopia Critical Stop.WAV");
        static Brick br = new Brick();
        static void Main()
        {
            
            Menu menu = new Menu();
            menu.PrintMenu();
            
        }

        public void Engine(int threadValue)
        {
            //SoundPlayer failSound = new SoundPlayer("../../Sounds/fail.wav");
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Brick currentBrick = new Brick();
            Console.CursorVisible = false;
            currentGameScore.CurrentScore = 0;
            Ball ball = new Ball();
            LivesContainer lives = new LivesContainer();
            SidesPrinter sides = new SidesPrinter();
            Pan pan = new Pan();
            GameOverProcedure gameOver = new GameOverProcedure();
            int startYPos = currentBrick.brickYCoord;
            Brick[,] bricks = new Brick[Console.WindowWidth, Console.WindowHeight];
            bricks = SetInitialBricksCoordinates(currentBrick, startYPos, bricks);
            
            lives.PrintLives();
            sides.PrintWalls();
            ball.MoveBall();
            while (true)
            {
                currentBrick.brickCounter = CheckCollision(bricks, ball, currentBrick.brickCounter);
                if (PanCollide(ball, pan) == false)
                {
                    if (lives.Lives > 0)
                    {
                        if (lives.Lives > 1)
                        {
                            //using (failSound)
                            //{
                            //    failSound.Play();
                            //}
                        }
                        ball = StartNewBall(ball, lives, pan);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    pan.MovePan();
                    ball.MoveBall();
                }
                Thread.Sleep(threadValue);
                currentGameScore.PrintScore();
                if (lives.Lives == 0 && currentBrick.brickCounter > 0)
                {
                    gameOver.GameEnd(currentGameScore.CurrentScore,currentBrick.brickCounter,lives.Lives,threadValue);
                }
                else if (lives.Lives > 0 && currentBrick.brickCounter == 0)
                {
                    gameOver.GameEnd(currentGameScore.CurrentScore, currentBrick.brickCounter,lives.Lives,threadValue);
                }
            }
            
        }

        private static Ball StartNewBall(Ball ball, LivesContainer lives, Pan pan)
        {
            Console.SetCursorPosition(ball.BallX, ball.BallY);
            Console.Write(" ");
            ball = new Ball();
            ball.MoveBall();
            lives.Lives--;
            lives.PrintLives();
            Console.SetCursorPosition(pan.PanXCoord, pan.PanYCoord);
            Console.Write("              ");
            pan.PanXCoord = Console.WindowWidth / 2 - 7;
            pan.PrintPan();
            return ball;
        }

        private static Brick[,] SetInitialBricksCoordinates(Brick currentBrick, int startYPos, Brick[,] bricks)
        {   
            for (int i = 10; i < 70; i++)
            {
                for (int j = 3; j < 8; j++)
                {
                    Brick newBrick = new Brick();
                    newBrick.brickXCoord = currentBrick.brickXCoord;
                    newBrick.brickYCoord = currentBrick.brickYCoord;
                    bricks[currentBrick.brickXCoord, currentBrick.brickYCoord] = newBrick;
                    currentBrick.PrintBrick();
                    currentBrick.brickCounter++;
                    currentBrick.brickYCoord++;
                }
                currentBrick.brickYCoord = startYPos;
                currentBrick.brickXCoord++;
            }
            return bricks;
        }
        private static void RemoveBrick(Brick hitBrick)
        {
            Console.SetCursorPosition(hitBrick.brickXCoord, hitBrick.brickYCoord);
            Console.Write(" ");
        }
        private static int CheckCollision(Brick[,] bricks, Ball ball,int brickCounter)
        {
            for (int i = 10; i < 70; i++)
            {
                for (int j = 3; j < 8; j++)
                {
                    if (bricks[i, j] != null)
                    {
                        if (ball.BallX == i && ball.BallY == j)
                        {
                            //using (player)
                            //{
                            //    player.Play();
                            //}
                            if (bricks[i, j].HasBonusPoints == true)
                            {
                                AddBonus();
                                brickCounter--; 
                            }
                            else
                            {
                                AddRegularPoints();
                                Console.Write("          ");
                                brickCounter--;
                            }
                            ball.CollisionMoveBall();
                            RemoveBrick(bricks[i, j]);
                            bricks[i, j] = null;
                            
                        }
                    }
                }
            }
            return brickCounter;
        }

        private static void AddRegularPoints()
        {
            currentGameScore.CurrentScore += 10;
            Console.SetCursorPosition(10, 0);
        }

        private static void AddBonus()
        {
            currentGameScore.CurrentScore += 100;
            Console.SetCursorPosition(10, 0);
            Console.Write("+100 Bonus");
        }

        private static bool PanCollide(Ball ball, Pan pan)
        {
            if ((ball.BallY + 1) == pan.PanYCoord)
            {
                if (ball.BallX == pan.PanXCoord)
                {
                    ball.Direction = "upleft";
                    ResetBallBools(ball);
                    return true;
                }
                else if ((ball.BallX > pan.PanXCoord + 1 && ball.BallX <= pan.PanXCoord + 6))
                {
                    ball.CollisionSidesPanMove("left");
                    ResetBallBools(ball);
                    return true;
                }
                else if ((ball.BallX > pan.PanXCoord + 6 && ball.BallX <= pan.PanXCoord + 8))
                {
                    ball.Direction = "straightup";
                    ResetBallBools(ball);
                    return true;
                }
                else if ((ball.BallX > pan.PanXCoord + 8 && ball.BallX <= pan.PanXCoord + 13))
                {
                    ball.CollisionSidesPanMove("right");
                    ResetBallBools(ball);
                    return true;
                }
                else if (ball.BallX == pan.PanXCoord + 14)
                {
                    ball.Direction = "upright";
                    ResetBallBools(ball);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static void ResetBallBools(Ball ball)
        {
            ball.HitLeftBorder = false;
            ball.HitRightBorder = false;
            ball.HitUpBorder = false;
        }

    }
}
