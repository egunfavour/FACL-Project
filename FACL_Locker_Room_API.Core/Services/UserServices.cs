using FACL_Locker_Room_API.Core.DTOs;
using FACL_Locker_Room_API.Core.Interfaces;
using FACL_Locker_Room_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FACL_Locker_Room_API.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IReadWritetoJson readWritetoJson;
        private readonly string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"FACL_Locker_Room_API.Infrastructure\Account\");
        
        public UserServices(IReadWritetoJson readWritetoJson)
        {
            this.readWritetoJson = readWritetoJson;
        }

        public async Task<ResponseDTO> CreateAccount(CreateAccountDTO user)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            List<UserModel> newUser = new List<UserModel>();
            newUser.Add(new UserModel()
            {
                Id = Guid.NewGuid().ToString(),
                LastName = user.LastName,
                FirstName = user.FirstName,
                Nationality = user.Nationality,
                Gender = user.Gender,
                DateOfBirth = new DateTime(user.DateOfBirth.year, user.DateOfBirth.month, user.DateOfBirth.day)
            }) ;
            string curFile = $@"{filePath}{user.FirstName}-{user.LastName}.json";
            if (File.Exists(curFile))
            {
                responseDTO.Message = "Account already exist";
                responseDTO.StatusCode = (int)HttpStatusCode.BadRequest;
                return responseDTO;
            }
            else
            {
                await readWritetoJson.WriteAllToJson<List<UserModel>>(newUser, curFile);

                responseDTO.Message = "Account Created";
                responseDTO.StatusCode = (int)HttpStatusCode.OK;
                return responseDTO;
            }  
        }

        public async Task<UserModel> GetAcccount(GetAccountDTO user)
        {
            string curFile = $@"{filePath}{user.FirstName}-{user.LastName}.json";
            if (File.Exists(curFile))
            {
                var account = await readWritetoJson.ReadAllFromJson<UserModel>(curFile);
                var userObj = account.Where(x => x.FirstName == user.FirstName && x.LastName == user.LastName).FirstOrDefault();
                return userObj;
            }
            else
            {
                return null;
            }
        }
    }
}
