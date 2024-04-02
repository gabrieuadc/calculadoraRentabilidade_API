using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prodrentapi.Models{

    public class ProdutoRentabilidadeModel{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? id{get;set;}

        [BsonElement("UF")]
        [StringLength(2, MinimumLength = 2)]
        public String? UF{get;set;}

        [BsonElement("ProdutoId")]
        public int ProdutoId{get;set;}

        [BsonElement("OrigemId")]
        public int OrigemId{get;set;}

        [BsonElement("DestinacaoId")]
        public int DestinacaoId{get;set;}

        [BsonElement("ValorCusto")]
        public int ValorCusto{get;set;}
        
        [BsonElement("ValorVenda")]
        public int ValorVenda{get;set;}

    }

}





// UF             ( SC, RS, PR ... ) 
// ProdutoId   
// OrigemId			
// DestinacaoId
// ValorCusto
// ValorVenda