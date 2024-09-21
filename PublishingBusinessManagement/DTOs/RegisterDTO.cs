using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PublishingBusinessManagement.DTOs
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}