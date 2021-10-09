using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalidadT2Test.TestRepositorios.Mocks
{
    public class AppBibliotecaContextMock
    {
        public static Mock<AppBibliotecaContext> GetApplicationContextMock()
        {
            IQueryable<Usuario> userData = GetUserData();

            var mockDbSetUser = new Mock<DbSet<Usuario>>();
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());
            mockDbSetUser.Setup(m => m.AsQueryable()).Returns(userData);


            var mockContext = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            mockContext.Setup(c => c.Usuarios).Returns(mockDbSetUser.Object);

            return mockContext;
        }
        private static IQueryable<Usuario> GetUserData()
        {
            return new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin", Password = "admin", Nombres = "Luis" },
                new Usuario { Id = 2, Username = "user1", Password = "user1", Nombres = "Luis" },
                new Usuario { Id = 3, Username = "user2", Password = "user2", Nombres = "Luis" },
                new Usuario { Id = 4, Username = "user3", Password = "user3", Nombres = "Luis" },
                new Usuario { Id = 5, Username = "user4", Password = "user4", Nombres = "Luis"},
                new Usuario { Id = 6, Username = "admin2", Password = "admin2", Nombres = "Luis" },
            }.AsQueryable();
        }
    }
}
