using Application.Common.Constants;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            context.ChatRoles.Add(new ChatRole { Name = ChatRoleConstants.UserRole });
            context.ChatRoles.Add(new ChatRole { Name = ChatRoleConstants.AdminRole });
            context.ChatRoles.Add(new ChatRole { Name = ChatRoleConstants.OwnerRole });

            context.Roles.Add(new IdentityRole { Name = UserRoleConstants.UserRole, NormalizedName = ChatRoleConstants.UserRole.ToUpper() });
            context.Roles.Add(new IdentityRole { Name = UserRoleConstants.AdminRole, NormalizedName = ChatRoleConstants.AdminRole.ToUpper() });

            // context.SaveChanges();
        }
    }
}
