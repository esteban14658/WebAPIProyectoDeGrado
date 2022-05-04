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
using WebAPIProyectoDeGrado.Entitys;
using PG.Bussiness.DTOs;

namespace WebAPIProyectoDeGrado.Controllers.Tests
{
    [TestClass()]
    public class ResidentControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            CreateResidentDto createResidentDTO = new();
            CreateUserDto createUserDTO = new();
            createResidentDTO.Name = "Juan";
            createResidentDTO.LastName = "Diaz";
            createResidentDTO.Phone = "3213213211";
            createResidentDTO.AddressList = new List<CreateAddressDto>();
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
            ResidentDto residentDTO = new ResidentData().BuildResidentDTO(1);

            var mockService = new Mock<IResidentService>();
            var mockRepo = new Mock<IResidentRepository>();
            var controller = new ResidentController(mockService.Object);
            mockRepo.Setup(repo => repo.Exists(residentDTO.Id)).Returns(true);
            mockService.Setup(ser => ser.Update(residentDTO, residentDTO.Id)).ReturnsAsync(residentDTO);
            ActionResult result = controller.Put(residentDTO, 1).Result;
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
            ResidentDto resident = new ResidentData().BuildResidentDTO(1);
            var mockRepo = new Mock<IResidentRepository>();
            var mockService = new Mock<IResidentService>();
            mockRepo.Setup(repo => repo.ExistUserByEmail(resident.User.Email)).Returns(true);
            mockService.Setup(ser => ser.GetUserByEmail(resident.User.Email)).Returns(Task.FromResult(resident));

            Assert.AreEqual(1, resident.Id);
        }

        [TestMethod()]
        public void GetUserByIdTest()
        {
            ResidentDto resident = new ResidentData().BuildResidentDTO(1);
            var mockRepo = new Mock<IResidentRepository>();
            var mockService = new Mock<IResidentService>();
            var controller = new ResidentController(mockService.Object);
            mockRepo.Setup(repo => repo.ExistUserById(resident.User.Id)).Returns(true);
            mockService.Setup(ser => ser.GetUserById(resident.User.Id)).Returns(Task.FromResult(resident));
            bool result = controller.GetUserById(1).IsCompleted;
            Assert.IsTrue(result);
            Assert.AreEqual(1, resident.Id);
        }

        [TestMethod()]
        public void GetTest()
        {
            List<ResidentDto> residents = new ResidentData().BuildListResidentDTO();
            List<Resident> list = new();
            PaginateDto<ResidentDto> paginate = new();
            paginate.Records = residents;
            paginate.NumberOfRecords = residents.Count;
            paginate.Page = 0;
            paginate.Size = 10;
            var mockRepo = new Mock<IResidentRepository>();
            var mockService = new Mock<IResidentService>();
            var controller = new ResidentController(mockService.Object);
            mockRepo.Setup(repo => repo.GetAll()).Returns(Task.FromResult(list));
            mockService.Setup(ser => ser.GetAll(0, 10)).Returns(Task.FromResult(paginate));
            bool result = controller.Get(0, 10).IsCompleted;
            Assert.IsTrue(result);
            Assert.AreEqual(4, paginate.NumberOfRecords);
        }
    }
}