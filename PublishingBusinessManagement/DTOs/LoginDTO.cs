using System.ComponentModel.DataAnnotations;

namespace PublishingBusinessManagement.DTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
