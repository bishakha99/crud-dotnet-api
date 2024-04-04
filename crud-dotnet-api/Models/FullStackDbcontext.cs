using crud_dotnet_api.data;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Models
{
    public class FullStackDbcontext : DbContext
    {
        public FullStackDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Banks> Banks { get; set; }
        public DbSet<branches> branches { get; set; }

    }
}
