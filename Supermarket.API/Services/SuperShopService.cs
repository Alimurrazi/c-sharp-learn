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
using System.Text.RegularExpressions;
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
        public async Task<List<Product>> ScrapeItems(int SuperShopId, int CategoryId){
            SuperShop superShop = await _ISuperShopRepository.FindByAsync(SuperShopId);
            Category category = await _ICategoryRepository.FindByIdAsync(CategoryId);

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();
            superShop.Url = "https://www.pickaboo.com/smartphone/samsung.html";
            HttpResponseMessage request = await httpClient.GetAsync(superShop.Url);
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser(); 
            IHtmlDocument document = parser.ParseDocument(response);

            var result = new List<Product>();
            result = this.GetScrapedResults(document);
            return result;
        }

        private string RemoveSpaces(string res){
            string result = "";
            for(int i = 1;i<res.Length-1;i++){
                var c = res[i];
                var p = res[i-1];
                var n = res[i+1];
                if(res[i] == ' '){
                    if((res[i-1]>='a' || res[i-1]>='A' || res[i-1]>='0') && (res[i+1]<='z' || res[i+1]<='Z' || res[i+1]<='9') &&(res[i+1]!='\0')){
                        result+= res[i];
                    }
                }
                else{
                    result+=res[i];
                }
            }
            return result;
        }
        private List<Product> GetScrapedResults(IHtmlDocument document){
            var ProductCollection = new List<Product>();
           var productElementCollection = document.All.Where(x =>
                x.ClassName == "product details product-item-details").ToList();
            productElementCollection.ForEach(s => {
            Product scrappedProduct = new Product();
            var result = s.QuerySelectorAll("a").OfType<IHtmlAnchorElement>();
            foreach (var i in result)
            {
                scrappedProduct.SuperShopUrl = i.Href;
                scrappedProduct.Name = i.InnerHtml;
                scrappedProduct.Name = scrappedProduct.Name.ReplaceFirst("\n","");
                scrappedProduct.Name = RemoveSpaces(scrappedProduct.Name);
            }
            try{
            var price = s.QuerySelector(".price");
            if(price.InnerHtml == null){
                scrappedProduct.Price = "100$";
            }else{
            scrappedProduct.Price = price.InnerHtml;
            }
            ProductCollection.Add(scrappedProduct);
            }catch(Exception ex){
                Console.WriteLine(ex);
            }
            });
            Console.WriteLine(ProductCollection);
            return ProductCollection;
        }

    }
}