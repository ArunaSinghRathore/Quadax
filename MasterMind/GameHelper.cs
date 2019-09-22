using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public static class GameHelper
    {
        public static string ObtainValidatedInput(int maxTurns, int turn)
        {
            string input = Console.ReadLine();
            if (!ValidateInput(input)) { Console.WriteLine("Please provide input in form of 4 numbers only."); input = Console.ReadLine(); };
            return input;
        }

        public static bool CheckForWin(string input, string code)
        {
            if (input==code)
            {
                return true;
            }
            return false;
        }

        

        private static bool ValidateInput(string input)
        {
            int number;
            return input.Length == 4 && int.TryParse(input, out number);
        }

        public static void WriteToConsole(string key, string formatString = "")
        {           
            Console.WriteLine(String.Format(ConfigurationSettings.AppSettings[key], formatString));
            Console.WriteLine();
        }
    }
}
