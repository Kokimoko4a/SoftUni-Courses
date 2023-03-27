using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Resource;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            //  string input = File.ReadAllText("../../../Datasets/sales.xml");
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportDto[]), root);
            StringReader stringReader = new StringReader(inputXml);

            SupplierImportDto[] supplierImportDtos = (SupplierImportDto[])xmlSerializer.Deserialize(stringReader);
            int count = 0;

            foreach (var supplierDto in supplierImportDtos)
            {
                Supplier validSupplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };

                count++;

                context.Suppliers.Add(validSupplier);
            }

            context.SaveChanges();
            return $"Successfully imported {count}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartDtoImport[]), root);
            StringReader stringReader = new StringReader(inputXml);

            PartDtoImport[] oartsDto = (PartDtoImport[])xmlSerializer.Deserialize(stringReader);
            int count = 0;

            foreach (var partDto in oartsDto)
            {
                if (context.Suppliers.Any(x => x.Id == partDto.SupplierId))
                {
                    Part validPart = new Part()
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = partDto.SupplierId
                    };

                    count++;

                    context.Parts.Add(validPart);
                }


            }

            context.SaveChanges();
            return $"Successfully imported {count}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarImportDto[]), root);
            StringReader stringReader = new StringReader(inputXml);

            CarImportDto[] carsDto = (CarImportDto[])xmlSerializer.Deserialize(stringReader);
            int count = 0;

            foreach (var carDto in carsDto)
            {
                Car validCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                };

                foreach (var partDto in carDto.Parts.DistinctBy(x => x.Id))
                {
                    if (context.Parts.Any(x => x.Id == partDto.Id))
                    {
                        PartCar partCar = new PartCar() { CarId = validCar.Id, PartId = partDto.Id };
                        validCar.PartsCars.Add(partCar);
                        context.PartsCars.Add(partCar);
                    }
                }

                context.Cars.Add(validCar);
                count++;
            }

            context.SaveChanges();
            return $"Successfully imported {count}";
        }


        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerDto[]), root);
            StringReader stringReader = new StringReader(inputXml);

            CustomerDto[] customerDtos = (CustomerDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var dtoCustomer in customerDtos)
            {
                Customer validCustomer = new Customer()
                {
                    Name = dtoCustomer.Name,
                    BirthDate = dtoCustomer.BirthDate,
                    IsYoungDriver = dtoCustomer.IsYoungDriver
                };

                context.Customers.Add(validCustomer);
            }
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}";
        }


        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleDto[]), root);
            StringReader stringReader = new StringReader(inputXml);

            SaleDto[] saleDtos = (SaleDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var saleDto in saleDtos)
            {
                Sale validSale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };

                if (!context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    continue;
                }

                context.Sales.Add(validSale);
            }

            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}";
        }


        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarExportDto[]), root);
            StringWriter stringWriter = new StringWriter(sb);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            CarExportDto[] cars = context.Cars.Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new CarExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, cars, ns);

            return sb.ToString().TrimEnd();
        }



        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BMWExportDto[]), root);
            StringWriter stringWriter = new StringWriter(sb);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            BMWExportDto[] bwmCars = context.Cars.Where(c => c.Make.ToLower() == "bmw")
    .OrderBy(c => c.Model)
    .ThenByDescending(c => c.TraveledDistance)
    .Select(c => new BMWExportDto()
    {
        Id = c.Id,
        Model = c.Model,
        TraveledDistance = c.TraveledDistance
    })
    .ToArray();



            xmlSerializer.Serialize(stringWriter, bwmCars, ns);
            return sb.ToString().TrimEnd();
        }



        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierExportDto[]), root);
            StringWriter stringWriter = new StringWriter(sb);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            SupplierExportDto[] suppliers = context.Suppliers.Where(s => s.IsImporter == false).Select(s => new SupplierExportDto()
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, suppliers, ns);

            return sb.ToString().TrimEnd();
        }



        //Problem 17
       /* public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarExportDto[]), root);
            StringWriter stringWriter = new StringWriter(sb);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            CarExportDto[] cars = context.Cars.Select(c => new CarExportDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                Parts = c.PartsCars.Select(p => new PartExportDto()
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price,
                })
                .OrderByDescending(p => p.Price)
                .ToList()
            })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, cars, ns);

            return sb.ToString().TrimEnd();
        }*/



        //Problem 18 - 0/100 in Judge
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerDtoExport[]), root);
            StringWriter stringWriter = new StringWriter(sb);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            CustomerDtoExport[] customers = context.Customers.Where(c => c.Sales.Count > 0 ).Select(c => new CustomerDtoExport()
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.IsYoungDriver ? c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price)) - (c.Sales.Sum(s => s.Discount) / 100) *
                c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price)) : c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price))
            })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, customers, ns);

            return sb.ToString().TrimEnd();
        }


        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleDtoExport[]), root);
            StringWriter stringWriter = new StringWriter(sb);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            SaleDtoExport[] sales = context.Sales.Select(s => new SaleDtoExport()
            {
                CustomerCar = new CarExportDto() 
                {
                    TraveledDistance = s.Car.TraveledDistance,
                    Make = s.Car.Make,
                    Model = s.Car.Model
                },

                CustomerName = s.Customer.Name,
                Discount = s.Discount,
                PriceWithDiscount = s.Car.PartsCars.Sum(p => p.Part.Price) - ((s.Discount/100) * s.Car.PartsCars.Sum(p => p.Part.Price)),
                Price = s.Car.PartsCars.Sum(s => s.Part.Price)

            }).ToArray();

            xmlSerializer.Serialize(stringWriter, sales, ns);

            return sb.ToString().TrimEnd();
        }
    }
}