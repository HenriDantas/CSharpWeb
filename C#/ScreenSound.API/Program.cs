using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScreenSound.API.Endpoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//não vai funcionar
//builder.Services.AddDbContext<ScreenSoundContext>((options) => {
//    options
//            .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
//            .UseLazyLoadingProxies();
//});
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//minimal api
//app.MapGet("/artistas", ([FromServices] DAL<Artista> artistaDAL) =>
//{
//    return artistaDAL.Get();
//});

//app.MapGet("/artista/{name}", ([FromServices] DAL<Artista> artistaDAL, string name) =>
//{
//    var artista = artistaDAL.GetRegisterBy(
//            a => a.Nome.ToLower().Equals(name.ToLower())
//    );

//    if(artista == null)
//    {
//        //throw new Exception("Não foi encontrado nenhum artista com esse nome!");
//        //return "Não foi encontrado nenhum artista com esse nome!";
//        return Results.NotFound("Não foi encontrado nenhum artista com esse nome!");
//    }

//    //return artista;
//    return Results.Ok(artista);
//});

//app.MapPost("/artista", ([FromServices] DAL<Artista> artistaDAL, [FromBody] Artista artista) =>
//{
//    if (artista.Nome == null 
//        || artista.FotoPerfil == null 
//        || artista.Bio == null)
//    {
//        return Results.NotFound("Preencha todos os campos obrigatórios");
//    }

//    artistaDAL.Create(artista);

//    //return artista;
//    return Results.Ok(artista);
//});

//app.MapDelete("/artista/{artistaId}", ([FromServices] DAL<Artista> artistaDAL, long artistaId) =>
//{
//    if (artistaId == null)
//    {
//        return Results.NotFound("Id não informado!");
//    }

//    var artista = artistaDAL.GetRegisterBy(a => a.Id == artistaId);

//    if (artista == null)
//    {
//        return Results.NotFound("Artista não encontrado!");
//    }

//    artistaDAL.Delete(artista);

//    //return artista;
//    return Results.Ok(artista + "\n DELETADO");
//});

//app.MapPut("/artista", ([FromServices] DAL<Artista> artistaDAL, [FromBody] Artista artista) =>
//{
//    if (artista.Nome == null
//        || artista.FotoPerfil == null
//        || artista.Bio == null)
//    {
//        return Results.NotFound("Preencha todos os campos obrigatórios");
//    }

//    var updateArtista = artistaDAL.GetRegisterBy(a => a.Id == artista.Id);

//    if (updateArtista == null)
//    {
//        return Results.NotFound("Artista não encontrado!");
//    }

//    updateArtista.Bio = artista.Bio;
//    updateArtista.FotoPerfil= artista.FotoPerfil;
//    updateArtista.Nome = artista.Nome;

//    artistaDAL.Update(updateArtista);

//    //return artista;
//    return Results.Ok(artista);
//});

//app.MapGet("/musicas", ([FromServices] DAL<Musica> musicaDAL) =>
//{
//    //return musicaDAL.Get();
//    return Results.Ok(musicaDAL.Get());
//});

//app.MapGet("/musica/{name}", ([FromServices] DAL<Musica> musicaDAL, string name) =>
//{
//    var musica = musicaDAL.GetRegisterBy(
//            a => a.Nome.ToLower().Equals(name.ToLower())
//    );

//    if (musica == null)
//    {
//        return Results.NotFound("Não foi encontrado nenhuma musica com esse nome!");
//    }

//    //return artista;
//    return Results.Ok(musica);
//});

//app.MapPost("/musica", ([FromServices] DAL<Musica> musicaDAL, [FromBody] Musica musica) =>
//{
//    if (musica.Nome == null
//        || musica.AnoLancamento == null
//        || musica.artista == null)
//    {
//        return Results.NotFound("Preencha todos os campos obrigatórios");
//    }

//    musicaDAL.Create(musica);

//    return Results.Ok(musica);
//});

//app.MapDelete("/musica/{musicaId}", ([FromServices] DAL<Musica> musicaDAL, long musicaId) =>
//{
//    if (musicaId == null)
//    {
//        return Results.NotFound("Id não informado!");
//    }

//    var musica = musicaDAL.GetRegisterBy(a => a.Id == musicaId);

//    if (musica == null)
//    {
//        return Results.NotFound("Musica não encontrado!");
//    }

//    musicaDAL.Delete(musica);

//    return Results.Ok(musica + "\n DELETADO");
//});

//app.MapPut("/musica", ([FromServices] DAL<Musica> musicaDAL, [FromBody] Musica musica) =>
//{
//    if (musica.Nome == null
//        || musica.AnoLancamento == null
//        || musica.artista == null)
//    {
//        return Results.NotFound("Preencha todos os campos obrigatórios");
//    }

//    var updateMusica = musicaDAL.GetRegisterBy(a => a.Id == musica.Id);

//    if (updateMusica == null)
//    {
//        return Results.NotFound("Musica não encontrada!");
//    }

//    updateMusica.Nome = musica.Nome;
//    updateMusica.AnoLancamento = musica.AnoLancamento;
//    updateMusica.artista = musica.artista;

//    musicaDAL.Update(updateMusica);

//    return Results.Ok(musica);
//});



app.AddEndpointsArtistas();
app.AddEndpointsMusicas();
app.AddEndpointsGeneros();

app.Run();
