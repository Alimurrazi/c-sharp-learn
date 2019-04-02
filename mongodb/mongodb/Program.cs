using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mongodb
{
    
    public class Person
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
            var dbList = dbClient.ListDatabaseNames().ToList();
            Console.WriteLine("created database so far...........");
            foreach(var item in dbList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("...................................");

            IMongoDatabase db = dbClient.GetDatabase("Person");
            var collectionList = db.ListCollections().ToList();
            Console.WriteLine("created collection for person database.................");
            foreach(var item in collectionList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("........................................................");

            db = dbClient.GetDatabase("Person");
            IMongoCollection<Person> collection = db.GetCollection<Person>("employees");

            Person randomUser = new Person
            {
                Id = ObjectId.GenerateNewId(),
                FirstName = "john",
                LastName = "doe",
                Age = 25
            };
            collection.InsertOne(randomUser);



            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
