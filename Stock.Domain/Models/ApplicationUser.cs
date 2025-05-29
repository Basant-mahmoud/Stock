using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Stock.Stock.Domain.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    
    }
}
