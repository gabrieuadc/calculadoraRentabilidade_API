using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prodrentapi.Models{

    public class ProdutoModel{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? id{get;set;}
        [BsonElement("CodigoBarras")]
        public String? CodigoBarras{get;set;}
        [BsonElement("NCM")]
        public String? NCM{get;set;}
        [BsonElement("Nome")]
        public String? Nome{get;set;}

    }

}