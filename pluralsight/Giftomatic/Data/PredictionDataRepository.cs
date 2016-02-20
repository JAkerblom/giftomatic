using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Giftomatic.Models;

namespace Giftomatic.Data
{
  public class PredictionDataRepository : IPredictionDataRepository
  {
    PredictionDataContext _ctx;
    public PredictionDataRepository(PredictionDataContext ctx)
    {
      _ctx = ctx;
    }

    public IQueryable<Item> GetItemFeatures()
    {
      return _ctx.ItemFeatureSets;
    }

    public IQueryable<UserFeatureSet> GetUserFeatures()
    {
      return _ctx.UserFeatureSets;
    }

    public IQueryable<ItemRating> GetItemRatings(int userId)
    {
      return _ctx.ItemRatings.Where(r => r.UserId == userId);
    }

    public IQueryable<UserFeatureSet> GetUserFeatureSetsIncludingItemRatings()
    {
      return _ctx.UserFeatureSets.Include("ItemRatings");
    }
    
    public IQueryable<ItemImage> GetItemImages(int itemId = -1)
    {
      if (itemId == -1)
      {
        return _ctx.ItemImages;
      }
      else
      {
        return _ctx.ItemImages.Where(i => i.ItemId == itemId);
      }
      
    }

    public bool Save()
    {
      try
      {
        return _ctx.SaveChanges() > 0;
      }
      catch (Exception ex)
      {
        // TODO log this error
        return false;
      }
    }

    public bool AddUserFeatureSet(UserFeatureSet newSetOfUserFeatures)
    {
      try
      {
        _ctx.UserFeatureSets.Add(newSetOfUserFeatures);
        return true;
      }
      catch (Exception ex)
      {
        // TODO log this error
        return false;
      }
    }

    public bool AddItemRatings(IEnumerable<ItemRating> newSetOfRatings)
    {
      try
      {
        _ctx.ItemRatings.Add(newSetOfRatings);
        return true;
      }
      catch (Exception ex)
      {
        // TODO log this error
        return false;
      }
    }

    public bool AddItemImage(ItemImage newItemImage)
    {
      try
      {
        _ctx.;
      }
      catch (Exception ex)
      {
        // TODO log this error
        return false;
      }
    }
  }
}