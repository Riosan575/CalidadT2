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
        public void AddComentario(Comentario comentario);
    }
    public class LibroRepository: ILibroRepository
    {
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
        public void AddComentario(Comentario comentario)
        {
            throw new NotImplementedException();
        } 
    }
}
