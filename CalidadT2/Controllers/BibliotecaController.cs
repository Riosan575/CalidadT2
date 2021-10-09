using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly IBliotecaRepository repository;
        private readonly AppBibliotecaContext app;

        public BibliotecaController(IBliotecaRepository repository, AppBibliotecaContext app)
        {
            this.repository = repository;
            this.app = app;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var model = app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == user.Id)
                .ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();
            repository.AddBiblioteca(libro,user.Id);
            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();

            var libro = app.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            app.SaveChanges();

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

            var libro = app.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            app.SaveChanges();

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
