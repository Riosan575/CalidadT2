using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IHomeRepository
    {
        public List<Libro> VerLibros();
    }
    public class HomeRepository : IHomeRepository
    {
        private AppBibliotecaContext context;
        public HomeRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public List<Libro> VerLibros()
        {
            var libros = context.Libros.Include(o => o.Autor).ToList();

            return libros;
        }
    }
}
