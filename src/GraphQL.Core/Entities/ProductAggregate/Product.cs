using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Core.Entities
{
    public class Product : BaseEntity
    {
        //public Product() { }

        //public Product(AssetImage assetImage, IList<AssetImage> assetImages, IList<Category> categories)
        //{
        //    AssetImage = assetImage;
        //    AssetImages = assetImages;
        //    Categories = categories;
        //}

        public string Name { get; set; }
        public string ModelNo { get; set; }
        public string Sku { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public double ActualPrice { get; set; }
        public int Quantity { get; set; }
        public string AssetImageId { get; set; }
        public IList<string> AssetImageIds { get; set; }
        public IList<string> AssetVedioIds { get; set; }
        public string ProductCustomTypeId { get; set; }
        public string BrandId { get; set; }
        public string ParentProductId { get; set; }
        public string CategoryId { get; set; }
        public IList<string> CategoryIds { get; set; }

        public bool IsNew { get; set; } = false;
        public bool IsFeatured { get; set; } = false;
        public bool IsOnSale { get; set; } = false;
        public bool IsSoldOut { get; set; } = false;
        public bool IsVariation { get; set; } = false;
        public bool IsStockEnabled { get; set; } = true;
        public DateTime ActualCreatedAt { get; set; } = DateTime.UtcNow;
        public string SupplierId { get; set; }
        public string SellerId { get; set; }
    }



    public class ProductViewModel : BaseEntity
    {
        public ProductViewModel()
        {
            IsNew = false;
            IsOnSale = false;
            IsFeatured = false;
            IsSoldOut = false;
            IsStockEnabled = false;
            IsVariation = false;
        }
        public string Name { get; set; }
        public string ModelNo { get; set; }
        public string Sku { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public double ActualPrice { get; set; }
        public int Quantity { get; set; }
        public string AssetImageId { get; set; }
        public IList<string> AssetImageIds { get; set; }
        public IList<string> AssetVedioIds { get; set; }
        public string ProductCustomTypeId { get; set; }
        public string BrandId { get; set; }
        public string ParentProductId { get; set; }
        public string CategoryId { get; set; }
        public IList<string> CategoryIds { get; set; }

        public bool? IsNew { get; set; } = false;
        public bool? IsFeatured { get; set; } = false;
        public bool? IsOnSale { get; set; } = false;
        public bool? IsSoldOut { get; set; } = false;
        public bool? IsVariation { get; set; } = false;
        public bool? IsStockEnabled { get; set; } = true;
        public DateTime? ActualCreatedAt { get; set; } = DateTime.UtcNow;
        public string SupplierId { get; set; }
        public string SellerId { get; set; }

        public IList<ProductTag> ProductTags { get; set; }
        public IList<ProductAttributeViewModel> ProductAttributes { get; set; }
    }
}