using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IBliotecaRepository
    {
        public List<Biblioteca> VerBiblioteca(int id); 
        public void AddBiblioteca(int libro, int id);
        public void MarcarComoLeyendo(int libroId, int id);
        public void MarcarComoTerminado(int libroId, int id);
        public Usuario LoggedUser();
    }
    public class BibliotecaRepository : IBliotecaRepository
    {
        private readonly AppBibliotecaContext context;
        private HttpContext httpcontext;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public List<Biblioteca> VerBiblioteca(int id)
        {
            var model = context.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == id)
                .ToList();
            return model;
        }
        public void AddBiblioteca(int libro, int id)
        {          
            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = id,
                Estado = ESTADO.POR_LEER
            };

            context.Bibliotecas.Add(biblioteca);
            context.SaveChanges();

        }

        public void MarcarComoLeyendo(int libroId, int id)
        {
            var libro = context.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == id)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            context.SaveChanges();
        }

        public void MarcarComoTerminado(int libroId, int id)
        {
            var libro = context.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == id)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            context.SaveChanges();
        }
        public Usuario LoggedUser() 
        {
            var claim = httpcontext.User.Claims.FirstOrDefault();
            var user = context.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
