using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcomPortal.Models.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required, StringLength(100, ErrorMessage = "Name must be between 1 and 100 characters.")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address."), StringLength(100)]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number."), StringLength(13)]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}