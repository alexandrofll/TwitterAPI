using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAPI.Model;

namespace TwitterAPI.Data.Context
{
    public class TweetDbContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }

        public TweetDbContext(DbContextOptions<TweetDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

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
