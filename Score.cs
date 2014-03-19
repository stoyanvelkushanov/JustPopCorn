
namespace PopCorn
{

    using System;
    using System.Collections.Generic;
    using System.IO;

    class Score
    {
        private int currentScore = 0;
        public int CurrentScore
        {
            get
            {
                return currentScore;
            }
            set
            {
                this.currentScore = value;
            }
        }
        public void PrintScore()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("Score:{0}", currentScore);
        }
        public void SaveScore(int score)
        {

            List<string> tempList = new List<string> { };
            string nick = Console.ReadLine();
            int index = 0;
            if (!System.IO.File.Exists("score.txt"))
            {
                var scoreFile = System.IO.File.Create("score.txt");
                scoreFile.Close();
            }

            StreamReader reader = new StreamReader("score.txt");
            using (reader)
            {
                for (string line; (line = reader.ReadLine()) != null; )
                {
                    tempList.Add(line);
                    index++;
                }
            }


            StreamWriter writer = new StreamWriter("score.txt");
            tempList.Add(nick + "  -  " + score);
            using (writer)
            {
                while (tempList[index] != null)
                {
                    writer.WriteLine(tempList[index]);
                    tempList.RemoveAt(index);
                    index--;
                    if (index < 0)
                    {
                        break;
                    }
                }

            }

        }
        public void PrintHighScore()
        {
            Console.Clear();
            try
            {
                StreamReader reader = new StreamReader("score.txt");
                List<string> list = new List<string> { };
                using (reader)
                {
                    for (string line; (line = reader.ReadLine()) != null; )
                    {
                        list.Add(line);
                    }
                }
                int biggestScore = 0;
                int Score = 0;
                int maxScorePosition = 0;
                List<string> sortedList = new List<string>();
                while (list.Count > 0)
                {
                    for (int k = 0; k < list.Count; k++)
                    {
                        Score = ParseString(list[k]);
                        if (Score >= biggestScore)
                        {
                            biggestScore = Score;
                            maxScorePosition = k;
                        }
                    }
                    sortedList.Add(list[maxScorePosition]);
                    list.RemoveAt(maxScorePosition);
                    biggestScore = 0;
                }
                if (sortedList.Count == 0)
                {
                    throw new Exception();
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("PLAYERS SCORE");
                int i;
                for (i = 0; i < sortedList.Count; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 8, i + 5);
                    Console.WriteLine("{0}. {1}", i + 1, sortedList[i].ToUpper());
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 14, i + 8);
                Console.Write("Press enter to back in the menu");
                Console.ResetColor();
                ConsoleKeyInfo key = Console.ReadKey();
                Menu menu = new Menu();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    menu.PrintMenu();
                }
            }
            catch (Exception ex)
            {
                Console.Write("THE LIST IS EMPTY");
            }
        }
        private bool ValidateChar(char ch)
        {
            bool isDigit = false;
            if (char.IsDigit(ch))
            {
                return isDigit = true;
            }
            else
            {
                return isDigit;
            }
        }
        private int ParseString(string input)
        {
            string currentNumber = string.Empty;
            List<string> numbers = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (ValidateChar(input[i]))
                {
                    currentNumber += input[i].ToString();
                }

            }
            return int.Parse(currentNumber);

        }
    }
}
