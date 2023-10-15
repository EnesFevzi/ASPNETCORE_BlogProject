using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageID { get; set; } = Guid.Parse("F71F4B9A-AA60-461D-B398-DE31001BF214");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
