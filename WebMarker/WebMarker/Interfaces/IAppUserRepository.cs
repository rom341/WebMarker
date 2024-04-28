using WebMarker.Models;

namespace WebMarker.Interfaces
{
    public interface IAppUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserByIdAsync(string id);
        Task<AppUser> GetUserByLoginAsync(string Login);
        Task<AppUser> GetUserByPasswordAsync(string Password);
        Task<AppUser> GetUserByEmailAsync(string Email);
        bool AddUser(AppUser user);
        bool UpdateUser(AppUser user);
        bool DeleteUser(AppUser user);
        bool Save();
    }
}
