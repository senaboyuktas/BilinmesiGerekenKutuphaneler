using System;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Name alanı boş olamaz. Attribute'dan geldi.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
