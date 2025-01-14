using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class ArtistasExtension
    {
        public static void AddEndpointsArtistas(this WebApplication app)
        {
            app.MapGet("/artistas", ([FromServices] DAL<Artista> artistaDAL) =>
            {
                return artistaDAL.Get();
            });

            app.MapGet("/artista/{name}", ([FromServices] DAL<Artista> artistaDAL, string name) =>
            {
                var artista = artistaDAL.GetRegisterBy(
                        a => a.Nome.ToLower().Equals(name.ToLower())
                );

                if (artista == null)
                {
                    //throw new Exception("Não foi encontrado nenhum artista com esse nome!");
                    //return "Não foi encontrado nenhum artista com esse nome!";
                    return Results.NotFound("Não foi encontrado nenhum artista com esse nome!");
                }

                //return artista;
                return Results.Ok(artista);
            });

            app.MapPost("/artista", ([FromServices] DAL<Artista> artistaDAL, [FromBody] ArtistaRequest artistaRequest) =>
            {
                var artista = new Artista(artistaRequest.nome, artistaRequest.bio);

                if (artista.Nome == null
                    || artista.Bio == null)
                {
                    return Results.NotFound("Preencha todos os campos obrigatórios");
                }

                artistaDAL.Create(artista);

                //return artista;
                return Results.Ok(artista);
            });

            app.MapDelete("/artista/{artistaId}", ([FromServices] DAL<Artista> artistaDAL, long artistaId) =>
            {
                if (artistaId == null)
                {
                    return Results.NotFound("Id não informado!");
                }

                var artista = artistaDAL.GetRegisterBy(a => a.Id == artistaId);

                if (artista == null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }

                artistaDAL.Delete(artista);

                //return artista;
                return Results.Ok(artista + "\n DELETADO");
            });

            app.MapPut("/artista", ([FromServices] DAL<Artista> artistaDAL, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
            {
                var artista = new Artista(artistaRequestEdit.artista.Nome, artistaRequestEdit.artista.Bio, artistaRequestEdit.artista.FotoPerfil);

                if (artista.Nome == null
                    || artista.FotoPerfil == null
                    || artista.Bio == null
                    || artista.Id == null)
                {
                    return Results.NotFound("Preencha todos os campos obrigatórios");
                }

                var updateArtista = artistaDAL.GetRegisterBy(a => a.Id == artista.Id);

                if (updateArtista == null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }

                updateArtista.Bio = artista.Bio;
                updateArtista.FotoPerfil = artista.FotoPerfil;
                updateArtista.Nome = artista.Nome;

                artistaDAL.Update(updateArtista);

                var artistaResponse = new ArtistaResponse(updateArtista.Id, updateArtista.Nome, updateArtista.Bio, updateArtista.FotoPerfil);

                //return artista;
                return Results.Ok(artistaResponse);
            });
        }

    }
}
