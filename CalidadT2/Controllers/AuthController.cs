using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Models;
using CalidadT2.Repositories;
using CalidadT2.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository repository;
        private readonly IAuthService AuthService;
        private readonly AppBibliotecaContext app;

        public AuthController(IAuthRepository repository, IAuthService AuthService,AppBibliotecaContext app)
        {
            this.app = app;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = repository.Login(username,password);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout()
        {
            AuthService.Logout();
            return RedirectToAction("Login");
        }
    }
}
