using Catalogo_de_Filmes.ViewModels;

namespace Catalogo_de_Filmes.Views;

public partial class CadastroFilmePage : ContentPage
{
    public CadastroFilmePage(ListaFilmes viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}