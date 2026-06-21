using Catalogo_de_Filmes.ViewModels;

namespace Catalogo_de_Filmes.Views;

public partial class ListaFilmesPage : ContentPage
{
    private readonly ListaFilmes _viewModel;

    public ListaFilmesPage(ListaFilmes viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_viewModel != null)
        {
            
            await _viewModel.CarregarFilmesAsync();
        }
    }
}