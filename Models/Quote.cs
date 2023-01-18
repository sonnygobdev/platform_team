using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIK8S.Models
{
    public class Quote
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("quote")]
        public string Qte { get; set; } = null!;

        [BsonElement("author")]
        public string Author { get; set; } = null!;
    }
}
