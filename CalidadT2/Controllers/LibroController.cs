using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepository repository;
        private readonly AppBibliotecaContext app;

        public LibroController(AppBibliotecaContext app, ILibroRepository repository)
        {
            this.app = app;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = repository.Details(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            var user = repository.LoggedUser();
            repository.AddComentario(comentario,user.Id);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        //private Usuario LoggedUser()
        //{
        //    var claim = HttpContext.User.Claims.FirstOrDefault();
        //    var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
        //    return user;
        //}
    }
}
