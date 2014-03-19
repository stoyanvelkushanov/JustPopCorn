namespace PopCorn
{
    using System;
    
    class SidesPrinter
    {
        private char bottomSymbol = '^';
        private char rightLeftSymbols = '|';
        private char roofSymbols = '=';
        private int width = Console.WindowWidth-1;  
        private int height = Console.WindowHeight-1;
        public void PrintWalls()
        {
            //print bottom symbols
            for (int i = 1; i < width; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(i, height);
                Console.Write(bottomSymbol);
                Console.ResetColor();
            }
            //print left side 

            for (int i = 2; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, i);
                Console.Write(rightLeftSymbols);
                Console.ResetColor();
            }

            //print right side 
            for (int i = 2; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(width, i);
                Console.Write(rightLeftSymbols);
                Console.ResetColor();
            }

            //print roof
            for (int i = 1; i < width; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 1);
                Console.Write(roofSymbols);
                Console.ResetColor();
            }
        }
    }
}
