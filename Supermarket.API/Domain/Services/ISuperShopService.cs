namespace Supermarket.API.Domain.Services
{
    public interface ISuperShopService
    {
         void ScrapeItems(int SuperShopId, int CategoryId);
    }
}