using FolkClothesShop.Data;
using FolkClothesShop.Data.Entity;
using FolkClothesShop.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Services.Data
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext dbContext;
        public AdminService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> AdminExistsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
                .Admins
                .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }

        public async Task<string?> AdminIdByUserIdAsync(string userId)
        {
            Admin? admin = await this.dbContext.Admins.FirstOrDefaultAsync(x => x.UserId == userId);
            if (admin == null)
            {
                return null;
            }
            return admin.Id.ToString();
        }
    }
}
