using Catalogo_de_Filmes.Views;

namespace Catalogo_de_Filmes;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetalhesFilmePage), typeof(DetalhesFilmePage));
    }
}