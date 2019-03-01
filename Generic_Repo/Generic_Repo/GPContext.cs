using Microsoft.EntityFrameworkCore;

namespace Generic_Repo
{
    public class GPContext : DbContext
    {
        public GPContext(DbContextOptions<GPContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
