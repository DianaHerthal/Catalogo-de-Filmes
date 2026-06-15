using Catalogo_de_Filmes.Models;
using Catalogo_de_Filmes.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Catalogo_de_Filmes.ViewModels;

public partial class ListaFilmes : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Filme> _filmes;

    public ListaFilmes()
    {
        Filmes = new ObservableCollection<Filme>
        {
            new Filme { Titulo = "Invocação do Mal", Genero = "Terror", Sinopse = "Investigadores paranormais trabalham para ajudar uma família aterrorizada por uma presença sombria em sua fazenda.", ImagemUrl = "https://i.pinimg.com/736x/d8/79/5e/d8795ea96df0da0e3e33700e407198a4.jpg" },
            new Filme { Titulo = "It: A Coisa", Genero = "Terror", Sinopse = "Um grupo de crianças se une para investigar o misterioso disappearance de vários jovens na cidade, enfrentando um palhaço assustador.", ImagemUrl = "https://i.pinimg.com/736x/36/c3/3e/36c33e8a1816eee306121835025ac767.jpg" },

            new Filme { Titulo = "As Branquelas", Genero = "Comédia", Sinopse = "Dois agentes do FBI afro-americanos se disfarçam de duas herdeiras brancas para protegê-las de um sequestro.", ImagemUrl = "https://i.pinimg.com/1200x/64/d5/e8/64d5e81e585d36a4c00c4a10b9118b34.jpg" },
            new Filme { Titulo = "Se Beber, Não Case!", Genero = "Comédia", Sinopse = "Três amigos acordam de uma despedida de solteiro em Las Vegas sem memória da noite anterior e sem o noivo.", ImagemUrl = "https://i.pinimg.com/1200x/74/a7/a3/74a7a37667410cffdb7c037099039ace.jpg" },

            new Filme { Titulo = "Shrek", Genero = "Animado", Sinopse = "Um ogro mal-humorado tem seu pântano invadido por criaturas de contos de fadas e faz um acordo com um lorde para resgatar uma princesa.", ImagemUrl = "https://i.pinimg.com/736x/82/58/d5/8258d5d80e06df3581b603530e17e7de.jpg" },
            new Filme { Titulo = "Toy Story", Genero = "Animado", Sinopse = "Um boneco de caubói se sente ameaçado e com ciúmes quando um novo patrulheiro espacial toma o lugar de brinquedo favorito no quarto.", ImagemUrl = "https://i.pinimg.com/1200x/fa/b8/bf/fab8bf931b25ef82046f8e8119582db7.jpg" }
        };
    }

    [RelayCommand]
    private async Task IrParaDetalhesAsync(Filme filmeSelecionado)
    {
        if (filmeSelecionado == null) return;

        var parametros = new Dictionary<string, object>
        {
            { "FilmeSelecionado", filmeSelecionado }
        };

        await Shell.Current.GoToAsync(nameof(DetalhesFilmePage), parametros);
    }
}