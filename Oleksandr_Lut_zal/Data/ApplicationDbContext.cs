using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oleksandr_Lut_zal.Models;

namespace Oleksandr_Lut_zal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShopingPosition> ShopingPositions { get; set; }
        public DbSet<Oleksandr_Lut_zal.Models.ShoppingPositionList> ShoppingPositionList { get; set; } = default!;
    }
}
