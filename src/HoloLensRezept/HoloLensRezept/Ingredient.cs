using System;
using System.Runtime.Serialization;

public class Ingredient
{
    [DataContract]
	public Ingredient()
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
