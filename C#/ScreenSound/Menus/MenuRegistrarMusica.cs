using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");

        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;

        var artistaDB = artistaDAL.GetRegisterBy(a => a.Nome == nomeDoArtista);
        if (artistaDB != null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            
            Console.Write("Agora digite o ano de lançamento da música: ");
            string anoLancamento = Console.ReadLine()!;

            //Artista artista = artistasRegistrados[nomeDoArtista];
            artistaDB.AdicionarMusica(new Musica(tituloDaMusica) 
            { 
                AnoLancamento = Convert.ToInt32(anoLancamento), 
                artistaId = artistaDB.Id 
            });
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");

            artistaDAL.Update(artistaDB);

            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
