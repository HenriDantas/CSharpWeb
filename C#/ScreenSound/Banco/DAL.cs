using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class DAL<T> where T : class
    {
        private readonly ScreenSoundContext _context;

        public DAL(ScreenSoundContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public T GetRegisterBy(Func<T, bool> condition)
        {
            return _context.Set<T>().FirstOrDefault(condition);
        }

        public IEnumerable<T> GetAll(Func<T, int?> condition)
        {
            return _context.Set<T>().OrderBy(condition).ToList();
        }

        public IEnumerable<T> GetAllBy(Func<T, bool> condition)
        {
            return _context.Set<T>().Where(condition).ToList();
        }
    }
}
