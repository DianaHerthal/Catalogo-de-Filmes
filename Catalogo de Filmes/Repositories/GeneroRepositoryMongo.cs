using Catalogo_de_Filmes.Models;
using MongoDB.Driver;

namespace Catalogo_de_Filmes.Repositories;

public class GeneroRepositoryMongo : IGeneroRepository
{
    private readonly IMongoCollection<Genero> _collection;

    public GeneroRepositoryMongo()
    {
        var client = new MongoClient("mongodb+srv://nomeuser_db_user:senha@cluster0.zcskgxg.mongodb.net/?appName=Cluster0");
        var database = client.GetDatabase("CatalogoFilmesDB");
        _collection = database.GetCollection<Genero>("Generos");
    }

    public async Task<List<Genero>> GetGenerosAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task AddGeneroAsync(Genero genero)
    {
        await _collection.InsertOneAsync(genero);
    }

    public async Task DeleteGeneroAsync(Genero genero)
    {
        await _collection.DeleteOneAsync(g => g.Id == genero.Id);
    }
}
