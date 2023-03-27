using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //  string input = File.ReadAllText(@"../../../Datasets/cars.json");

            string result = GetTotalSalesByCustomer(context);

            Console.WriteLine(result);
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var supliersDto = JsonConvert.DeserializeObject<SuplierDto[]>(inputJson);

            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));

            Supplier[] validSups = mapper.Map<Supplier[]>(supliersDto);

            context.Suppliers.AddRange(validSups);
            context.SaveChanges();

            return $"Successfully imported {validSups.Length}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partsDto = JsonConvert.DeserializeObject<PartDto[]>(inputJson);

            Mapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));
            List<Part> validParts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                if (context.Suppliers.Any(x => x.Id == partDto.SupplierId))
                {
                    Part validPart = mapper.Map<Part>(partDto);
                    validParts.Add(validPart);
                }
            }


            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }


        //Problem 11 
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<CarDto[]>(inputJson);

            Mapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));

            List<Car> validCars = new List<Car>();


            foreach (var carDto in carsDto)
            {
                Car validCar = mapper.Map<Car>(carDto);

                foreach (var part in carDto.PartsId.Distinct())
                {
                    validCar.PartsCars.Add(new PartCar { PartId = part, CarId = validCar.Id });
                }

                validCars.Add(validCar);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }



        //Problem 12 
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<CustomerDto[]>(inputJson);

            Mapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));

            Customer[] validCustomers = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Length}.";

        }


        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDto = JsonConvert.DeserializeObject<SalesDto[]>(inputJson);

            Mapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));

            Sale[] validSales = mapper.Map<Sale[]>(salesDto);
            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Length}.";
        }


        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var experiencedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(experiencedCustomers, Formatting.Indented);

        }


        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);

        }


        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localCuppliers = context.Suppliers.Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(localCuppliers, Formatting.Indented);
        }


        //Problem 17 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(c => new
            {
                car = new
                {

                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                },
                parts = c.PartsCars.Select(p => new
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price.ToString("f2")
                }).ToList()

            }).ToList();




            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }


        //Problem 18 - 50/100
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers.Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }


        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },

                customerName = s.Customer.Name,
                discount = s.Discount.ToString("f2"),
                price = s.Car.PartsCars.Sum(x => x.Part.Price).ToString("f2"),
                priceWithDiscount = (s.Car.PartsCars.Sum(x => x.Part.Price) - s.Discount / 100 * s.Car.PartsCars.Sum(x => x.Part.Price)).ToString("f2")
            })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

    }
}