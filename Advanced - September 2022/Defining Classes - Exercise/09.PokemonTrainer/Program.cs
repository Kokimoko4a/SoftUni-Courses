using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Trainer> trainersInfo = new List<Trainer>();


            while (command != "Tournament")
            {
                string[] tokens = command.Split();
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                Pokemon pokemon = new Pokemon();
                pokemon.Name = tokens[1];
                pokemon.Element = tokens[2];
                pokemon.Health = int.Parse(tokens[3]);


                if (trainersInfo.Any(x => x.Name == tokens[0]))
                {
                    var currTrainer = trainersInfo.Find(x => x.Name == tokens[0]);
                    currTrainer.Pokemons.Add(pokemon);
                }

                else 
                {
                    Trainer trainer = new Trainer();
                    trainer.Name = tokens[0];

                    trainer.Pokemons.Add(pokemon);
                    trainersInfo.Add(trainer);
                }
             
                command = Console.ReadLine();

            }

            command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var item in trainersInfo)
                {
                    if (item.Pokemons.Any(x=>x.Element == command))
                    {
                        item.NumberOfBadges++;
                    }

                    else
                    {
                        for (int i = 0; i < item.Pokemons.Count; i++)
                        {
                            item.Pokemons[i].Health -= 10;

                            if (item.Pokemons[i].Health<=0)
                            {
                                item.Pokemons.Remove(item.Pokemons[i]);
                                i--;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            trainersInfo = trainersInfo.OrderByDescending(x=>x.NumberOfBadges).ToList();
            foreach (var item in trainersInfo)
            {
                Console.WriteLine($"{item.Name} {item.NumberOfBadges} {item.Pokemons.Count}");
            }
        }
    }
}
