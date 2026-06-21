using Catalogo_de_Filmes.Models;
using Catalogo_de_Filmes.Repositories;
using Catalogo_de_Filmes.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Catalogo_de_Filmes.ViewModels;

public partial class ListaFilmes : ObservableObject
{
    private readonly IFilmeRepository _repository;
    private readonly IGeneroRepository _generoRepository;

    [ObservableProperty]
    private ObservableCollection<Filme> _filmes;

    [ObservableProperty]
    private Filme _novoFilme;


    [ObservableProperty]
    private ObservableCollection<Genero> _listaDeGeneros;

    [ObservableProperty]
    private Genero _generoSelecionado;

    public ListaFilmes(IFilmeRepository repository, IGeneroRepository generoRepository)
    {
        _repository = repository;
        _generoRepository = generoRepository;

        Filmes = new ObservableCollection<Filme>();
        ListaDeGeneros = new ObservableCollection<Genero>(); 
        NovoFilme = new Filme();

        CarregarFilmesAsync();
    }

    public async Task CarregarFilmesAsync()
    {
        try
        {
            var databaseFilmes = await _repository.GetFilmesAsync();
            Filmes.Clear();
            foreach (var filme in databaseFilmes) Filmes.Add(filme);

            var databaseGeneros = await _generoRepository.GetGenerosAsync();
            ListaDeGeneros.Clear();
            foreach (var gen in databaseGeneros) ListaDeGeneros.Add(gen);
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Erro", "Erro ao conectar com o MongoDB.", "OK");
        }
    }

    [RelayCommand]
    private async Task IrParaCadastroAsync()
    {
        NovoFilme = new Filme();
        GeneroSelecionado = null; 

        await CarregarFilmesAsync();

        await Shell.Current.GoToAsync(nameof(CadastroFilmePage));
    }

    
    [RelayCommand]
    private async Task SalvarFilmeAsync()
    {
        if (string.IsNullOrWhiteSpace(NovoFilme.Titulo))
        {
            await Shell.Current.DisplayAlert("Aviso", "O título do filme é obrigatório.", "OK");
            return;
        }

        NovoFilme.Genero = GeneroSelecionado?.Nome ?? "Sem Gênero";

        await _repository.AddFilmeAsync(NovoFilme);
        Filmes.Add(NovoFilme);

        await Shell.Current.DisplayAlert("Sucesso", "Filme cadastrado com sucesso!", "OK");
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task RemoverFilmeAsync(Filme filmeSelecionado)
    {
        if (filmeSelecionado == null) return;
        await _repository.DeleteFilmeAsync(filmeSelecionado);
        Filmes.Remove(filmeSelecionado);
    }

    [RelayCommand]
    private async Task IrParaDetalhesAsync(Filme filmeSelecionado)
    {
        if (filmeSelecionado == null) return;
        var parametros = new Dictionary<string, object> { { "FilmeSelecionado", filmeSelecionado } };
        await Shell.Current.GoToAsync(nameof(DetalhesFilmesPage), parametros);
    }

    
    [RelayCommand]
    private async Task IrParaGenerosAsync()
    {
        await Shell.Current.GoToAsync(nameof(GerenciarGenerosPage));
    }
}