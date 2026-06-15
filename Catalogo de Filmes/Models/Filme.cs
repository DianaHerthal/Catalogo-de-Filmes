using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo_de_Filmes.Models;

public class Filme
{
    public string Titulo { get; set; }  
    public string Sinopse { get; set; } 
    public string ImagemUrl { get; set; }

    public string Genero { get; set; }
}