using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.PresentationTests
{
    public class ResidentData
    {
        public CreateResidentDto BuildCreateResidentDTO()
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
            return createResidentDTO;
        }

        public ResidentDto BuildResidentDTO(int index)
        {
            ResidentDto residentDTO = new();
            UserDto userDTO = new();
            residentDTO.Id = index;
            residentDTO.Name = "Juan";
            residentDTO.LastName = "Diaz";
            residentDTO.Phone = "3213213211";
            residentDTO.AddressList = new List<AddressDto>();
            userDTO.Id = index;
            userDTO.Email = "esteb_12" + index + "@hotmail.com";
            userDTO.State = true;
            userDTO.Role = "isResident";
            residentDTO.User = userDTO;
            return residentDTO;
        }

        public List<ResidentDto> BuildListResidentDTO()
        {
            List<ResidentDto> list = new();
            for (int i = 0; i < 4; i++)
            {
                list.Add(BuildResidentDTO(i));
            }
            return list;
        }
    }
}
