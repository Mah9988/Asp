using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace elecpro.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
