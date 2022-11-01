using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACL_Locker_Room_API.Core.DTOs
{
    public class DateOnlyDTO
    {
        [Range(1922,2023, ErrorMessage = "enter a valid year")]
        public int year { get; set; }
        [Range(1, 12, ErrorMessage = "enter a valid month")]
        public int month { get; set; }
        [Range(1,30, ErrorMessage="enter a valid day")]
        public int day { get; set; }
    }
}
