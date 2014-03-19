namespace PopCorn
{

    using System;

    class LivesContainer
    {
        private int lives = 3;
        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                this.lives = value;
            }
        }
        public void PrintLives()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(Console.WindowWidth - 10, 0);
            Console.Write("Lives - {0} ", lives);
            Console.ResetColor();
        }
    }
}
