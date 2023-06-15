using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ScrumApp.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        [BsonElement("User_Name")]
        public string User_Name { get; set; } = null!;

        [BsonElement("Board_Ids")]
        public BoardIds BoardIds { get; set; } = new BoardIds();



    }
    public class BoardIds
    {
        [BsonElement("bid")]
        public string Bid { get; set; } = null!;
    }
}
