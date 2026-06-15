namespace Catalogo_de_Filmes.Views;

public partial class ListaFilmesPage : ContentPage
{
    public ListaFilmesPage(ViewModels.ListaFilmes viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}