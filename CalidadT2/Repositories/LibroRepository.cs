using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface ILibroRepository
    {
        public Libro Details(int id);
        public void AddComentario(Comentario comentario, int userId);
        public Usuario LoggedUser();
    }
    public class LibroRepository: ILibroRepository
    {
        private HttpContext httpcontext;
        private readonly AppBibliotecaContext context;

        public LibroRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public Libro Details(int id)
        {
            var model = context.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();

            return model;
        }
        public void AddComentario(Comentario comentario, int userId)
        {
            comentario.UsuarioId = userId;
            comentario.Fecha = DateTime.Now;
            context.Comentarios.Add(comentario);

            var libro = context.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

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
