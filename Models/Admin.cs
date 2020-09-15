using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWorksHere.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string Email { get; set; }

        [Column(TypeName = "Varchar(10)")]
        public string Password { get; set; }
    }
}
