//using ScreenSound.Modelos;

namespace ScreenSoundWEB.Requests;

public record MusicaRequest(string Nome, int AnoLancamento, int artistaId, ICollection<GeneroRequest> Generos = null);

