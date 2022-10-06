using Microsoft.EntityFrameworkCore;
using TwitterAPI.Domain.Model;

namespace TwitterAPI.Data.Context
{
    public class TweetDbContext : DbContext
    {
        public DbSet<Tweet>? Tweets { get; set; }
        public DbSet<TweetHashtag>? TweetHashtags { get; set; }        
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tweet>()
               .HasData(
               new Tweet()
               {
                   Id = 1,
                   Text = "Tweet 1",
                   Date = DateTimeOffset.UtcNow
               },
               new Tweet()
               {
                   Id = 2,
                   Text = "Tweet 2",
                   Date = DateTimeOffset.UtcNow
               },
               new Tweet()
               {
                   Id = 3,
                   Text = "Tweet 3",
                   Date = DateTimeOffset.UtcNow                     
               }
               );

            modelBuilder.Entity<TweetHashtag>()
                .HasData(
                new TweetHashtag() 
                { 
                    Id = 1,
                    TweetId = 1,
                    Hashtag = "#hello1" 
                },
                new TweetHashtag() 
                {
                    Id = 2,
                    TweetId = 1,
                    Hashtag = "#hello2" 
                },
                new TweetHashtag() 
                {
                    Id = 3,
                    TweetId = 1,
                    Hashtag = "#hello3" 
                },
                new TweetHashtag() 
                {
                    Id = 4,
                    TweetId = 2,
                    Hashtag = "#world1" 
                },
                new TweetHashtag() 
                {
                    Id = 5,
                    TweetId = 2,
                    Hashtag = "#world2" 
                },
                new TweetHashtag() 
                {
                    Id = 6,
                    TweetId = 2,
                    Hashtag = "#world3" 
                },
                new TweetHashtag() 
                {
                    Id = 7,
                    TweetId = 3,
                    Hashtag = "#news1" 
                },
                new TweetHashtag() 
                {
                    Id = 8,
                    TweetId = 3,
                    Hashtag = "#news2" 
                },
                new TweetHashtag() 
                {
                    Id = 9,
                    TweetId = 3,
                    Hashtag = "#news3" 
                }
                );            
        }
    }
}
