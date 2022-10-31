using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model,int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public int Capacity { get; set; }
        public string Model { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Capacity>Multiprocessor.Count)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.FirstOrDefault(x => x.Brand == brand) != null)
            {
                Multiprocessor.Remove(Multiprocessor.Find(x => x.Brand == brand));
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }

        public string Report()
        {
            return $"CPUs in the Computer {Model}:{Environment.NewLine}" +
                string.Join(Environment.NewLine, Multiprocessor);
        }
    }
}
