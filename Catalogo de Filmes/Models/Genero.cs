using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogo_de_Filmes.Models;

public class Genero
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Nome { get; set; }
}