using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjWork.Entities.User
{
    [Index(nameof(Email), IsUnique = true)]
    public class User:BaseEntities
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public int PhoneNum { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
