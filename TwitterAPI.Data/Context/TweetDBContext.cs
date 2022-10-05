using Microsoft.EntityFrameworkCore;
using TwitterAPI.Domain.Model;

namespace TwitterAPI.Data.Context
{
    public class TweetDbContext : DbContext
    {
        public DbSet<Tweet>? Tweets { get; set; }
        public DbSet<TweetAggregatedStatistic>? TweetAggregatedStatistics { get; set; }
        public DbSet<TweetHashtagsAggregatedStatistic>? TweetHashtagsAggregatedStatistics { get; set; }

        public TweetDbContext(DbContextOptions<TweetDbContext> options)
            : base(options)
        {
            //below migrate strategy is not suitable
            //for production environment
            //See here possible migration strategies
            //https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli
            //run following commands from package management console for adding migrations and updates after model changes
            //Add-Migration migration-02
            //Update-Database -Verbose
            Database.Migrate();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "TweetDb_InMemory");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>()
               .HasData(
               new Tweet()
               {
                   Id = 1,
                   Title = "Tweet 1",
                   Date = DateTimeOffset.UtcNow,
                   Hashtag = "#hello"
               },
               new Tweet()
               {
                   Id = 2,
                   Title = "Tweet 2",
                   Date = DateTimeOffset.UtcNow,
                   Hashtag = "#world"
               },
               new Tweet()
               {
                   Id = 3,
                   Title = "Tweet 3",
                   Date = DateTimeOffset.UtcNow,
                   Hashtag = "#news"
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}
