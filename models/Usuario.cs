using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prodrentapi.Models
{
     public class UsuarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id{get;set;}

        [BsonElement("Nome")]
        public string? Nome{get;set;}

        [BsonElement("Email")]
        public string? Email{get;set;}

        [BsonElement("Senha")]
        public string? Senha{get;set;}

    }

}