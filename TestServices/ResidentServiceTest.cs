using NUnit.Framework;
using System.Collections.Generic;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Services;

namespace TestServices
{
    public class ResidentServiceTest
    {
        private readonly IResidentService residentService;

        public ResidentServiceTest(IResidentService residentService)
        {
            this.residentService = residentService;
        }

        [Test]
        public void Test1()
        {
            var resident = new CreateResidentDTO();
            resident.Name = "Esteban";
            resident.LastName = "Beltran";
            resident.Phone = "3208858185";
            resident.AddressList = new List<CreateAddressDTO>();
            resident.User.Email = "esbeab11@gmail.com";
            resident.User.Password = "Aa_12345";
            resident.User.State = true;
            resident.User.Role = "isResident";

            residentService.Insert(resident);
            Assert.Pass();
        }
    }
}