using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System.Text.RegularExpressions;

namespace SpaceSystemWeb.Data
{
    public class UserRolesService : IUserRolesService
    {
        public const string ADMIN_ROLE_NAME = "Admin";
        public string ADMIN_USER_EMAIL;
        private const string EMAIL_PATTERN = "@spacesystem.com";
        private const string ADMIN_USER_PWD = "Password1!";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRolesService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private async Task EnsureRoles()
        {
            var existingRole = await _roleManager.FindByNameAsync(ADMIN_ROLE_NAME);
            if (existingRole is null)
            {
                var adminRole = new IdentityRole()
                {
                    Name = ADMIN_ROLE_NAME,
                    NormalizedName = ADMIN_ROLE_NAME.ToUpper()
                };
                await _roleManager.CreateAsync(adminRole);
            }
        }

        private async Task EnsureUsers()
        {
            if(!ADMIN_USER_EMAIL.Contains(EMAIL_PATTERN))
            {
                throw new InvalidOperationException("Cannot add  null user/role combination");
            }

            var existingAdminUser = await _userManager.FindByEmailAsync(ADMIN_USER_EMAIL);
            if (existingAdminUser is null)
            {
                var adminUser = new IdentityUser()
                {
                    Email = ADMIN_USER_EMAIL,
                    EmailConfirmed = true,
                    UserName = ADMIN_USER_EMAIL,
                    NormalizedEmail = ADMIN_USER_EMAIL.ToUpper(),
                    NormalizedUserName = ADMIN_USER_EMAIL.ToUpper(),
                    LockoutEnabled = false
                };

                await _userManager.CreateAsync(adminUser, ADMIN_USER_PWD);
            }
        }

        public async Task EnsureAdminUserRole(string email)
        {
            ADMIN_USER_EMAIL = email;

            //ensure roles
            await EnsureRoles();

            //ensure users
            await EnsureUsers();

            var existingAdminUser = await _userManager.FindByEmailAsync(ADMIN_USER_EMAIL);
            var existingRole = await _roleManager.FindByNameAsync(ADMIN_ROLE_NAME);
            if (existingAdminUser is null || existingRole is null)
            {
                throw new InvalidOperationException("Cannot add  null user/role combination");
            }

            var userRoles = await _userManager.GetRolesAsync(existingAdminUser);
            var existingUserAdminRole = userRoles.SingleOrDefault(x => x.Equals(ADMIN_ROLE_NAME));

            if (existingUserAdminRole is null)
            {
                await _userManager.AddToRoleAsync(existingAdminUser, ADMIN_ROLE_NAME);
            }
        }
    }
}