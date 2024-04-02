using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prodrentapi.Models{

    public class OrigemModel{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? id{get;set;}
        [BsonElement("Nome")]
        public String? Nome{get;set;}

    }

}