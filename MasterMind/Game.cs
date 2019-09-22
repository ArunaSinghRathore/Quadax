using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class Game
    {

        public bool IsOver { get; set; }
        private static int turn;
        private static int maxTurns = 9;
        private static string code;
        public bool MatchWon { get; set; }
        public void Start()
        {
            IsOver = false;
            GenerateCode();
        }
        public void ExecuteTurn()
        {
            if (turn <= maxTurns)
            {
                var input = GameHelper.ObtainValidatedInput(maxTurns, turn);
                CompareInput(input, code);
                if (!MatchWon)
                {
                    PromptUserToPressKey();
                    turn += 1;
                }
                else
                {
                    IsOver = true;
                }
            }
            else
            {
                IsOver = true;
            }
        }
        public void End()
        {
            if (!MatchWon)
            {
                GameHelper.WriteToConsole("LosingMessage",code);
            }
            else
            {
                GameHelper.WriteToConsole("WinningMessage");
            }
            Console.ReadLine();
        }

        private void CompareInput(string input, string code)
        {
            string perfectMatch = string.Empty;
            string match = string.Empty;
            char currInput = input[0];
            for (int i = 0; i < input.Length; i += 1)
            {
                if (input[i] == code[i])
                {
                    perfectMatch += input[i];
                }
            }
            string repeated = input[0].ToString();
            for (int i = 0; i < input.Length; i += 1)
            {
                if (!perfectMatch.Contains(input[i]) && (input[i] == code[0] || input[i] == code[1] || input[i] == code[2] || input[i] == code[3]))
                {
                    if (!match.Contains(repeated))
                    {
                        match += input[i];
                    }
                }

            }
            if (perfectMatch.Length == 4)
            {
                MatchWon = true;
            }
            else
            {
                for (int i = 0; i < perfectMatch.Length; i++)
                {
                    Console.Write("+");
                }
                for (int i = 0; i < match.Length; i++)
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
        }

        private void PromptUserToPressKey()
        {
            if (turn < maxTurns)
            {
                string strNumberOfTurns = (maxTurns - turn).ToString();
                GameHelper.WriteToConsole("TryAgainMessage", strNumberOfTurns);
            }
        }

        private void GenerateCode()
        {
            Random random = new Random();
            code = random.Next(1, 6).ToString() + random.Next(1, 6).ToString() + random.Next(1, 6).ToString() + random.Next(1, 6).ToString();
            GameHelper.WriteToConsole("StartUpMessage");
            Console.WriteLine(code);
        }
    }
}
