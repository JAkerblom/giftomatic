using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftomatic.Models;
using Newtonsoft.Json.Linq;

namespace Giftomatic.Data
{
  public interface IPredictionDataRepository
  {
    // GET is first interested in getting
    //  external (based on zip, age, gender; one row)
    //  and item features (n iitems, n rows)
    //  as well as the item image (either separately or
    //  with itemFeatures
    IQueryable<ExternalFeatureSet> GetExternalFeatures();
    IQueryable<ExternalFeatureSet> GetExternalFeaturesByUser(string zip, int age, string gender);
    IQueryable<ItemFeatureSet> GetItemFeatures();
    IQueryable<ItemFeatureSet> GetItemFeaturesByPrediction(int[] predictedItemsList, bool includeImages = true);
    IQueryable<ItemImage> GetItemImages(int[] predictedItemsList);
    IQueryable<SenderLink> GetSender(string senderId);
    IQueryable<SenderLink> GetSenderIncludingPredictions(string senderId);
    JObject GetPrediction(PredictionData data, int modelNr);
    JObject GetPrediction(UserFeatureSet usf, int modelNr);
    JObject GetPrediction(ASUserFeatureSet usf, int modelNr);

    // GETs that is useful for the retraining API
    //IQueryable<ItemRating> GetItemRatings();

    // GETs that are probably not going to be used 
    //  in the first place. Maybe for statistics?
    //IQueryable<UserFeatureSet> GetUserFeatures();
    //IQueryable<UserFeatureSet> GetUserFeatureSetsIncludingItemRatings();

    bool SaveUser(); // Don't know how this is going to fit

    // POSTs
    // -----
    // Add users input on submit
    // Add users rating of items
    bool AddUserFeatureSet(UserFeatureSet newSetOfUserFeatures);
    bool AddItemRatings(IEnumerable<ItemRating> newSetOfItemRatings);
    bool AddSenderLink(SenderLink newSender);

    // GETs that are probably are to be used if 
    //  using webpage for adding items to the back-end as well
    //bool AddItemFeatureSet(ItemFeatureSet newItem);
    //bool AddItemImage(ItemImage newItemImage);
  }
}
