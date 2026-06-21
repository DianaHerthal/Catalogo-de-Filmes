using Catalogo_de_Filmes.Views;

namespace Catalogo_de_Filmes;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CadastroFilmePage), typeof(CadastroFilmePage));
        Routing.RegisterRoute(nameof(DetalhesFilmesPage), typeof(DetalhesFilmesPage));
        Routing.RegisterRoute(nameof(EditarFilmePage), typeof(EditarFilmePage));
        Routing.RegisterRoute(nameof(GerenciarGenerosPage), typeof(GerenciarGenerosPage));
    }
}