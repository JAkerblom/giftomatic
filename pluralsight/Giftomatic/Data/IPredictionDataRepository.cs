using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftomatic.Models;

namespace Giftomatic.Data
{
    interface IPredictionDataRepository
    {
        IQueryable<ItemFeatureSet> GetItemFeatures();
        IQueryable<UserFeatureSet> GetUserFeatures();
        IQueryable<ItemRating> GetItemRatings();
        IQueryable<ItemImage> GetItemImage();

        bool SaveUser();

        bool AddUserFeatureSet(UserFeatureSet newSetOfUserFeatures);
        bool AddItemRatings(IEnumerable<ItemRating> newSetOfItemRatings);
        bool AddItem(ItemFeatureSet newItem);
        bool AddItemImage(ItemImage newItemImage);
    }
}
