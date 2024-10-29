using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Images
{
    public class ImageCreateDto
    {
        public string? ImageName { get; set; }

        [Required(ErrorMessage = "The image URL is Required")]
        public string Url { get; set; }

        [Required(ErrorMessage = "The product identity is Required")]
        public Guid ProductID { get; set; }
    }
}