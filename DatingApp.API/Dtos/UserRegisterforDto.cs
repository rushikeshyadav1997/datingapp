using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserRegisterforDto
    {   [Required]
        public string Username{get;set;}
        [Required]
        [StringLength(8,MinimumLength =4,ErrorMessage ="length must in between 4 to 8")]
        public string  Password { get; set; }
    }
}