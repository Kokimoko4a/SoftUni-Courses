using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        { //tabs count
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i++)
            {
                string currTabWedSite = Console.ReadLine();
                if (currTabWedSite == "Facebook")
                {
                    salary -= 150;
                }

                else if (currTabWedSite == "Instagram")
                {
                    salary -= 100;
                }

                else if (currTabWedSite == "Reddit")
                {
                    salary -= 50;
                }

                if (salary<=0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;//с това прекратяваш програмата
                }
            }

            Console.WriteLine(salary);



        }
    }
}
