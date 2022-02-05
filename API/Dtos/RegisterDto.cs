using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos {
    public class RegisterDto {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression ("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Password must have 1 Uppercase,1 lowercase ,1 number non alphanumeric and at les at 5 charcatores")]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Introduction { get; set; }

       [Required]
        public string KnownAs { get; set; }

        [Required]
        public string Interests { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}