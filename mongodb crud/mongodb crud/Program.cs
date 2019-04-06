using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace mongodb_crud
{

    public class Interactions
    {
        public ObjectId Id { get; set; }
        public string ChannelId { get; set; }
        public string ContactId { get; set; }
        public string Language { get; set; }
        public List<Pages> Pages { get; set; }
        public string SiteName { get; set; }
        public int Value { get; set; }
        public int VisitPageCount { get; set; }
    }


    public class Pages
    {
        public string Url { get; set; }
        public int VisitPageIndex { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("urlCollector");
            var collection = database.GetCollection<Interactions>("Interactions");

            var newItem = new Interactions
            {
                SiteName = "ExampleUrl",
                Pages = new List<Pages>
                {
                    new Pages
                    {
                        Url="http://stackoverflow.com",
                        VisitPageIndex = 4
                    },
                    new Pages
                    {
                        Url="http://github.com",
                        VisitPageIndex = 5
                    }
                }
            };

            collection.InsertOne(newItem);
           // var update = MongoDB.Driver.Builders.Update.Set(s => s.SiteName, "New Example");
           // collection.FindOneAndUpdate(s => s.SiteName == "Example", update);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }


}
