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

    public IQueryable<ExternalFeatureSet> GetExternalFeatures()
    {
      return _ctx.ExternalFeatureSets;
    }

    public IQueryable<ExternalFeatureSet> GetExternalFeaturesByUser(string zip, int age, string gender)
    {
      return _ctx.ExternalFeatureSets.Where(
          e =>
            (e.Zip == zip) &&
            (e.Age == age) &&
            (e.Gender == gender));
    }

    public IQueryable<ItemFeatureSet> GetItemFeatures()
    {
      return _ctx.ItemFeatureSets;
    }

    public IQueryable<ItemFeatureSet> GetItemFeaturesByPrediction(int[] predictedItemsList, bool includeImages = true)
    {
      IQueryable<ItemFeatureSet> itemsWImages;
      if (includeImages)
      {
        itemsWImages = _ctx.ItemFeatureSets.Include("ItemImages"); 
      }
      else
      {
        itemsWImages = _ctx.ItemFeatureSets;
      }
      
      return itemsWImages.Where(
            i =>
              (i.ItemId == predictedItemsList[0]) ||
              (i.ItemId == predictedItemsList[1]) ||
              (i.ItemId == predictedItemsList[2]));
    }
        
    public IQueryable<ItemImage> GetItemImages(int[] predictedItemsList)
    {
      return _ctx.ItemImages.Where(
          i => 
            (i.ItemId == predictedItemsList[0]) || 
            (i.ItemId == predictedItemsList[1]) || 
            (i.ItemId == predictedItemsList[2]));
    }

    public IQueryable<SenderLink> GetSender(string senderId)
    {
      return _ctx.SenderLinks.Where(s => s.Guid == senderId);
    }

    public IQueryable<SenderLink> GetSenderIncludingPredictions(string senderId)
    {
      var sender = _ctx.SenderLinks.Include("ItemRatings");
      return sender.Where(s => s.Guid == senderId);
    }
        

        /*public IQueryable<ItemRating> GetItemRatings(int userId)
        {
            return _ctx.ItemRatings.Where(r => r.UserId == userId);
        }*/

        /*public IQueryable<UserFeatureSet> GetUserFeatures()
            {
                return _ctx.UserFeatureSets;
            }*/

        /*public IQueryable<UserFeatureSet> GetUserFeatureSetsIncludingItemRatings()        
        {
            return _ctx.UserFeatureSets.Include("ItemRatings");
        }*/

    public bool SaveUser()
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
        _ctx.ItemRatings.AddRange(newSetOfRatings);
        return true;
      }
      catch (Exception ex)
      {
        // TODO log this error
        return false;
      }
    }
      
    public bool AddSenderLink(SenderLink newSender)
    {
      try
      {
        _ctx.SenderLinks.Add(newSender);
        return true;
      }
      catch (Exception ex)
      {
        // TODO log this error
        return false;
      }
    }  

    /*public bool AddItemImage(ItemImage newItemImage)
    //{
    //  try
    //  {
    //    _ctx.;
    //  }
    //  catch (Exception ex)
    //  {
    //    // TODO log this error
    //    return false;
    //  }
    }
    */
  }
}