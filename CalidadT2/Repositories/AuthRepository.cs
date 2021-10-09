using CalidadT2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IAuthRepository
    {
        Usuario Login(string username, string password);
    }
    public class AuthRepository : IAuthRepository
    {
        private readonly AppBibliotecaContext context;

        public AuthRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public Usuario Login(string username, string password)
        {
            return context.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }
    }
}
