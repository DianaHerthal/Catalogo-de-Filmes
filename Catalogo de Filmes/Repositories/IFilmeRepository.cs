using System;
using System.Collections.Generic;
using System.Text;

using Catalogo_de_Filmes.Models;

namespace Catalogo_de_Filmes.Repositories;

public interface IFilmeRepository
{
    Task<IEnumerable<Filme>> GetFilmesAsync();

    Task AddFilmeAsync(Filme filme);
    Task UpdateFilmeAsync(Filme filme);
    Task DeleteFilmeAsync(Filme filme);
}