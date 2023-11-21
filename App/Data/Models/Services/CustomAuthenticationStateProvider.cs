using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using System.Security.Claims;
using EcommerceProject.App.Data.Models.Entities;

namespace EcommerceProject.App.Data.Models.Services
{
    public class CustomAuthenticationStateProvider : RevalidatingServerAuthenticationStateProvider
    {
        private UserManager<User> _userManager { get; set; }
        public CustomAuthenticationStateProvider(ILoggerFactory loggerFactory, UserManager<User> userManager) : base(loggerFactory)
        {
            _userManager = userManager;
        }

        protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(1);

        protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            var user = authenticationState.User;
            var appUser = await _userManager.FindByNameAsync(user.Identity.Name);

            return appUser != null;
        }
    }
}
