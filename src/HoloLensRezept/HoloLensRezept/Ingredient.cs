using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HoloLensRezept
{
    [DataContract]
    public class Ingredient
    {
        [DataMember(Name = "id")]
        string Id;
        [DataMember(Name = "name")]
        string Name;
        [DataMember(Name = "unit")]
        string Unit;
        [DataMember(Name = "unitId")]
        string UnitId;
        [DataMember(Name = "amount")]
        double Amount;
        [DataMember(Name = "isBasic")]
        bool IsBasic;
        [DataMember(Name = "usageInfo")]
        string usageInfo;
        [DataMember(Name = "url")]
        string Url;
        [DataMember(Name = "foodId")]
        string FoodId;
        [DataMember(Name = "productGroup")]
        string ProductGroup;
    }
}
