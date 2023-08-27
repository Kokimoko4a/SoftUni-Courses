using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Contracts;
using SoftUniBazar.Models;

namespace SoftUniBazar.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService adService;

        public AdController(IAdService adService)
        {
            this.adService = adService;
        }

        public async Task<IActionResult> All()
        {
            return View(await adService.GetAllAds());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new AdFormModel() { Categories = await adService.LoadCategories() });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel adFormModel)
        {
            if (!ModelState.IsValid)
            {
                adFormModel.Categories = await adService.LoadCategories();

                return View(adFormModel);
            }


            try
            {
                await adService.CreateAd(adFormModel, User.Identity.Name);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                adFormModel.Categories = await adService.LoadCategories();

                return View(adFormModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool isAdYours = await adService.IsAdYour(id, User.Identity.Name);
            bool adExists = await adService.AdExists(id);


            if (!isAdYours)
            {
                return RedirectToAction("All");
            }

            if (!adExists)
            {
                return RedirectToAction("All");
            }

            return View(await adService.GetAdForEdit(id));
        }

        [HttpPost]

        public async Task<IActionResult> Edit(AdFormModel adFormModel)
        {
            bool isAdYours = await adService.IsAdYour(adFormModel.Id, User.Identity.Name);
            bool adExists = await adService.AdExists(adFormModel.Id);


            if (!isAdYours)
            {
                return RedirectToAction("All");
            }

            if (!adExists)
            {
                return RedirectToAction("All");
            }


            if (!ModelState.IsValid)
            {
                adFormModel.Categories = await adService.LoadCategories();

                return View(adFormModel);
            }


            try
            {
                await adService.EditAd(adFormModel);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                adFormModel.Categories = await adService.LoadCategories();

                return View(adFormModel); // I am trying to commit directly from here sit and watch ;)
                // Hi again
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            bool adExists = await adService.AdExists(id);
            bool isAlreadyAdded = await adService.IsAlreadyAdded(id, User.Identity.Name);

            if (!adExists)
            {
                return RedirectToAction("All");
            }

            if (isAlreadyAdded)
            {
                return RedirectToAction("All");
            }


            try
            {
                await adService.AddAdToCollection(id, User.Identity.Name);

                return RedirectToAction("Cart", await adService.GetAllAdsForUser(User.Identity.Name));
            }
            catch (Exception)
            {

                return View(await adService.GetAllAds());
            }
           
        }

        [HttpGet]

        public async Task<IActionResult> Cart()
        {
            return View(await adService.GetAllAdsForUser(User.Identity.Name));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id )
        {
            bool adExists = await adService.AdExists(id);
            bool isAlreadyAdded = await adService.IsAlreadyAdded(id, User.Identity.Name);

            if (!adExists)
            {
                return RedirectToAction("Cart", await adService.GetAllAdsForUser(User.Identity.Name));
            }

            if (!isAlreadyAdded)
            {
                return RedirectToAction("Cart", await adService.GetAllAdsForUser(User.Identity.Name));
            }

            await adService.RemoveAdFromUserCart(id, User.Identity.Name);

            return RedirectToAction("All");
        }
    }
}
