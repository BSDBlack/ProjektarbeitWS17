using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HoloLensRezept
{
    [DataContract]
    class Recipe
    {
        [DataMember(Name = "id")]
        string Id { get; set; }
        [DataMember(Name = "type")]
        int Type { get; set; }
        [DataMember(Name = "title")]
        string Title { get; set; }
        [DataMember(Name = "subtitle")]
        string Subtitle { get; set; }
        [DataMember(Name = "owner")]
        Owner OwnerVal { get; set; }
        [DataMember(Name = "rating")]
        Rating RatingVal { get; set; }
        [DataMember(Name = "difficulty")]
        int Difficulty { get; set; }
        [DataMember(Name = "hasImage")]
        bool hasImage { get; set; }
        [DataMember(Name = "hasVideo")]
        bool hasVideo { get; set; }
        [DataMember(Name = "previewImageId")]
        string PreviewImageId { get; set; }
        [DataMember(Name = "preparationTime")]
        int preparationTime { get; set; }
        [DataMember(Name = "isSubmitted")]
        bool IsSubmitted { get; set; }
        [DataMember(Name = "isRejected")]
        bool IsRejected { get; set; }
        [DataMember(Name = "createdAt")]
        DateTime CreatedAt { get; set; }
        [DataMember(Name = "imageCount")]
        int ImageCount { get; set; }
        [DataMember(Name = "editor")]
        string Editor { get; set; }
        [DataMember(Name = "submissionDate")]
        DateTime SubmissionDate { get; set; }
        [DataMember(Name = "isPremium")]
        bool IsPremium { get; set; }
        [DataMember(Name = "status")]
        int Status { get; set; }
        [DataMember(Name = "servings")]
        int Servings { get; set; }
        [DataMember(Name = "kCalories")]
        int KCalories { get; set; }
        [DataMember(Name = "instructions")]
        string Instructions { get; set; }
        [DataMember(Name = "miscellaneousText")]
        string MiscellaneousText { get; set; }
        [DataMember(Name = "ingredientsText")]
        string IngredientsText { get; set; }
        [DataMember(Name = "tags")]
        List<String> Tags { get; set; }
        [DataMember(Name = "viewCount")]
        int ViewCount { get; set; }
        [DataMember(Name = "cookingTime")]
        int CookingTime { get; set; }
        [DataMember(Name = "restingTime")]
        int RestingTime { get; set; }
        [DataMember(Name = "totalTime")]
        int TotalTime { get; set; }
        [DataMember(Name = "ingredientGroups")]
        List<IngredientGroup> IngredientsGroups { get; set; }
        [DataMember(Name = "categoryGroups")]
        List<Int> CategoryGroups { get; set; }
        [DataMember(Name = "recipeVideoId")]
        string RecipeVideoId { get; set; }
        [DataMember(Name = "siteUrl")]
        string siteUrl { get; set; }
    }
}
