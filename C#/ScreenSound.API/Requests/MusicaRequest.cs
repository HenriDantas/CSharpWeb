using ScreenSound.Modelos;

namespace ScreenSound.API.Requests;

public record MusicaRequest(string nome, int anoLancamento, int artistaId, ICollection<GeneroRequest> Generos = null);

