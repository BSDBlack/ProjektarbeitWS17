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
        string Id;
        [DataMember(Name = "type")]
        int Type;
        [DataMember(Name = "title")]
        string Title;
        [DataMember(Name = "subtitle")]
        string Subtitle;
        [DataMember(Name = "owner")]
        Owner OwnerVal;
        [DataMember(Name = "rating")]
        Rating RatingVal;
        [DataMember(Name = "difficulty")]
        int Difficulty;
        [DataMember(Name = "hasImage")]
        bool hasImage;
        [DataMember(Name = "hasVideo")]
        bool hasVideo;
        [DataMember(Name = "previewImageId")]
        string PreviewImageId;
        [DataMember(Name = "preparationTime")]
        int preparationTime;
        [DataMember(Name = "isSubmitted")]
        bool IsSubmitted;
        [DataMember(Name = "isRejected")]
        bool IsRejected;
        [DataMember(Name = "createdAt")]
        DateTime CreatedAt;
        [DataMember(Name = "imageCount")]
        int ImageCount;
        [DataMember(Name = "editor")]
        string Editor;
        [DataMember(Name = "submissionDate")]
        DateTime SubmissionDate;
        [DataMember(Name = "isPremium")]
        bool IsPremium;
        [DataMember(Name = "status")]
        int Status;
        [DataMember(Name = "siteUrl")]
        string siteUrl;
    }
}
