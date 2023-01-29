using System.ComponentModel.DataAnnotations;

namespace ApiRest.WebApi.DTOs
{
    public class RegisterUserRequestDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

