using System;

namespace _06._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int upBorderFirst = int.Parse(Console.ReadLine());
            int upBorderSecond = int.Parse(Console.ReadLine());
            int upBorderThird = int.Parse(Console.ReadLine());
            

            for (int firstDig = 1; firstDig <= upBorderFirst; firstDig++)
            {
                if (firstDig % 2 == 0)
                {
                    Console.WriteLine(firstDig);
                    


                    for (int i = 2; i <= upBorderSecond; i++)
                    {

                        int number = 2;

                        if (i % number == 0)
                        {
                            Console.WriteLine(i);
                            number++;

                            for (int thirdDig = 1; thirdDig <= upBorderThird; thirdDig++)
                            {

                                if (thirdDig % 2 == 0)
                                {
                                    Console.WriteLine(thirdDig);
                                 
                                }


                            }

                        }

                    }






                   /* for (int thirdDig = 1; thirdDig <= upBorderThird; thirdDig++)
                    {

                        if (thirdDig % 2 == 0)
                        {
                            Console.WriteLine(thirdDig);
                            flag3 = true;
                        }


                    }*/
                }
            }  
        }

    }
}

    

