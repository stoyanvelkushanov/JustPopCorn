namespace PopCorn
{

    using System;
    using System.Linq;

    class Ball
    {
        private bool hitRightBorder;
        public bool HitRightBorder
        {
            set { hitRightBorder = value; }
        }
        private bool hitLeftBorder;
        public bool HitLeftBorder
        {
            set { hitLeftBorder = value; }
        }
        private bool hitUpBorder;
        public bool HitUpBorder
        {
            set { hitUpBorder = value; }
        }
        private int ballY;
        private int ballX;
        private char ballSymbol;
        private readonly int upBorder = 2;
        private readonly int downBorder = Console.BufferHeight - 3;
        private readonly int leftBorder = 1;
        private readonly int rightBorder = Console.BufferWidth - 2;
        private string direction;
        public Ball()
        {
            hitUpBorder = false;
            hitRightBorder = false;
            hitLeftBorder = false;
            ballY = Console.BufferHeight - 3;
            ballX = Console.BufferWidth / 2;
            ballSymbol = 'O';
            direction = "upright";
        }
        public int BallX
        {
            get
            {
                return this.ballX;
            }
            set
            {
                this.ballX = value;
            }
        }
        public int BallY
        {
            get
            {
                return this.ballY;
            }
            set
            {
                this.ballY = value;
            }
        }
        public string Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }

        public void MoveBall()
        {
            Console.SetCursorPosition(ballX, ballY);
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            if (String.Equals("upright", direction))
            {
                MoveUpright();
            }
            if (String.Equals(direction, "downright"))
            {
                MoveDownRight();
            }
            if (String.Equals(direction, "downleft"))
            {
                MoveDownLeft();
            }
            if (String.Equals(direction, "upleft"))
            {
                MoveUpLeft();
            }
            if (String.Equals(direction, "straightup"))
            {
                MoveStraightUp();
            }
            if (String.Equals(direction, "straightdown"))
            {
                MoveStraightDown();
            }
        }

        private void MoveUpLeft()
        {
            if (ballX > leftBorder && ballY > upBorder)
            {
                ballX--;
                ballY--;
                PrintBall();
            }
            else
            {
                if (ballY == upBorder)
                {
                    direction = "downleft";
                    hitUpBorder = true;
                }
                if (ballX == leftBorder)
                {
                    hitLeftBorder = true;
                    direction = "upright";
                }
            }
        }

        private void MoveDownLeft()
        {
            if (ballX > leftBorder && ballY < downBorder)
            {
                ballX--;
                ballY++;
                PrintBall();
            }
            else
            {
                if (ballY == downBorder)
                {
                    direction = "upleft";
                }
                if (ballX == leftBorder)
                {
                    direction = "downright";
                }
            }
        }



        private void MoveDownRight()
        {
            if (ballX < rightBorder && ballY < downBorder)
            {
                ballX++;
                ballY++;
                PrintBall();
            }
            else
            {
                if (ballX == rightBorder)
                {
                    direction = "downleft";
                    hitRightBorder = true;
                }
                if (ballY == downBorder)
                {
                    direction = "upright";
                }
            }
        }

        private void MoveUpright()
        {
            if (ballX < rightBorder && ballY > upBorder)
            {
                ballX++;
                ballY--;
                PrintBall();
            }
            else
            {
                if (ballY == upBorder)
                {
                    direction = "downright";
                    hitUpBorder = true;
                }
                if (ballX == rightBorder)
                {
                    hitRightBorder = true;
                    direction = "upleft";
                }

            }
        }
        private void MoveStraightUp()
        {
            if (ballY > upBorder)
            {
                ballY--;
                PrintBall();
            }
            else
            {
                if (ballY == upBorder)
                {
                    direction = "downright";
                    hitUpBorder = true;
                }
            }
        }
        private void MoveStraightDown()
        {
            if (ballY < downBorder)
            {
                ballY++;
                PrintBall();
            }
            else
            {
                if (ballY == downBorder)
                {
                    direction = "straightup";
                }
            }
        }
        public void CollisionMoveBall()
        {
                if (direction.Equals("upleft"))
                {
                    if (hitRightBorder == true)
                    {
                        direction = "upright";
                        hitRightBorder = false;
                    }
                    else
                    {
                        direction = "downright";
                    }
                }
                else if (direction.Equals("upright"))
                {
                    if (hitLeftBorder == true)
                    {
                        direction = "uprleft";
                        hitLeftBorder = false;
                    }
                    else
                    {
                        direction = "downright";
                    }
                }
                else if (direction.Equals("downright"))
                {
                    
                   if (hitUpBorder == true)
                    {
                        direction = "upright";
                    }
                   else if (hitLeftBorder == true)
                   {
                       direction = "downleft";
                       hitLeftBorder = false;
                   }
                    else
                     direction = "upleft";
                }
                else if (direction.Equals("downleft"))
                {
                    if (hitUpBorder == true)
                    {
                        direction = "upleft";
                        hitUpBorder = false;
                        
                    }
                    else if (hitRightBorder == true)
                    {
                        direction = "downright";
                        hitRightBorder = false;
                    }
                    else
                    direction = "upright";
                }
                else if (direction.Equals("straightup"))
                {
                    direction = "straightdown";
                }
                else if (direction.Equals("straightdown"))
                {
                    direction = "straightup";
                }

        }
        public void CollisionSidesPanMove(string side)
        {
            if (direction.Equals("downright"))
            {
                direction = "upright";
            }
            else if (direction.Equals("downleft"))
            {
                direction = "upleft";
            }
            else if (direction.Equals("straightdown"))
            {
                if (side.Equals("left"))
                {
                    direction = "upleft";
                }
                else
                {
                    direction = "upright";
                }
            }
        }
        public void PrintBall()
        {
            try
            {
                Console.SetCursorPosition(ballX, ballY);
                Console.WriteLine(ballSymbol);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }
    }
}
