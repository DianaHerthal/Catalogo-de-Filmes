using Catalogo_de_Filmes.ViewModels;

namespace Catalogo_de_Filmes.Views;

public partial class GerenciarGenerosPage : ContentPage
{
    public GerenciarGenerosPage(GerenciarGenerosViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}