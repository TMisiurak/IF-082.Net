using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2,120)]
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required, Range(1, 120)]
        public string Password { get; set; }
        [Required, Range(1, 3)]
        public string Sex { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }
        [Required, Range(1, 300)]
        public string Address { get; set; }
        [Required]
        public string Image { get; set; }
        [Required, Range(1, 15)]
        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }   
    }
}