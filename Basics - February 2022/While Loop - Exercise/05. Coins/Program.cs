using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            var mount = double.Parse(Console.ReadLine());
            int lv = (int)mount;
            int br = 0;
            double stotinki = (mount - lv)*100;

            do
            {
                if (lv >= 2)
                {
                    lv -= 2;
                    br++;
                }

                else
                {
                    lv -= 1;
                    br++;
                }

            } while (lv >= 1);

            do
            {
                if (stotinki >=50)
                {
                    stotinki  -= 50;
                    br++;
                }

                else if(stotinki >=20 )
                {
                    stotinki  -= 20;
                    br++;
                }

                else if (stotinki >=10)
                {
                    stotinki -= 10;
                    br++;
                }

                else if (stotinki >=5)
                {
                    stotinki -= 5;
                        br++;
                }

                else if (stotinki >=2)
                {
                    stotinki -= 2;
                    br++;
                }
                
            } while (lv>=1);
            Console.WriteLine(br );
        }


        
    }
}
