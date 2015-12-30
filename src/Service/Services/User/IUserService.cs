namespace Service.Core
{
    public interface IUserService
    {
        AspNetUserModel GetUser(string userId);
    }
}