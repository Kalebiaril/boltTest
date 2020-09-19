using Microsoft.EntityFrameworkCore;

namespace SearchWebApi.DB
{
    public class SearchApiDbContext : DbContext
    {
        /// <summary>
        /// Collection of the all search results
        /// </summary>
        public DbSet<SearchData> SearchData { get; set; }


        public SearchApiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}