using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HoloLensRezept
{
    [DataContract]
    public class Recipe
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "type")]
        public int Type { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "subtitle")]
        public string Subtitle { get; set; }
        [DataMember(Name = "owner")]
        public Owner OwnerVal { get; set; }
        [DataMember(Name = "rating")]
        public Rating RatingVal { get; set; }
        [DataMember(Name = "difficulty")]
        public int Difficulty { get; set; }
        [DataMember(Name = "hasImage")]
        public bool hasImage { get; set; }
        [DataMember(Name = "hasVideo")]
        public bool hasVideo { get; set; }
        [DataMember(Name = "previewImageId")]
        public string PreviewImageId { get; set; }
        [DataMember(Name = "preparationTime")]
        public int preparationTime { get; set; }
        [DataMember(Name = "isSubmitted")]
        public bool IsSubmitted { get; set; }
        [DataMember(Name = "isRejected")]
        public bool IsRejected { get; set; }
        [DataMember(Name = "createdAt")]
        public string CreatedAt { get; set; }
        [DataMember(Name = "imageCount")]
        public int ImageCount { get; set; }
        [DataMember(Name = "editor")]
        public Editor Editor_C { get; set; }
        [DataMember(Name = "submissionDate")]
        public string SubmissionDate { get; set; }
        [DataMember(Name = "isPremium")]
        public bool IsPremium { get; set; }
        [DataMember(Name = "status")]
        public int Status { get; set; }
        [DataMember(Name = "servings")]
        public int Servings { get; set; }
        [DataMember(Name = "kCalories")]
        public int KCalories { get; set; }
        [DataMember(Name = "instructions")]
        public string Instructions { get; set; }
        [DataMember(Name = "miscellaneousText")]
        public string MiscellaneousText { get; set; }
        [DataMember(Name = "ingredientsText")]
        public string IngredientsText { get; set; }
        [DataMember(Name = "tags")]
        public List<String> Tags { get; set; }
        [DataMember(Name = "viewCount")]
        public int ViewCount { get; set; }
        [DataMember(Name = "cookingTime")]
        public int CookingTime { get; set; }
        [DataMember(Name = "restingTime")]
        public int RestingTime { get; set; }
        [DataMember(Name = "totalTime")]
        public int TotalTime { get; set; }
        [DataMember(Name = "ingredientGroups")]
        public List<IngredientGroup> IngredientsGroups { get; set; }
        [DataMember(Name = "categoryGroups")]
        public List<int> CategoryGroups { get; set; }
        [DataMember(Name = "recipeVideoId")]
        public string RecipeVideoId { get; set; }
        [DataMember(Name = "siteUrl")]
        public string siteUrl { get; set; }
    }
}
