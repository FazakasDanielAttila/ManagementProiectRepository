using InchirieriAuto.Controllers;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace InchirieriAuto.Tests.Controllers
{
    public class AngajatiControllerTests
    {
        private Mock<IAngajatiRepository> mockRepo;
        private AngajatiController controller;

        public AngajatiControllerTests()
        {
            // Crearea mock-ului pentru IAngajatiRepository
            mockRepo = new Mock<IAngajatiRepository>();

            // Injectarea mock-ului în AngajatiController folosind constructorul suplimentar
            controller = new AngajatiController(mockRepo.Object);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfAngajatis()
        {
            // Arrange - configurarea mock-ului pentru a returna o listă de angajați
            var testAngajatis = GetTestAngajatis();
            mockRepo.Setup(repo => repo.GetAllAngajatis()).Returns(testAngajatis);

            // Act - apelarea metodei Index
            var result = controller.Index();

            // Assert - verificarea rezultatului
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<AngajatiModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);
        }

        private List<AngajatiModel> GetTestAngajatis()
        {
            return new List<AngajatiModel>
            {
                new AngajatiModel { IDAngajat = Guid.NewGuid(), Nume = "Test1", Prenume = "User1" },
                new AngajatiModel { IDAngajat = Guid.NewGuid(), Nume = "Test2", Prenume = "User2" },
            };
        }
    }
}
