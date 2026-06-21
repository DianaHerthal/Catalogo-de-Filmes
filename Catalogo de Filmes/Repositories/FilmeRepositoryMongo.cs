using Catalogo_de_Filmes.Models;
using MongoDB.Driver;

namespace Catalogo_de_Filmes.Repositories;

public class FilmeRepositoryMongo : IFilmeRepository
{
    private readonly IMongoCollection<Filme> _colecao;

    public FilmeRepositoryMongo()
    {
       
        var stringConexao = "mongodb://localhost:27017";

        var cliente = new MongoClient(stringConexao);
        var banco = cliente.GetDatabase("CatalogoFilmesDB");
        _colecao = banco.GetCollection<Filme>("Filmes");
    }

    public async Task<IEnumerable<Filme>> GetFilmesAsync()
    {
        return await _colecao.Find(_ => true).ToListAsync();
    }

    public async Task AddFilmeAsync(Filme filme)
    {
        await _colecao.InsertOneAsync(filme);
    }

    public async Task UpdateFilmeAsync(Filme filme)
    {
        await _colecao.ReplaceOneAsync(f => f.Id == filme.Id, filme);
    }

    public async Task DeleteFilmeAsync(Filme filme)
    {
        await _colecao.DeleteOneAsync(f => f.Id == filme.Id);
    }
}