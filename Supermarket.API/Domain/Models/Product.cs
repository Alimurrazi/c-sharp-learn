namespace Supermarket.API.Domain.Models
{
    public class Product{
        public int Id{get;set;}
         public int SupserShopId {get;set;}
        public string Name{get;set;}
        public short QuantityInPackage{get;set;}
        public int Price{get;set;}
        public int CategoryId{get;set;}
        public EUnitOfMeasurement UnitOfMeasurement{get;set;}
        public Category Category{get;set;}
    }
}