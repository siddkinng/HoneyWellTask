using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserHoneyWell.Models
{
    public class Users
    {
        [Required]
        public int Userid { get; set; }
        [Required]

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        [Required]

        public string UserName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

    }
}
