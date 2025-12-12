using OrbitOps.API.Models;

namespace OrbitOps.API.Services
{
    public static class PermissionMap
    {
        public static void ApplyRolePermissions(User user)
        {
            switch (user.Role)
            {
                case "Admin":
                    user.CanRead = true;
                    user.CanCreate = true;
                    user.CanUpdate = true;
                    user.CanDelete = true;
                    break;

                case "Gerente":
                    user.CanRead = true;
                    user.CanCreate = true;
                    user.CanUpdate = true;
                    user.CanDelete = false;
                    break;

                case "Colaborador":
                    user.CanRead = true;
                    user.CanCreate = true;
                    user.CanUpdate = false;
                    user.CanDelete = false;
                    break;

                case "Leitor":
                default:
                    user.CanRead = true;
                    user.CanCreate = false;
                    user.CanUpdate = false;
                    user.CanDelete = false;
                    break;
            }
        }
    }
}
