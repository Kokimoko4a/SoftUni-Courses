using SoftUniBazar.Models;

namespace SoftUniBazar.Contracts
{
    public interface IAdService
    {
        Task<ICollection<CategoryFormModel>> LoadCategories();

        Task CreateAd(AdFormModel adFormModel, string username);

        Task<ICollection<AdViewModel>> GetAllAds();

        Task<bool> AdExists(int id);

        Task<bool> IsAdYour(int id, string username);

        Task<AdFormModel> GetAdForEdit(int id);

        Task EditAd(AdFormModel adFormModel);

        Task<bool> IsAlreadyAdded(int id, string username);

        Task AddAdToCollection(int id, string username);

        Task<IEnumerable<AdViewModel>> GetAllAdsForUser(string username);

        Task RemoveAdFromUserCart(int id, string username);

    }
}
