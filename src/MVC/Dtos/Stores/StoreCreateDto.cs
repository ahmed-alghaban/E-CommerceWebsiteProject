using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Stores
{
    public class StoreCreateDto
    {
        [Required(ErrorMessage = "Store Name Is Required")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "User Is Required")]
        public Guid UserID { get; set; }
    }
}