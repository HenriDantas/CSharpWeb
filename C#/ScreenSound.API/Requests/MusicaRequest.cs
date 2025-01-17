using ScreenSound.Modelos;

namespace ScreenSound.API.Requests;

public record MusicaRequest(string Nome, int AnoLancamento, int artistaId, ICollection<GeneroRequest> Generos = null);

