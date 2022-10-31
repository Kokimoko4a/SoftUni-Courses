using System;

namespace _04._Обръщение_според_възраст_и_пол
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            
            /*  if (gender == "f")
              {
                  if (age<16)
                  {
                      Console.WriteLine("Miss");
                  }
                  else
                  {
                      Console.WriteLine("Ms.");
                  }

              }
              else
              {
                  if (age < 16) {
                      Console.WriteLine("Master");
                  }
                  else
                  {
                      Console.WriteLine("Mr.");
                  }*/

            switch (gender)
            {
                case "m":
                    if (age < 16)
                    {
                        Console.WriteLine("Master");
                    }
                    else {
                        Console.WriteLine("Mr.");
                         }
                    break;
                case "f":
                    if (age < 16) {
                        Console.WriteLine("Miss");
                    }
                    else {
                        Console.WriteLine("Ms.");                              
                    }
                    break;
                /*default:
                    break;*/
            }

        }
        }
    }

