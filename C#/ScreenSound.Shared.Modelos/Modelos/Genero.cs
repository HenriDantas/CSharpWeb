using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos;

public class Genero
{

    //public Genero(string nome, string descricao)
    //{
    //    Nome = nome;
    //    Descricao = descricao;
    //}
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public virtual ICollection<Musica> Musicas { get; set; }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Descrição: {Descricao}";
    }
}