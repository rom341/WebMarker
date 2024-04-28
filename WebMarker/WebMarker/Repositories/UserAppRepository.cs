using Microsoft.EntityFrameworkCore;
using WebMarker.Data;
using WebMarker.Interfaces;
using WebMarker.Models;

namespace WebMarker.Repositories
{
    public class UserAppRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserAppRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddUser(AppUser user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(AppUser user)
        {
            _context.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
           return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser> GetUserByEmailAsync(string Email)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == Email);
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<AppUser> GetUserByLoginAsync(string Login)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName == Login);
        }

        public async Task<AppUser> GetUserByPasswordAsync(string Password)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Password == Password);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateUser(AppUser user)
        {
            _context.Update(user);
            return Save();
        }
    }
}
