using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos;

public class Musica
{
    public Musica(string nome)
    {
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int AnoLancamento { get; set; }
    public int artistaId { get; set; }
    public virtual Artista? artista { get; set; }
    public virtual ICollection<Genero> Generos { get; set; }

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