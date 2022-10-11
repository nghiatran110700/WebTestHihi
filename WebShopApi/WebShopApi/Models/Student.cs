using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebShopApi.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public List<string> Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
