using Abp.Authorization;
using CmsFeature.Authorization.Roles;
using CmsFeature.Authorization.Users;

namespace CmsFeature.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
