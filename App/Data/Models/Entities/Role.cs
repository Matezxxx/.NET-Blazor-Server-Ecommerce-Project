using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace EcommerceProject.App.Data.Models.Entities
{
    public class Role:IdentityRole<int>
    {
       public Role() { }
        public Role(string roleName):base(roleName) { }
    }
}
