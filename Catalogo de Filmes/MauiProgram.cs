using Microsoft.Extensions.Logging;
using Catalogo_de_Filmes.ViewModels;
using Catalogo_de_Filmes.Views;

namespace Catalogo_de_Filmes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<ListaFilmes>();
            builder.Services.AddTransient<DetalhesFilmes>();

            builder.Services.AddTransient<ListaFilmesPage>();
            builder.Services.AddTransient<DetalhesFilmesPage>();

            return builder.Build();
        }
    }

    internal class DetalhesFilmesPage
    {
    }
}