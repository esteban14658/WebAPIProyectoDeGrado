using WebAPIProyectoDeGrado.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PG.PresentationTests;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Repositories;
using WebAPIProyectoDeGrado.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIProyectoDeGrado.Controllers.Tests
{
    [TestClass()]
    public class ResidentControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            CreateResidentDTO createResidentDTO = new();
            CreateUserDTO createUserDTO = new();
            createResidentDTO.Name = "Juan";
            createResidentDTO.LastName = "Diaz";
            createResidentDTO.Phone = "3213213211";
            createResidentDTO.AddressList = new List<CreateAddressDTO>();
            createUserDTO.Email = "esteb_12@hotmail.com";
            createUserDTO.Password = "Aa_12345";
            createUserDTO.State = true;
            createUserDTO.Role = "isResident";
            createResidentDTO.User = createUserDTO;
            var mockService = new Mock<IResidentService>();
            var mockRepo = new Mock<IResidentRepository>();
            var controller = new ResidentController(mockService.Object);
            mockRepo.Setup(repo => repo.ExistUserByEmail(createResidentDTO.User.Email)).Returns(false);
            mockService.Setup(ser => ser.Insert(createResidentDTO)).ReturnsAsync(createResidentDTO);
            ActionResult result = controller.Post(createResidentDTO).Result;
            Assert.AreEqual(createResidentDTO.Name, "Juan");
        }

        [TestMethod()]
        public void PutTest()
        {
            ResidentDTO residentDTO = new ResidentData().BuildResidentDTO(1);

            var mockService = new Mock<IResidentService>();
            var mockRepo = new Mock<IResidentRepository>();

            mockRepo.Setup(repo => repo.Exists(residentDTO.Id)).Returns(true);
            mockService.Setup(ser => ser.Update(residentDTO, residentDTO.Id)).ReturnsAsync(residentDTO);

            Assert.AreEqual(1, residentDTO.User.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int id = 1;
            var mockRepo = new Mock<IResidentRepository>();
            var mockService = new Mock<IResidentService>();

            mockRepo.Setup(repo => repo.DeleteAddressList(id));
            mockRepo.Setup(repo => repo.DeleteUser(id));
            mockRepo.Setup(repo => repo.Delete(id));
            mockService.Setup(ser => ser.DeleteAll(id));

            Assert.AreEqual(1, id);
        }

        [TestMethod()]
        public void GetUserByEmailTest()
        {
            ResidentDTO resident = new ResidentData().BuildResidentDTO(1);
            var mockRepo = new Mock<IResidentRepository>();
            var mockService = new Mock<IResidentService>();
            mockRepo.Setup(repo => repo.ExistUserByEmail(resident.User.Email)).Returns(true);
            mockService.Setup(ser => ser.GetUserByEmail(resident.User.Email)).Returns(Task.FromResult(resident));

            Assert.AreEqual(1, resident.Id);
        }

        [TestMethod()]
        public void GetUserByIdTest()
        {
            ResidentDTO resident = new ResidentData().BuildResidentDTO(1);
            var mockRepo = new Mock<IResidentRepository>();
            var mockService = new Mock<IResidentService>();
            mockRepo.Setup(repo => repo.ExistUserById(resident.User.Id)).Returns(true);
            mockService.Setup(ser => ser.GetUserById(resident.User.Id)).Returns(Task.FromResult(resident));

            Assert.AreEqual(1, resident.Id);
        }
    }
}