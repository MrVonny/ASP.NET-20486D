using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using ButterfliesShop.Validators;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Pls enter the butterfly nae")]
        [Display(Name = "Common Name:")]
        public string CommonName { get; set; }
        [Required(ErrorMessage = "Please select the butterfly family")]
        [Display(Name = "Butterfly Family:")]
        public Family? ButterflyFamily { get; set; }
        [Display(Name = "Butterfly Quantity")]
        [Required(ErrorMessage = "Please select the butterfly quantity")]
        [MaxButterflyQuantityValidation(50)]
        public int? Quantity { get; set; }
        [Display(Name = "Characteristics:")]
        [Required(ErrorMessage = "Please type the characteristics")]
        [StringLength(50)]
        public string Characteristics { get; set; }
        [Display(Name = "Updated On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }
        [Display(Name ="Butterfly Picture:")]
        [Required(ErrorMessage = "Please select the butterflies picture")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }

    }
}
