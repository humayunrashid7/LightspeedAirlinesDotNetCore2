using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LightspeedAirlinesDotNetCore2.Entities
{
    public class UserRoleEntity : IdentityRole<Guid>
    {
        public UserRoleEntity() : base()
        {
        }

        public UserRoleEntity(string roleName) : base(roleName)
        {
        }
    }
}
