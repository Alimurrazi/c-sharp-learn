using System.Collections.Generic;

namespace Supermarket.API.Domain.Models{
    public class Category{
        public int Id{get;set;}
        public int SupserShopId {get;set;}
        public string Name{get;set;}
        public string TitleInUrl{get;set;}
        public IList<Product>Products{get;set;} = new List<Product>();
    }
}