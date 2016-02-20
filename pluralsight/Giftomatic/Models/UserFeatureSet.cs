using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giftomatic.Models
{
    public class UserFeatureSet
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Zip { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        // User may get multi-option questions 
        //  which presents a couple of nominal values
        public string SubjectPrefX { get; set; }
        public string SubjectPrefY { get; set; }
        // User may get boolean questions of preference
        public bool LikesX { get; set; }
        public bool LikesY { get; set; }
        // User may get claims posed as boolean questions
        //  e.g. "do you have a dog?"
        public bool ClaimX { get; set; }
        public bool ClaimY { get; set; }
        // User may be asked to input a value in a
        //  numeric scale.
        public int ScaleValueX { get; set; }
        public int ScaleValueY { get; set; }

        public ICollection<ItemRating> ItemRatings { get; set; }

        //public int ItemId { get; set; }
        //public int Rating { get; set; }
  }
}