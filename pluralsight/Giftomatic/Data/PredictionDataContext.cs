using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Giftomatic.Models;

namespace Giftomatic.Data
{
  public class PredictionDataContext : DbContext
  {
    public PredictionDataContext()
      : base("DefaultConnection")
    {
      this.Configuration.LazyLoadingEnabled = false;
      this.Configuration.ProxyCreationEnabled = false;

      Database.SetInitializer(
        new MigrateDatabaseToLatestVersion<PredictionDataContext, PredictionDataMigrationsConfiguration>()
        );
    }

    public DbSet<UserInput> UserInputs { get; set; }
    //public DbSet<UserFeatureSet> UserFeatures { get; set; }
    //public DbSet<ItemRating> ItemRatings { get; set; }
    public DbSet<Item> Items { get; set; }

  }
}