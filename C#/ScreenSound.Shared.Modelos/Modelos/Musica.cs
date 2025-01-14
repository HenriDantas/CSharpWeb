using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos;

public class Musica
{
    public Musica(string nome, int anoLancamento, Artista artistaa)
    {
        Nome = nome;
        AnoLancamento = anoLancamento;
        artista = artistaa;
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int AnoLancamento { get; set; }
    public Artista? artista { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}