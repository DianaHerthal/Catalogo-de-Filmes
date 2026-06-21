using Catalogo_de_Filmes.Models; 
using Catalogo_de_Filmes.ViewModels;

namespace Catalogo_de_Filmes.Views;

[QueryProperty(nameof(FilmeEdicao), "FilmeEdicao")]
public partial class EditarFilmePage : ContentPage
{
    private readonly DetalhesFilmes _viewModel;

    public Filme FilmeEdicao
    {
        set => _viewModel.Filme = value;
    }

    public EditarFilmePage(DetalhesFilmes viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}