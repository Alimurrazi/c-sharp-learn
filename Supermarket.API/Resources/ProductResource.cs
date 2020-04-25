namespace Supermarket.API.Resources
{
    public class ProductResource
    {
        public int Id{get;set;}
        public int SuperShopId {get;set;}
        public string Name{get;set;}
        public int QuantityInPackage{get;set;}
        public string UnitOfMeasurement{get;set;}
        public string SuperShopUrl{get;set;}
        public string Price{get;set;}
        public CategoryResource Category{get;set;}
    }
}