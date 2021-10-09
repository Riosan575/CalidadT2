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
            var user = repository.LoggedUser();
            var model = repository.VerBiblioteca(user.Id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            var user = repository.LoggedUser();
            repository.AddBiblioteca(libro,user.Id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            var user = repository.LoggedUser();

            repository.MarcarComoLeyendo(libroId,user.Id);

            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            var user = repository.LoggedUser();

            repository.MarcarComoLeyendo(libroId, user.Id);

            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        //private Usuario LoggedUser()
        //{
        //    var claim = HttpContext.User.Claims.FirstOrDefault();
        //    var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
        //    return user;
        //}
    }
}
