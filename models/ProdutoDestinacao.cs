using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prodrentapi.Models{

    public class ProdutoDestinacaoModel{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? id{get;set;}
        [BsonElement("UF")]
        [StringLength(2, MinimumLength = 2)]
        public String? UF{get;set;}

        [BsonElement("ProdutoID")]
        public int ProdutoID{get;set;}

        [BsonElement("DestinacaoID")]
        public int DestinacaoID{get;set;}

        [BsonElement("AliquotaDebitoPIS")]
        public float AliquotaDebitoPIS{get;set;}

        [BsonElement("AliquotaDebitoCOFINS")]
        public float AliquotaDebitoCOFINS{get;set;}

        [BsonElement("AliquotaDebitoIPI")]
        public float AliquotaDebitoIPI{get;set;}

        [BsonElement("AliquotaDebitoICMS")]
        public float AliquotaDebitoICMS{get;set;}

        [BsonElement("AliquotaDebitoOutros")]
        public float AliquotaDebitoOutros{get;set;}

    }

}