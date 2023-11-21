using EcommerceProject.App.Data.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Radzen;
using System.Data.Entity;

namespace EcommerceProject.App.Pages.UserPages
{
    public partial class UserPage:ComponentBase
    {
      
        public List<User> users=new List<User>();
       


        protected override void OnInitialized()
        {
            users = userManager.Users.ToList();
           
            base.OnInitialized();

        }
    }
}
