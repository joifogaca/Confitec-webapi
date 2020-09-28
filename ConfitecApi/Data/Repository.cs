using ConfitecApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfitecApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Usuario[]> GetAllUsuarioAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;


            query = query.Include(u => u.Escolaridade);

            

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }

        public Task<Escolaridade[]> GetAllEscolaridadeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuarioById(int usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios;


            query = query.Include(u => u.Escolaridade);



            query = query.AsNoTracking()
                         .OrderBy(c => c.id)
                         .Where(user => user.id == usuarioId);
                         

            return await query.FirstOrDefaultAsync();
        }
    }
}
