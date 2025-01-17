using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.RequestsEdit;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class GenerosExtension
    {
        public static void AddEndpointsGeneros(this WebApplication app)
        {
            app.MapGet("/generos", ([FromServices] DAL<Genero> generoDAL) =>
            {
                //return musicaDAL.Get();
                return Results.Ok(generoDAL.Get());
            });

            app.MapGet("/genero/{name}", ([FromServices] DAL<Genero> generoDAL, string name) =>
            {
                var genero = generoDAL.GetRegisterBy(
                        a => a.Nome.ToLower().Equals(name.ToLower())
                );

                if (genero == null)
                {
                    return Results.NotFound("Não foi encontrado nenhum genero com esse nome!");
                }

                //return artista;
                return Results.Ok(genero);
            });

            app.MapPost("/genero", ([FromServices] DAL<Genero> generoDAL, [FromBody] GeneroRequest generoRequest) =>
            {
                var genero = new Genero()
                {
                    Nome = generoRequest.Nome,
                    Descricao = generoRequest.Descricao
                };

                //if (musica.Nome == null
                //|| musica.AnoLancamento == null
                //    || musica.artista == null)
                //{
                //    return Results.NotFound("Preencha todos os campos obrigatórios");
                //}

                generoDAL.Create(genero);

                return Results.Ok(genero);
            });

            app.MapDelete("/genero/{musicaId}", ([FromServices] DAL<Genero> generoDAL, long generoId) =>
            {
                if (generoId == null)
                {
                    return Results.NotFound("Id não informado!");
                }

                var genero = generoDAL.GetRegisterBy(a => a.Id == generoId);

                if (genero == null)
                {
                    return Results.NotFound("Musica não encontrado!");
                }

                generoDAL.Delete(genero);

                return Results.Ok(genero + "\n DELETADO");
            });

            app.MapPut("/genero", ([FromServices] DAL<Genero> generoDAL, [FromBody] GeneroRequestEdit generoRequestEdit) =>
            {
                if (generoRequestEdit.id == null
                    || generoRequestEdit.nome == null
                    || generoRequestEdit.descricao == null)
                {
                    return Results.NotFound("Preencha todos os campos obrigatórios");
                }

                var genero = new Genero()
                {
                    Id = generoRequestEdit.id,
                    Nome = generoRequestEdit.nome,
                    Descricao = generoRequestEdit.descricao,
                };

                var updateGenero = generoDAL.GetRegisterBy(a => a.Id == genero.Id);

                if (updateGenero == null)
                {
                    return Results.NotFound("Musica não encontrada!");
                }

                updateGenero.Id = genero.Id;
                updateGenero.Nome = genero.Nome;
                updateGenero.Descricao = genero.Descricao;

                generoDAL.Update(updateGenero);

                var generoResponse = new GeneroResponse(genero.Id, genero.Nome, genero.Descricao);

                return Results.Ok(generoResponse);
            });

        }
    }
}
