

namespace PopCorn
{
    using System;

    class Pan
    {
        private int panXCoord;
       
        private int maxLeftMove;
        private int maxRightMove;
        private string panSymbols;
        private readonly int panYCoord = Console.WindowHeight - 2;
        public Pan()
        {
            panXCoord = Console.WindowWidth / 2 - 7;
            maxLeftMove = 0;
            maxRightMove = Console.WindowWidth - 1;
            panSymbols = "/============\\";
            PrintPan();
        }
        public int PanXCoord
        {
            get
            {
                return this.panXCoord;
            }
            set
            {
                this.panXCoord = value;
            }
        }

        public int PanYCoord
        {
            get
            {
                return this.panYCoord;
            }
        }

        public void PrintPan()
        {
            for (int i = panXCoord, k = 0; i < panXCoord + panSymbols.Length; i++, k++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(i, panYCoord);
                Console.Write(panSymbols[k]);
                Console.ResetColor();
            }
        }
        public void MovePan()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.LeftArrow && panXCoord > maxLeftMove + 1)
                {
                    MovePanLeft(key);
                }
                if ((key.Key == ConsoleKey.RightArrow) && (panXCoord + panSymbols.Length < maxRightMove - 1))
                {
                    MovePanRight(key);
                }

            }
        }
        private void MovePanLeft(ConsoleKeyInfo key)
        {
            panXCoord--;
            Console.SetCursorPosition(panXCoord + panSymbols.Length, panYCoord);
            PrintPan();
            Console.Write(' ');

        }

        private void MovePanRight(ConsoleKeyInfo key)
        {
            panXCoord++;
            Console.SetCursorPosition(panXCoord - 1, panYCoord);
            Console.Write(' ');
            PrintPan();
        }

    }
}
