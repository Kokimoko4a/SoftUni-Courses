using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();


            Console.WriteLine(GetSoldProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }));

            UserDto[]? usersDtos = JsonConvert.DeserializeObject<UserDto[]>(inputJson);

            List<User> usersToInsert = new List<User>();

            foreach (var user in usersDtos!)
            {
                User userValid = mapper.Map<User>(user);
                usersToInsert.Add(userValid);
            }

            context.Users.AddRange(usersToInsert);
            context.SaveChanges();
            return $"Successfully imported {usersToInsert.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }));

            ProductDto[]? productsDto = JsonConvert.DeserializeObject<ProductDto[]>(inputJson);

            Product[] validProducts = mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }));

            CategoriesDto[] categoriesDtos = JsonConvert.DeserializeObject<CategoriesDto[]>(inputJson);

            ICollection<Category> valid = new HashSet<Category>();

            foreach (var category in categoriesDtos!)
            {
                if (category.Name != null)
                {
                    Category curr = mapper.Map<Category>(category);
                    valid.Add(curr);
                }
            }

            context.Categories.AddRange(valid);
            context.SaveChanges();

            return $"Successfully imported {valid.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }));

            CategoryProductDto[] dtos = JsonConvert.DeserializeObject<CategoryProductDto[]>(inputJson);

            CategoryProduct[] valid = mapper.Map<CategoryProduct[]>(dtos);

            context.CategoriesProducts.AddRange(valid);
            context.SaveChanges();

            return $"Successfully imported {valid.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000).OrderBy(x => x.Price).Select(p => new
            {
                name = p.Name,
                price = p.Price,
                seller = p.Seller.FirstName + " " + p.Seller.LastName
            }).ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Any(x => x.BuyerId != null)).OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(x => x.BuyerId != null).Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        buyerFirstName = x.Buyer.FirstName,                
                        buyerLastName = x.Buyer.LastName
                    }).ToArray()
                }).ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.OrderByDescending(x => x.CategoriesProducts.Count).Select(x => new
            {
                category = x.Name,
                productsCount = x.CategoriesProducts.Count,
                averagePrice = (x.CategoriesProducts.Any() ? x.CategoriesProducts.Average(x => x.Product.Price) : 0).ToString("f2"),
                totalRevenue = (x.CategoriesProducts.Any() ? x.CategoriesProducts.Sum(x => x.Product.Price) : 0).ToString("f2")

            }).ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.Where(x => x.ProductsSold.Any(x => x.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(x => x.Buyer != null),
                        products = x.ProductsSold.Where(x => x.Buyer != null).Select(x => new
                        {
                            name = x.Name,
                            price = x.Price,
                        }).ToArray()
                    }
                })
                .OrderByDescending(x => x.soldProducts.count).ToArray();

            var wrap = new
            {
                usersCount = users.Length,
                users = users
            };

            return JsonConvert.SerializeObject(wrap, Formatting.Indented, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        }
    }
}