using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly WastelessDbContext _context;

        public UserRepository(WastelessDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Boolean> IsDuplicateUser(User user)
        {
            return await _context.Users.Where(dbUser => dbUser.Email == user.Email).AnyAsync();
        }

        public async Task<User> GetValidUser(User user)
        {
            return await _context.Users.Where(dbUser => dbUser.Email == user.Email && dbUser.Password == user.Password).FirstOrDefaultAsync();
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
