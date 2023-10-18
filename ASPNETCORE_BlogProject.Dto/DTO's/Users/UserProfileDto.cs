using ASPNETCORE_BlogProject.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace ASPNETCORE_BlogProject.Dto.DTO_s.Users
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public IFormFile? Photo { get; set; }
        public Image Image { get; set; }
    }
}
