using Catalogo_de_Filmes.Models;

namespace Catalogo_de_Filmes.Repositories;

public interface IGeneroRepository
{
    Task<List<Genero>> GetGenerosAsync();
    Task AddGeneroAsync(Genero genero);
    Task DeleteGeneroAsync(Genero genero);
}