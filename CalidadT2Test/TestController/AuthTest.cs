using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositories;
using CalidadT2.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.TestController
{
    public class AuthTest
    {
        [Test]
        public void TestLoginPostFail()
        {

            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Login("admin", "1234")).Returns((Usuario)null);
            var controller = new AuthController(mock.Object,null,null);

            var result = controller.Login("admin", "1234") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestLoginPostSuccess()
        {

            var mock = new Mock<IAuthRepository>();
            mock.Setup(o => o.Login("admin", "admin")).Returns(new Usuario());

            var authMock = new Mock<IAuthService>();

            var controller = new AuthController(mock.Object, authMock.Object, null);

            var result = controller.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}
