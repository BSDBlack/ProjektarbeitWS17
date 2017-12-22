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
        public string Id;
        [DataMember(Name = "name")]
        public string Name;
        [DataMember(Name = "unit")]
        public string Unit;
        [DataMember(Name = "unitId")]
        public string UnitId;
        [DataMember(Name = "amount")]
        public double Amount;
        [DataMember(Name = "isBasic")]
        public bool IsBasic;
        [DataMember(Name = "usageInfo")]
        public string usageInfo;
        [DataMember(Name = "url")]
        public string Url;
        [DataMember(Name = "foodId")]
        public string FoodId;
        [DataMember(Name = "productGroup")]
        public string ProductGroup;
    }
}
