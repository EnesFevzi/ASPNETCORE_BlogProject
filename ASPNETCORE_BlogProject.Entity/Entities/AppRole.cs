﻿using ASPNETCORE_BlogProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
    public class AppRole : IdentityRole<int>,IEntityBase
    {
    }
}
