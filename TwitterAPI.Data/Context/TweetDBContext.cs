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
        }
    }
}
