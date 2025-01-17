using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.RequestsEdit;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicasExtension
    {
        public static void AddEndpointsMusicas(this WebApplication app)
        {
            app.MapGet("/musicas", ([FromServices] DAL<Musica> musicaDAL) =>
            {
                //return musicaDAL.Get();
                return Results.Ok(musicaDAL.Get());
            });

            app.MapGet("/musica/{name}", ([FromServices] DAL<Musica> musicaDAL, string name) =>
            {
                var musica = musicaDAL.GetRegisterBy(
                        a => a.Nome.ToLower().Equals(name.ToLower())
                );

                if (musica == null)
                {
                    return Results.NotFound("Não foi encontrado nenhuma musica com esse nome!");
                }

                //return artista;
                return Results.Ok(musica);
            });

            app.MapPost("/musica", ([FromServices] DAL<Musica> musicaDAL, [FromServices] DAL<Genero> generoDAL, [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.Nome)
                {
                    artistaId = musicaRequest.artistaId ,
                    AnoLancamento = musicaRequest.AnoLancamento,
                    Generos = musicaRequest.Generos is not null ? GeneroRequestConverter(generoDAL, musicaRequest.Generos )
                                                                : new List<Genero>()
                };
                    
                //if (musica.Nome == null
                //|| musica.AnoLancamento == null
                //    || musica.artista == null)
                //{
                //    return Results.NotFound("Preencha todos os campos obrigatórios");
                //}

                musicaDAL.Create(musica);

                return Results.Ok(musica);
            });

            app.MapDelete("/musica/{musicaId}", ([FromServices] DAL<Musica> musicaDAL, long musicaId) =>
            {
                if (musicaId == null)
                {
                    return Results.NotFound("Id não informado!");
                }

                var musica = musicaDAL.GetRegisterBy(a => a.Id == musicaId);

                if (musica == null)
                {
                    return Results.NotFound("Musica não encontrado!");
                }

                musicaDAL.Delete(musica);

                return Results.Ok(musica + "\n DELETADO");
            });

            app.MapPut("/musica", ([FromServices] DAL<Musica> musicaDAL, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
            {
                var musica = new Musica(musicaRequestEdit.musica.Nome)
                {
                    AnoLancamento = musicaRequestEdit.musica.AnoLancamento, 
                    artistaId = musicaRequestEdit.artista.Id
                }
                ;

                if (musica.Nome == null
                    || musica.AnoLancamento == null
                    || musica.artistaId == null)
                {
                    return Results.NotFound("Preencha todos os campos obrigatórios");
                }

                var updateMusica = musicaDAL.GetRegisterBy(a => a.Id == musica.Id);

                if (updateMusica == null)
                {
                    return Results.NotFound("Musica não encontrada!");
                }

                updateMusica.Nome = musica.Nome;
                updateMusica.AnoLancamento = musica.AnoLancamento;
                updateMusica.artistaId = musica.artistaId;

                musicaDAL.Update(updateMusica);

                var musicaArtista = musicaDAL.GetRegisterBy(a => a.Id == musica.artistaId);

                var musicaResponse = new MusicaResponse(musica.Id, musica.Nome, musica.artistaId, musicaArtista.Nome);

                return Results.Ok(musicaResponse);
            });

        }

        private static ICollection<Genero> GeneroRequestConverter([FromServices] DAL<Genero> generoDAL,ICollection<GeneroRequest> generos)
        {
            var listaGeneros = new List<Genero>();
            foreach (var genero in generos)
            {
                var entity = RequestToEntity(genero);
                    /* o entity marca a entidade como uma entidade rastreável se ele a recuperar.
                     * é manipulado pelo entity. Caso seja necessário alterar essa entidade que está marcada, 
                     * ele vai atualizar a informação, ou seja, vai cadastrar novamente o item, como acontecia antes.*/


                var generoBD = generoDAL.GetRegisterBy(g => g.Nome.ToUpper().Equals(genero.Nome.ToUpper()));
                if (generoBD != null)
                {
                    listaGeneros.Add(generoBD);
                } else
                {
                    listaGeneros.Add(entity);
                }
            }

            return listaGeneros;
        }

        private static Genero RequestToEntity(GeneroRequest genero)
        {
            return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao } ;
        }
    }
}
