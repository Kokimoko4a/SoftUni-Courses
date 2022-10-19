using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Employees = new List<Employee>();
        }

        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public int Count { get { return Employees.Count; } }

        public void Add(Employee employee)
        {
            if (Capacity> Employees.Count)
            {
                Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (Employees.FirstOrDefault(x=>x.Name == name) != null)
            {
                Employees.Remove(Employees.Find(x => x.Name == name));
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            return Employees.OrderByDescending(x => x.Age).First();
        }

        public Employee GetEmployee(string name)
        {
            return Employees.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            return $"Employees working at Bakery {Name}:{Environment.NewLine}" +
                string.Join(Environment.NewLine, Employees);
        }
    }
}
