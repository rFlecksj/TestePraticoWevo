using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UsuarioAPI.Models{

    public class Usuario{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome {get; set;}

        [BsonElement("CPF")]
        public string CPF {get; set;}

        [BsonElement("Email")]
        public string Email {get; set;}

        [BsonElement("Telefone")]
        public string Telefone {get; set;}

        [BsonElement("Sexo")]
        public string Sexo {get; set;}

        [BsonElement("DataNascimento")]
        public string DataNascimento {get; set;}
    }
}