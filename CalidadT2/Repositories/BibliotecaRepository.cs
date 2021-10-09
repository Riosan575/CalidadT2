using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IBliotecaRepository
    {
        public Biblioteca Add(int libro);
        public void MarcarComoLeyendo(int libroId);
        public void MarcarComoTerminado(int libroId);
        public Usuario LoggedUser();

    }
    public class BibliotecaRepository : IBliotecaRepository
    {
        private readonly AppBibliotecaContext context;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public Biblioteca Add(int libro)
        {
            Usuario user = LoggedUser();

            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            return biblioteca;

        }

        public void MarcarComoLeyendo(int libroId)
        {
            throw new NotImplementedException();
        }

        public void MarcarComoTerminado(int libroId)
        {
            throw new NotImplementedException();
        }
        public Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
