using FACL_Locker_Room_API.Core.DTOs;
using FACL_Locker_Room_API.Domain.Models;

namespace FACL_Locker_Room_API.Core.Interfaces
{
    public interface IUserServices
    {
        Task<ResponseDTO> CreateAccount(CreateAccountDTO user);
        Task<UserModel> GetAcccount(GetAccountDTO user);
       
    }
}