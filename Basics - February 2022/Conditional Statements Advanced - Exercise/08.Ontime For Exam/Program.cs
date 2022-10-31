using System;

namespace _08.Ontime_For_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minuteOfExam = int.Parse(Console.ReadLine());
            int hourOfArriving = int.Parse(Console.ReadLine());
            int minuteOfArriving = int.Parse(Console.ReadLine());

            int examTime = hourOfExam * 60 + minuteOfExam;
            int arrivalTime = hourOfArriving * 60 + minuteOfArriving;

            if (examTime  < arrivalTime)
            {
                if (arrivalTime - examTime >=60)
                {
                    int hh = (arrivalTime - examTime) / 60;
                        int mm = (arrivalTime - examTime) % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{hh}:{mm:d2} hours after the start");
                }

                else if (arrivalTime - examTime <60)
                {
                    int mm = (arrivalTime - examTime) % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{mm} minutes after the start");
                }
            }

            else if (examTime -arrivalTime>=0 && examTime - arrivalTime<=30)
            {
                if (examTime - arrivalTime >0)
                {
                    int mm = (examTime  - arrivalTime) % 60;
                    Console.WriteLine("On time");
                    Console.WriteLine($"{mm} minutes before the start");

                }
                else
                {
                    Console.WriteLine("On time");
                }
            }

            else if (examTime - arrivalTime >30)
            {
                if (examTime - arrivalTime >= 60)
                {
                    int mm = (examTime - arrivalTime) % 60;
                    int hh =  (examTime - arrivalTime) / 60;
                    Console.WriteLine("Early");
                    Console.WriteLine($"{hh}:{mm:d2} hours before the start");
                }

                else
                {                   
                    int mm = (examTime - arrivalTime) % 60;
                    Console.WriteLine("Early");
                    Console.WriteLine($"{mm} minutes before the start");
                }
            }
        }
    }
}
