﻿using ScreenSound.Modelos;

namespace ScreenSound.API.RequestsEdit;

public record MusicaRequestEdit(Musica musica, Artista artista);

//professor fez assim 

/* 
    public record MusicaRequestEdit(int Id, string nome, int ArtistaId,int anoLancamento)
        : MusicaRequest(nome,ArtistaId,anoLancamento);
*/