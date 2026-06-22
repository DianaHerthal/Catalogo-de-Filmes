using Catalogo_de_Filmes.ViewModels;

namespace Catalogo_de_Filmes.Views;

public partial class ListaFilmesPage : ContentPage
{
    public ListaFilmesPage(ListaFilmes viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ListaFilmes viewModel)
        {
            await viewModel.CarregarFilmesAsync();
        }
    }
}