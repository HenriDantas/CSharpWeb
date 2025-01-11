using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir TODAS as musicas");

        Console.Write("Digite o ano das musicas que deseja ver: ");
        var anoLancamento = Console.ReadLine()!;

        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());

        var listMusics = musicaDAL.GetAllBy(m => m.AnoLancamento == Convert.ToInt32(anoLancamento));
        if (listMusics != null)
        {
            foreach (var music in listMusics)
            {
                Console.WriteLine($"\n{music.ToString()}");
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNenhuma musica foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
