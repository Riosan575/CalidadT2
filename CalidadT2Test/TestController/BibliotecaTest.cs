using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.TestController
{
    public class BibliotecaTest
    {
        [Test]
        public void MostrarLibrosEnBibliotecaCaso01()
        {
            var Mockrepo = new Mock<IBliotecaRepository>();
            Mockrepo.Setup(o => o.VerBiblioteca(1)).Returns(new List<Biblioteca>());
            Mockrepo.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 1 });
            var controller = new BibliotecaController(Mockrepo.Object, null);
            var view = controller.Index() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AgregarLibroEnBibliotecaCaso02()
        {
            var Mockrepo = new Mock<IBliotecaRepository>();
            Mockrepo.Setup(o => o.AddBiblioteca(1, 1));
            Mockrepo.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 1 });

            var controller = new BibliotecaController(Mockrepo.Object, null);
            var view = controller.Add(1) as RedirectToActionResult;
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void MarcarComoLeyendoCaso03()
        {
            var Mockrepo = new Mock<IBliotecaRepository>();
            Mockrepo.Setup(o => o.MarcarComoLeyendo(1, 1));
            Mockrepo.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 1 });

            var controller = new BibliotecaController(Mockrepo.Object, null);
            var view = controller.MarcarComoLeyendo(1) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void MarcarComoTerminadoCaso04()
        {
            var Mockrepo = new Mock<IBliotecaRepository>();
            Mockrepo.Setup(o => o.MarcarComoTerminado(1, 1));
            Mockrepo.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 1 });

            var controller = new BibliotecaController(Mockrepo.Object, null);
            var view = controller.MarcarComoTerminado(1) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
