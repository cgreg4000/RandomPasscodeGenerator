using System;

namespace RandomPasscodeGenerator.Models
{
    public class RandomPassword
    {
        public string password;

        public RandomPassword()
        {
            password = "";
            Random rand = new Random();
            string[] letters = new string[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            };
            for (int i = 0; i <= 13; i++)
            {
                int randomValue = rand.Next(0, 36);
                if (randomValue < 10)
                {
                    password += randomValue.ToString();
                }
                else
                {
                    password += letters[randomValue - 10];
                }
            }
            Console.WriteLine(password);
        }
    }
}