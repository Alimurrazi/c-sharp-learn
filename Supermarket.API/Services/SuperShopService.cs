using System;
using System.Collections.Generic;
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
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
namespace Supermarket.API.Services
{
    public class SuperShopService : ISuperShopService
    {
        private readonly ISuperShopRepository _ISuperShopRepository;
        private readonly ICategoryRepository _ICategoryRepository;
        private readonly ILogger<SuperShopService> _logger;
        public SuperShopService(ISuperShopRepository superShopRepository,
         ICategoryRepository categoryRepository,
         ILogger<SuperShopService> logger){
            _ISuperShopRepository = superShopRepository;
            _ICategoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<IHtmlDocument> ScrapeItems(int SuperShopId, int CategoryId){
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
          //  this.GetScrapedResults(document);
          //_logger.LogInformation(document);
          // c16H9d


         //   _logger.LogInformation(document.DocumentElement.OuterHtml);
            this.GetScrapedResults(document);
            return document;
        }

        private void GetScrapedResults(IHtmlDocument document){
           // IEnumerable<IElement> productElementCollection = null;
           var productElementCollection = document.All.Where(x =>
                x.ClassName == "c16H9d");
           // Console.WriteLine(productElementCollection);
            _logger.LogInformation(productElementCollection.ToString());
        }
    }
}