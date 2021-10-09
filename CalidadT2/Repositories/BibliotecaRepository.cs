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
        public void AddBiblioteca(int libro, int id);
        public void MarcarComoLeyendo(int libroId);
        public void MarcarComoTerminado(int libroId);
    }
    public class BibliotecaRepository : IBliotecaRepository
    {
        private readonly AppBibliotecaContext context;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            this.context = context;
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

        public void MarcarComoLeyendo(int libroId)
        {
            throw new NotImplementedException();
        }

        public void MarcarComoTerminado(int libroId)
        {
            throw new NotImplementedException();
        }
    }
}
