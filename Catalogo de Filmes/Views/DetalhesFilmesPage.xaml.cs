namespace Catalogo_de_Filmes.Views;

public partial class DetalhesFilmePage : ContentPage
{
    public DetalhesFilmePage(ViewModels.DetalhesFilmes viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}