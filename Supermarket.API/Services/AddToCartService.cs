using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using Supermarket.API.Domain.Services;
using System.Threading.Tasks;
using Supermarket.API.Resources;
using Supermarket.API.Persistence.Repositories;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Models;
using System.Linq;
namespace Supermarket.API.Services
{
    public class AddToCartService: IAddToCartService
    {
        private readonly IAddToCartRepository _addToCartRepository;
        public AddToCartService(IAddToCartRepository AddToCartRepository){
            this._addToCartRepository = AddToCartRepository;
        }
        private List<int> GetProductIdList(AddToCartResource[] products){
            List<int> idList = new List<int>();
            foreach (var product in products)
            {
                idList.Add(product.ProductId);
            }
            return idList;
        }
        public async Task <int> CalculateProductPrice(AddToCartResource[] cartResource){
            List<int> idList = this.GetProductIdList(cartResource);
            var selectedProducts = await _addToCartRepository.GetProductListById(idList);
            int Price = 0;
            foreach (var CartItem in cartResource)
            {
            Product SelectedProduct = selectedProducts.First(product => product.Id == CartItem.ProductId);
            var ProductPrice = int.Parse(Regex.Replace(SelectedProduct.Price, "[^0-9]", ""));
            Price = Price + (ProductPrice * CartItem.Amount);
            }
            return Price;
        }
    }
}