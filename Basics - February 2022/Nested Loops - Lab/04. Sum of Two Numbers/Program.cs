using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
        {  
            {
                int startNum = int.Parse(Console.ReadLine());
                int endNum = int.Parse(Console.ReadLine());
                int magicNum = int.Parse(Console.ReadLine());
                int combination = 0;

                bool isMagicFound = false;

                for (int firstNum = startNum; firstNum <= endNum; firstNum++)
                {
                    for (int secNum = startNum; secNum <= endNum; secNum++)
                    {
                        combination++;

                        if (firstNum + secNum == magicNum)
                        {
                            isMagicFound = true;
                            Console.WriteLine($"Combination N:{combination} ({firstNum} + {secNum} = {firstNum + secNum})");
                                return; 
                        }

                            
                    }
                        
               }

                    if (!isMagicFound)
                    {
                        Console.WriteLine($"{combination} combinations - neither equals {magicNum}");
                    }
            }
        }
    }

}
    }

