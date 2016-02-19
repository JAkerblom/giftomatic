using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftomatic.Data
{
    interface IPredictionDataRepository
    {
        IQueryable<Item> GetItems();
        IQueryable<UserFeatureSet> GetUserFeatures();
        IQueryable<ItemRating> GetItemRatings();

        bool SaveUser(); 
    }
}
