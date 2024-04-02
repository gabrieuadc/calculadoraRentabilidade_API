using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prodrentapi.Models{

    public class ProdutoOrigemModel{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public String? id{get;set;}

        [BsonElement("UF")]
        [StringLength(2, MinimumLength = 2)]
        public String? UF{get;set;}

        [BsonElement("ProdutoID")]
        public int ProdutoID{get;set;}

        [BsonElement("OrigemID")]
        public int OrigemID{get;set;}

        [BsonElement("AliquotaCreditoPIS")]
        public int AliquotaCreditoPIS{get;set;}

        [BsonElement("AliquotaCreditoCOFINS")]
        public int AliquotaCreditoCOFINS{get;set;}

        [BsonElement("AliquotaCreditoIPI")]
        public int AliquotaCreditoIPI{get;set;}

        [BsonElement("AliquotaCreditoICMS")]
        public int AliquotaCreditoICMS{get;set;}

        [BsonElement("AliquotaCreditoOutros")]
        public int AliquotaCreditoOutros{get;set;}

    }

}