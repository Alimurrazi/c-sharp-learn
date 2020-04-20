using System.IO;
using System.Net.Http;
using System.Threading;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;

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
        public async void ScrapeItems(int SuperShopId, int CategoryId){
            SuperShop superShop = await _ISuperShopRepository.FindByAsync(SuperShopId);
            Category category = await _ICategoryRepository.FindByIdAsync(CategoryId);

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage request = await httpClient.GetAsync(superShop.Url);
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser(); 
            IHtmlDocument document = parser.ParseDocument(response);
        }
    }
}