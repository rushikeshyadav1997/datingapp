using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserRegisterforDto
    {   [Required]
        public string Username{get;set;}
        [Required]
        [StringLength(8,MinimumLength =4,ErrorMessage ="length must in between 4 to 8")]
        public string  Password { get; set; }
         [Required]
        public string Gender { get; set; }

        [Required]
        public string KnownAs { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public UserRegisterforDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
    
}