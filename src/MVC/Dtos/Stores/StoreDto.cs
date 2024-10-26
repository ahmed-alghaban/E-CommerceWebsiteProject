using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Stores
{
    public class StoreDto
    {
        public Guid ID { get; set; }
        public string StoreName { get; set; }
        public Guid UserID { get; set; }
    }
}