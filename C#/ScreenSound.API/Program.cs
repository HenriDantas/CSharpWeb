using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

app.MapGet("/", () =>
{
    var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
    return artistaDAL.Get();
});

app.Run();
