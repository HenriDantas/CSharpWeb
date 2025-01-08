using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class MusicaDAL
    {
        private readonly ScreenSoundContext _context;
        
        public MusicaDAL(ScreenSoundContext context)
        {
            _context = context;
        }

        public IEnumerable<Musica> GetMusicas()
        {
            return _context.Musica.ToList();
        }

        public IEnumerable<Musica>GetMusicsByNameArtista(string nameArtista)
        {
            //fazer
            return _context.Musica.ToList();
        }
    }
}
