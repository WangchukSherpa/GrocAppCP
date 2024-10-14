using ProjWork.Repo.Interface;
using ProjWork.Data;
using ProjWork.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProjWork.Entities.Order;

namespace ProjWork.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly ProductDbContext _context;

        public UserRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<Address> GetUserStoredAddressAsync(string email)
        {
            // Assuming you have access to a DbContext
            var user = await _context.Users
                .Include(u => u.Address) // Include the address
                .FirstOrDefaultAsync(u => u.Email == email);

            return user?.Address; // Return the address if user exists
        }

    }
}
