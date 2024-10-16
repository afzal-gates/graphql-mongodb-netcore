using System.ComponentModel.DataAnnotations;

namespace GraphQL.Core.Entities
{
    public class AssetItem : BaseEntity
    {
        public string Name { get; set; }
        public string Alt { get; set; }
        [Required]
        public string Url { get; set; }
        public string LargeUrl { get; set; }
        public string MediumUrl { get; set; }
        public string SmallUrl { get; set; }
        public bool? IsVideo { get; set; } = false;
    }
}