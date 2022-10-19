using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public int Capacity { get; set; }
        public string Type { get; set; }
        public List<Car> Cars { get; set; }
        public int Count { get { return Cars.Count; } }

        public void Add(Car car)
        {
            if (Capacity > Cars.Count)
            {
                Cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (Cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model) != null)
            {
                Cars.Remove(Cars.Find(x => x.Manufacturer == manufacturer && x.Model == model));
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            return Cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return Cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            return $"The cars are parked in {Type}:{Environment.NewLine}" +
                string.Join(Environment.NewLine, Cars);

        }
    }
}
