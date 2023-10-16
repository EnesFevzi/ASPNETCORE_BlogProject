using ASPNETCORE_BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Dto.DTO_s.Users
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public List<AppRole> Roles { get; set; }
    }
}
