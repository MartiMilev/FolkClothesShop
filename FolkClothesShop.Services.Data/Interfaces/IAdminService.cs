using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<string?> AdminIdByUserIdAsync(string userId);
        Task<bool> AdminExistsByUserIdAsync(string userId);

    }
}
