using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Images
{
    public class ImageDto
    {
        public Guid ID { get; set; }
        public string ImageName { get; set; }
        public string Url { get; set; }
        public Guid ProductID { get; set; }
        public Product AssociatedProduct { get; set; }
    }
}