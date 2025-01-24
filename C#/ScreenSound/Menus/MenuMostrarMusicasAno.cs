using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir TODAS as músicas por ano de lançamento");

        Console.Write("Digite o ano das músicas que deseja ver: ");
        string anoLancamento = Console.ReadLine()!;

        var musicaDAL = new DAL<Musica>(new ScreenSoundContext(context));

        var listMusics = musicaDAL.GetAllBy(m => m.AnoLancamento == Convert.ToInt32(anoLancamento));
        if (listMusics.Count() > 0)
        {
            Console.WriteLine($"\nExibindo músicas do Ano {anoLancamento}:");
            foreach (var music in listMusics)
            {
                music.ExibirFichaTecnica();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNenhuma músicas foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
