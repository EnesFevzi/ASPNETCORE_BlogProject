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
        public Guid ImageID { get; set; } = Guid.Parse("4084c97a-2aa1-4675-b519-69f6fe410633");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
