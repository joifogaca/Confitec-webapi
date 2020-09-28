using ConfitecApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfitecApi.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //USUARIO
        Task<Usuario[]> GetAllUsuarioAsync();

        Task<Escolaridade[]> GetAllEscolaridadeAsync();

        Task<Usuario> GetUsuarioById(int usuarioId);


    }
}
