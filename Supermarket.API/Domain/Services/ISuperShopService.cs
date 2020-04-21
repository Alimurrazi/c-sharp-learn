using AngleSharp.Html.Dom;
using System.Threading.Tasks;
namespace Supermarket.API.Domain.Services
{
    public interface ISuperShopService
    {
         Task<IHtmlDocument> ScrapeItems(int SuperShopId, int CategoryId);
    }
}