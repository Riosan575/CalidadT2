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
    public class HomeTest
    {
        [Test]
        public void HomeTestCaso01()
        {
            var mockrepository = new Mock<IHomeRepository>();
            mockrepository.Setup(o => o.VerLibros()).Returns(new List<Libro>());
            var controller = new HomeController(mockrepository.Object, null);
            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
