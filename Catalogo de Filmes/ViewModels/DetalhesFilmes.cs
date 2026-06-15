using System;
using System.Collections.Generic;
using System.Text;

using Catalogo_de_Filmes.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Catalogo_de_Filmes.ViewModels;

[QueryProperty(nameof(Filme), "FilmeSelecionado")]
public partial class DetalhesFilmes : ObservableObject
{
    [ObservableProperty]
    private Filme _filme;
}