using System.Collections.Generic;
using AngleSharp.Html.Dom;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
namespace Supermarket.API.Domain.Services
{
    public interface ISuperShopService
    {
         Task<List<Product>> ScrapeItems(int SuperShopId, int CategoryId);
    }
}