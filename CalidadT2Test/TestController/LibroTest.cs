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
    public class LibroTest
    {
        [Test]
        public void LibroDetailsCaso01()
        {
            var mockrepository = new Mock<ILibroRepository>();
            mockrepository.Setup(o => o.Details(1)).Returns(new Libro() { Id = 1 });
            mockrepository.Setup(o => o.LoggedUser()).Returns(new Usuario()); ;

            var controller = new LibroController(null, mockrepository.Object);
            var view = controller.Details(1) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void LibroAddComentarioCaso02()
        {
            var mockrepository = new Mock<ILibroRepository>();
            mockrepository.Setup(o => o.AddComentario(new Comentario(), 1));
            mockrepository.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 1 }); ;

            var controller = new LibroController(null, mockrepository.Object);
            var view = controller.AddComentario(new Comentario()) as RedirectToActionResult;
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
