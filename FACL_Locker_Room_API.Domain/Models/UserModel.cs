using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACL_Locker_Room_API.Domain.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }    
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
