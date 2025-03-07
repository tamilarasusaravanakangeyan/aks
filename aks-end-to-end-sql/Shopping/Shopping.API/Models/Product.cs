using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shopping.API.Models
{
    public class Product
    {
        public string Id { get; set; }  // Updated to string (could be GUID or another string-based ID)
        public string Name { get; set; }
        public string Category { get; set; }  // Added Category
        public string Description { get; set; }  // Added Description
        public string ImageFile { get; set; }  // Added ImageFile
        public int Price { get; set; }
    }
}
