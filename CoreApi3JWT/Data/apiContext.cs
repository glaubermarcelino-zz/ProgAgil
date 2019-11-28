using CoreApi3JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApi3JWT.Data
{
    public class apiContext :DbContext
    {
        public apiContext(DbContextOptions<apiContext> options):base(options){}
        public DbSet<Users> Users { get; set; }
    }
}