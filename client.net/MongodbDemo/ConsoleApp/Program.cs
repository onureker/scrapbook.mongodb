using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Untyped();
            Task task2 = Typed();
            task2.GetAwaiter().GetResult();
        }

        private static async Task Typed()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<Person>("bar");

            await collection.InsertOneAsync(new Person { Name = "Jack" });

            var list = await collection.Find(x => x.Name == "Jack")
                .ToListAsync();

            foreach (var person in list)
            {
                Console.WriteLine(person.Name);
            }
        }

        private static async Task Untyped()
        {
            var client = new MongoClient("mongodb://10.0.75.1:27017");
            var database = client.GetDatabase("deneme");
            var collection = database.GetCollection<BsonDocument>("bar");

            await collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

            var list = await collection.Find(new BsonDocument("Name", "Jack"))
                .ToListAsync();

            foreach (var document in list)
            {
                Console.WriteLine(document["Name"]);
            }
        }
    }
}
