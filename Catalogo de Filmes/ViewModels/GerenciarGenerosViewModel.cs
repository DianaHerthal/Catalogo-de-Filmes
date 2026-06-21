using Catalogo_de_Filmes.Models;
using Catalogo_de_Filmes.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Catalogo_de_Filmes.ViewModels;

public partial class GerenciarGenerosViewModel : ObservableObject
{
    private readonly IGeneroRepository _repository;

    [ObservableProperty]
    private ObservableCollection<Genero> _generos;

    [ObservableProperty]
    private string _novoNomeGenero;

    public GerenciarGenerosViewModel(IGeneroRepository repository)
    {
        _repository = repository;
        Generos = new ObservableCollection<Genero>();
        CarregarGenerosAsync();
    }

    private async Task CarregarGenerosAsync()
    {
        var dados = await _repository.GetGenerosAsync();
        Generos.Clear();
        foreach (var item in dados) Generos.Add(item);
    }

    [RelayCommand]
    private async Task AdicionarGeneroAsync()
    {
        if (string.IsNullOrWhiteSpace(NovoNomeGenero)) return;

        var genero = new Genero { Nome = NovoNomeGenero };
        await _repository.AddGeneroAsync(genero);

        Generos.Add(genero);
        NovoNomeGenero = string.Empty; 
    }

    [RelayCommand]
    private async Task RemoverGeneroAsync(Genero genero)
    {
        if (genero == null) return;
        await _repository.DeleteGeneroAsync(genero);
        Generos.Remove(genero);
    }
}