using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Giftomatic.Models;

namespace Giftomatic.Data
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext()
      : base("DefaultConnection")
    {
      this.Configuration.LazyLoadingEnabled = false;
      this.Configuration.ProxyCreationEnabled = false;

      Database.SetInitializer(
        new MigrateDatabaseToLatestVersion<MessageBoardContext, PredictionDataMigrationsConfiguration>()
        );
    }

    public DbSet<Topic> Topics { get; set; }
    public DbSet<Reply> Replies { get; set; }

  }
}