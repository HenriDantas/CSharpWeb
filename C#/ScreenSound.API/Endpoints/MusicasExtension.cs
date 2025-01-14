using Microsoft.AspNetCore.Mvc;
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

            app.MapPost("/musica", ([FromServices] DAL<Musica> musicaDAL, [FromBody] Musica musica) =>
            {
                if (musica.Nome == null
                    || musica.AnoLancamento == null
                    || musica.artista == null)
                {
                    return Results.NotFound("Preencha todos os campos obrigatórios");
                }

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

            app.MapPut("/musica", ([FromServices] DAL<Musica> musicaDAL, [FromBody] Musica musica) =>
            {
                if (musica.Nome == null
                    || musica.AnoLancamento == null
                    || musica.artista == null)
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
                updateMusica.artista = musica.artista;

                musicaDAL.Update(updateMusica);

                return Results.Ok(musica);
            });

        }
    }
}
