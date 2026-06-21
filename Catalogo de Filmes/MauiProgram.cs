using Microsoft.Extensions.Logging;
using Catalogo_de_Filmes.ViewModels;
using Catalogo_de_Filmes.Views;
using Catalogo_de_Filmes.Repositories;

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
            

            
            builder.Services.AddSingleton<ListaFilmes>(); 
            builder.Services.AddTransient<DetalhesFilmes>();

      
            builder.Services.AddTransient<ListaFilmesPage>();
            builder.Services.AddTransient<DetalhesFilmesPage>();
            builder.Services.AddTransient<CadastroFilmePage>();
            builder.Services.AddTransient<EditarFilmePage>();

            builder.Services.AddSingleton<IFilmeRepository, FilmeRepositoryMongo>();
            builder.Services.AddSingleton<IGeneroRepository, GeneroRepositoryMongo>(); 

            builder.Services.AddTransient<GerenciarGenerosViewModel>();
            builder.Services.AddTransient<GerenciarGenerosPage>();

            return builder.Build();
        }
    }
}