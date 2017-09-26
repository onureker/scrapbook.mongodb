using MongoDB.Bson;

namespace ConsoleApp
{
    public class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}