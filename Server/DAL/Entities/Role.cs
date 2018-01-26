using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 200)]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}