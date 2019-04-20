using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace mongodb_crud_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");

            IMongoDatabase db = dbClient.GetDatabase("cityList");
            var collection = db.GetCollection<BsonDocument>("city");

            BsonDocument city = new BsonDocument();
            BsonElement nameElement = new BsonElement("name","dhaka");
            city.Add(nameElement);
            city.Add(new BsonElement("population", "20M"));
            collection.InsertOne(city);

            BsonElement updateNameElement = new BsonElement("name", "Dhaka");
            BsonDocument updateCity = new BsonDocument();
            updateCity.Add(updateNameElement);
            updateCity.Add(new BsonElement("population", "35M"));
            BsonDocument findCity = new BsonDocument(new BsonElement("population", "25M"));
            var update = collection.FindOneAndReplace(findCity, updateCity);

            findCity= new BsonDocument(new BsonElement("name", "dhaka"));
            collection.FindOneAndDelete(findCity);

            //var result = collection.Find(new BsonDocument()).ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToString());
            //}


            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
