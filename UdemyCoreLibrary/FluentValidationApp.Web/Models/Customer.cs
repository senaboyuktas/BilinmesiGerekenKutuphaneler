using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

        // Customer.Address[i].Id
        public IList<Address> Addresses { get; set; }
    }
}
