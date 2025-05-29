using Stock.Stock.Domain.InterfacesRepo;
using Stock.Stock.Domain.Models;
using Stock.Stock.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Stock.Stock.Infrastructure.Repo
{
    public class AuthRepository : IAuthRepository
    {
        private readonly StockDBContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthRepository(StockDBContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;   
        }

        public async Task<bool> EmailExistAsync(string email) { 
        
                return await _userManager.FindByEmailAsync(email) != null;
        }
        public async Task<bool> UsernameExistsAsync(string username) { 
        
                    return await _userManager.FindByNameAsync(username) != null;
        }
    }
}
