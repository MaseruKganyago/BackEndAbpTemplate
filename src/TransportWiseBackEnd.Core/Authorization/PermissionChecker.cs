using Abp.Authorization;
using TransportWiseBackEnd.Authorization.Roles;
using TransportWiseBackEnd.Authorization.Users;

namespace TransportWiseBackEnd.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
