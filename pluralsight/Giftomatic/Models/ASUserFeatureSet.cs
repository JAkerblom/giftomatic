using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Giftomatic.Models
{
  public class ASUserFeatureSet
  { 
    public string Zip { get; set; }
    public int Age { get; set; }
    public string SexType { get; set; }
    public int PrefersSoftPresent { get; set; }
    public int PrefersSuntrip { get; set; }
    public int PrefersDog { get; set; }
    public int SantaBelief { get; set; }
    public string ChocolatePref { get; set; }
    public string CandyPref { get; set; }
    public string KallePref { get; set; }
    public int LikesFood1 { get; set; }
    public int LikesFood2 { get; set; }
    public int LikesFood3 { get; set; }
    public int LikesFood4 { get; set; }
    public int LikesFood5 { get; set; }
    public int LikesFood6 { get; set; }
    public int LikesFood7 { get; set; }
    public int LikesFood8 { get; set; }
    public int LikesFood9 { get; set; }
    public int LikesFood10 { get; set; }
    public int LikesFood11 { get; set; }
    public int LikesFood12 { get; set; }


    //internal IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
    //{
    //  return source.GetType().GetProperties(bindingAttr).ToDictionary
    //  (
    //    propInfo => propInfo.Name,
    //    propInfo => 
    //  );

    //  //throw new NotImplementedException();
    //}

    //public int ItemId { get; set; }
    //public int Rating { get; set; }
  }
}