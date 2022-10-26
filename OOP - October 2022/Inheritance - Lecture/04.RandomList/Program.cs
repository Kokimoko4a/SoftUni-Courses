using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList();
            strings.Add("d");
            Console.WriteLine(strings.RandomString());
        }
    }
}
