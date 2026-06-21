using Catalogo_de_Filmes.Models;
using Catalogo_de_Filmes.Repositories;
using Catalogo_de_Filmes.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Catalogo_de_Filmes.ViewModels;

[QueryProperty(nameof(Filme), "FilmeSelecionado")]
public partial class DetalhesFilmes : ObservableObject
{
    private readonly IFilmeRepository _repository;

    [ObservableProperty]
    private Filme _filme;

    public DetalhesFilmes(IFilmeRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    private async Task IrParaEdicaoAsync()
    {
        var parametros = new Dictionary<string, object>
        {
            { "FilmeEdicao", Filme }
        };
        await Shell.Current.GoToAsync(nameof(EditarFilmePage), parametros);
    }

    [RelayCommand]
    private async Task SalvarEdicaoAsync()
    {
        if (Filme == null) return;

        await _repository.UpdateFilmeAsync(Filme);
        await Shell.Current.DisplayAlert("Sucesso", "Filme atualizado com sucesso!", "OK");

        await Shell.Current.GoToAsync("../..");
    }
}