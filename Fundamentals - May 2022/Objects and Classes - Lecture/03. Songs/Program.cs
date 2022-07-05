using System;
using System.Collections.Generic;

namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfSongs = int.Parse(Console.ReadLine());
            List<Songs> songs = new List<Songs>();

            for (int i = 0; i < countOfSongs ; i++)
            {
                string[] currentInfo = Console.ReadLine().Split("_");

                Songs currentSong = new Songs ();

                currentSong.TypeList = currentInfo[0];
                currentSong.Name = currentInfo[1];
                currentSong.Time = currentInfo[2];

                songs.Add(currentSong);
                
                    
            }

            string wantedType = Console.ReadLine();
            if (wantedType !="all")
            {
                foreach (var song in songs)
                {
                    if (song.TypeList  == wantedType )
                    {
                        Console.WriteLine(song .Name );
                    }
                }
            }

            else if(wantedType == "all")
            {
                foreach (var song in songs )
                {
                    Console.WriteLine(song .Name );
                }
            }


        }
    }

    class Songs
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }


    }
}
