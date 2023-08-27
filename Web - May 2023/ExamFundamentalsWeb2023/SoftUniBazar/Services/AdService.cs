
namespace SoftUniBazar.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SoftUniBazar.Contracts;
    using SoftUniBazar.Data;
    using SoftUniBazar.Data.Models;
    using SoftUniBazar.Models;


    public class AdService : IAdService
    {
        private readonly BazarDbContext data;

        public AdService(BazarDbContext data)
        {
            this.data = data;
        }



        public async Task<ICollection<CategoryFormModel>> LoadCategories()
        {
            return await data.Categories.Select(c => new CategoryFormModel()
            {
                Id = c.Id,
                Name = c.Name
            }).ToArrayAsync();
        }

        public async Task CreateAd(AdFormModel adFormModel, string username)
        {
            IdentityUser user = await data.Users.FirstOrDefaultAsync(u => u.UserName == username);

            Ad ad = new Ad()
            {
                Description = adFormModel.Description,
                CategoryId = adFormModel.CategoryId,
                ImageUrl = adFormModel.ImageUrl,
                Name = adFormModel.Name,
                OwnerId = user!.Id,
                Price = adFormModel.Price
            };

            data.Ads.Add(ad);
            await data.SaveChangesAsync();
        }

        public async Task<ICollection<AdViewModel>> GetAllAds()
        {
            return await data.Ads.Include(c => c.Category).Include(u => u.Owner).Select(a => new AdViewModel()
            {
                Description = a.Description,
                Owner = a.Owner.UserName,
                CreatedOn = a.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                Category = a.Category.Name,
                Price = a.Price,
                ImageUrl = a.ImageUrl,
                Name = a.Name,
                Id = a.Id
            }).ToArrayAsync();
        }

        public async Task<bool> AdExists(int id)
        {
            return await data.Ads.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> IsAdYour(int id, string username)
        {
            return await data.Ads.Include(u => u.Owner).AnyAsync(a => a.Owner.UserName == username && a.Id == id);
        }

        public async Task<AdFormModel> GetAdForEdit(int id)
        {
            Ad ad = await data.Ads.FirstOrDefaultAsync(a => a.Id == id);


            AdFormModel adFormModel = new AdFormModel()
            {
                Description = ad.Description,
                Categories = await LoadCategories(),
                CategoryId = ad.CategoryId,
                ImageUrl = ad.ImageUrl,
                Name = ad.Name,
                Price = ad.Price,
                Id = ad.Id
            };


            return adFormModel;
        }

        public async Task EditAd(AdFormModel adFormModel)
        {
            Ad ad = await data.Ads.FirstOrDefaultAsync(a => a.Id == adFormModel.Id);

            ad.Description = adFormModel.Description;
            ad.Price = adFormModel.Price;
            ad.ImageUrl = adFormModel.ImageUrl;
            ad.Name = adFormModel.Name;
            ad.CategoryId = adFormModel.CategoryId;


            await data.SaveChangesAsync();
        }

        public async Task<bool> IsAlreadyAdded(int id, string username)
        {
            IdentityUser user = await data.Users.FirstOrDefaultAsync(u => u.UserName == username);

            bool exists = await data.AdBuyers.AnyAsync(ab => ab.AdId == id & ab.BuyerId == user.Id);

            return exists;
        }

        public async Task AddAdToCollection(int id, string username)
        {
            IdentityUser user = await data.Users.FirstOrDefaultAsync(u => u.UserName == username);

            AdBuyer adBuyer = new AdBuyer()
            {
                AdId = id,
                BuyerId = user!.Id
            };

            await data.AdBuyers.AddAsync(adBuyer);

            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdViewModel>> GetAllAdsForUser(string username)
        {
            IdentityUser user = await data.Users.FirstOrDefaultAsync(u => u.UserName == username);

            ICollection<AdBuyer> adBuyers = await data.AdBuyers.Where(ab => ab.BuyerId == user.Id).ToArrayAsync();

            ICollection<AdViewModel> ads = new List<AdViewModel>();    

            foreach (var item in adBuyers)
            {
                Ad ad = await data.Ads.Include(a => a.Category).Include(u => u.Owner).FirstOrDefaultAsync(a => a.Id == item.AdId);

                AdViewModel adViewModel = new AdViewModel()
                {
                    Description = ad.Description,
                    CreatedOn = ad.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Category = ad.Category.Name,
                    Id = item.AdId,
                    ImageUrl = ad.ImageUrl,
                    Name = ad.Name,
                    Owner = ad.Owner.UserName,
                    Price = ad.Price,
                };

                ads.Add(adViewModel);
            }

            return ads;
        }

        public async Task RemoveAdFromUserCart(int id, string username)
        {
            IdentityUser user = await data.Users.FirstOrDefaultAsync(u => u.UserName == username);

            AdBuyer adBuyer = await data.AdBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == user.Id && ab.AdId == id);

            data.AdBuyers.Remove(adBuyer);

            await data.SaveChangesAsync();
        }
    }
}
