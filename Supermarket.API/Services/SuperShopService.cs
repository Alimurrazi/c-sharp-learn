using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Services
{
    public class SuperShopService : ISuperShopService
    {
        private readonly ISuperShopRepository _ISuperShopRepository;
        private readonly ICategoryRepository _ICategoryRepository;
        public SuperShopService(ISuperShopRepository superShopRepository, ICategoryRepository categoryRepository){
            _ISuperShopRepository = superShopRepository;
            _ICategoryRepository = categoryRepository;
        }
        public void ScrapeItems(int SuperShopId, int CategoryId){
            var SuperShop = _ISuperShopRepository.FindByAsync(SuperShopId);
            var Category = _ICategoryRepository.FindByIdAsync(CategoryId);        
        }
    }
}