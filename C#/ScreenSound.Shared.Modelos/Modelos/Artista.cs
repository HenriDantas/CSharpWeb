﻿using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos; 

public class Artista 
{
    private ICollection<Musica> Musicas = new List<Musica>();

    public Artista(string nome, string bio, String fotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png")
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = fotoPerfil;
    }
    public string Nome { get; set; }
    public string FotoPerfil { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Ano: {musica.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}