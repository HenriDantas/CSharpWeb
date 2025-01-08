using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos;

internal class Musica
{
    public Musica(string nome)
    {
        Nome = nome;
    }

    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    public int Id { get; set; }

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