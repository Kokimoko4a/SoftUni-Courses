using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            //  string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            ProductShopContext context = new ProductShopContext();
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserImportDto[]), root);

            StringReader reader = new StringReader(inputXml);

            UserImportDto[] usersDto = (UserImportDto[])xmlSerializer.Deserialize(reader);
            int count = 0;

            foreach (var userDto in usersDto)
            {
                User validUser = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age,
                };

                count++;

                context.Users.Add(validUser);
            }

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductsImportDto[]), root);

            StringReader reader = new StringReader(inputXml);

            ProductsImportDto[] productsDto = (ProductsImportDto[])xmlSerializer.Deserialize(reader);
            int count = 0;

            foreach (var dto in productsDto)
            {
                Product validProduct = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId

                };

                count++;

                context.Products.Add(validProduct);
            }

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryDtoImport[]), root);

            StringReader reader = new StringReader(inputXml);

            CategoryDtoImport[] categoriesDto = (CategoryDtoImport[])xmlSerializer.Deserialize(reader);
            int count = 0;

            foreach (var categoryDto in categoriesDto)
            {
                Category validCategory = new Category()
                {
                    Name = categoryDto.Name
                };

                count++;

                context.Categories.Add(validCategory);
            }

            context.SaveChanges();

            return $"Successfully imported {count}";
        }


        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Category_ProductsDto[]), root);

            StringReader reader = new StringReader(inputXml);

            Category_ProductsDto[] categoryProductsDto = (Category_ProductsDto[])xmlSerializer.Deserialize(reader);
            int count = 0;

            foreach (var categoryProductsdto in categoryProductsDto)
            {
                CategoryProduct validCategoryProducts = new CategoryProduct()
                {
                    CategoryId = categoryProductsdto.CategoryId,
                    ProductId = categoryProductsdto.ProductId
                };

                count++;

                context.CategoryProducts.Add(validCategoryProducts);
            }

            context.SaveChanges();

            return $"Successfully imported {count}";
        }


        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductDtoExport[]), root);

            ProductDtoExport[] products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(x => new ProductDtoExport
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                }
                )
                .Take(10)
            .ToArray();

            StringWriter stringWriter = new StringWriter(sb);

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(stringWriter, products, ns);

            return sb.ToString().TrimEnd();
        }


        //Problem 06 
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersProductsExport[]), root);
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            UsersProductsExport[] users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(x => new UsersProductsExport
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Where(x => x.BuyerId != null)
                    .Select(x => new ProductDtoExport
                    {
                        Name = x.Name,
                        Price = x.Price
                    }).ToList()
                }
                )
                .Take(5)
            .ToArray();

            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, users, ns);

            return sb.ToString().TrimEnd();
        }


        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlRootAttribute root = new XmlRootAttribute("Categories");
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CategoriesExport>), root);
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            List<CategoriesExport> categories = context.Categories.Select(c => new CategoriesExport
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count,
                AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price)
            })
                 .OrderByDescending(c => c.Count)
                 .ThenBy(c => c.TotalRevenue)
                 .ToList();

            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, categories, ns);

            return sb.ToString().TrimEnd();
        }


        //Problem 08 - not completed
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUsersAndSoldProductsAndCount), root);
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            ExportUsersAndSoldProductsAndCount usersAndProducts = new ExportUsersAndSoldProductsAndCount();

            usersAndProducts.UsersAndProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new UserAndSoldProductsExport
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts =
                    {
                     Count = x.ProductsSold.Count(x => x.Buyer != null),
                     Products = x.ProductsSold.Where(x => x.Buyer != null).OrderByDescending(x => x.Price)
                     .Select(x => new ProductExport
                     {
                        Name = x.Name,
                        Price = x.Price
                     }).ToList()
                    }
                }
                )
                .OrderByDescending(x => x.SoldProducts.Products.Count)
                .Take(10)
                .ToList();


            usersAndProducts.Count = usersAndProducts.UsersAndProducts.Count;


            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, usersAndProducts, ns);

            return sb.ToString().TrimEnd();
        }
    }
}