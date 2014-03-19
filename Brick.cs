

namespace PopCorn
{
    using System;

    class Brick
    {
        private char brickSymbol = '#';
        public int brickXCoord = 10;
        public int brickYCoord = 3;
        public int brickCounter = 0;
        public int BrickCounter
        {
            get { return this.brickCounter; }
            set { this.brickCounter = value; }
        }
        static private Random randomGenerator = new Random();
        private bool hasBonusPoints = SetBonusPoints();
        public bool HasBonusPoints
        {
            get
            {
                return this.hasBonusPoints;
            }
        }
        public void PrintBrick()
        {
            int colorNumber = randomGenerator.Next(1, 15);
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            Console.SetCursorPosition(this.brickXCoord, this.brickYCoord);
            Console.Write(brickSymbol);
            Console.ResetColor();
        }
        public static bool SetBonusPoints()
        {
            int randomValue = randomGenerator.Next(1, 10);
            if (randomValue > 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

