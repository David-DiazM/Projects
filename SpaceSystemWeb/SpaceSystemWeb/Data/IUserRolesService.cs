namespace SpaceSystemWeb.Data
{
    public interface IUserRolesService
    {
        Task EnsureAdminUserRole(string email);
    }
}