using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDig = 1; secondDig <=9; secondDig++)
                {
                    for (int thirdDig = 1; thirdDig <= 9; thirdDig++)
                    {
                        for (int fourthD = 1; fourthD <= 9; fourthD++)
                        {
                            bool isSpecial = n % firstDigit == 0 && n % secondDig == 0 && n % thirdDig  == 0 && n % fourthD == 0; 
                            if (isSpecial)
                            {
                                Console.Write($"{firstDigit}{secondDig}{thirdDig}{fourthD} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
