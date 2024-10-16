namespace GraphQL.API.Mutations
{
    using CB.Utility;
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Subscriptions;
    using HotChocolate.Types;
    using MassTransit.Initializers;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Mutation")]
    public class ProductMutation
    {
        public async Task<Product> CreateProductAsync(Product product, [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.InsertAsync(product);
            await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Product> CreateProductBulkAsync(ProductViewModel productObj,
            [Service] IProductRepository productRepository,
            [Service] IProductTagRepository tagRepository,
            [Service] IProductAttributeRepository attRepository,
            [Service] IProductAttributeValueRepository attValueRepository,
            [Service] IProductAttributeCombinationRepository combRepository,
            [Service] IProductVariationRepository productVariationRepository,
            [Service] ITopicEventSender eventSender
        )
        {
            Product product = new Product
            {
                Name = productObj.Name,
                Sku = productObj.Sku,
                ModelNo = productObj.ModelNo,
                Summary = productObj.Summary,
                Description = productObj.Description,
                BasePrice = productObj.BasePrice,
                SalePrice = productObj.SalePrice,
                CostPrice = productObj.CostPrice,
                ActualPrice = productObj.ActualPrice,
                CategoryId = productObj.CategoryId,
                CategoryIds = productObj.CategoryIds,
                AssetImageId = productObj.AssetImageId,
                AssetImageIds = productObj.AssetImageIds,
                BrandId = productObj.BrandId,
                ProductCustomTypeId = productObj.ProductCustomTypeId,
            };
            var result = await productRepository.InsertAsync(product);
            if (productObj.ProductTags != null)
                foreach (var item in productObj.ProductTags)
                {
                    ProductTag productTag = new ProductTag
                    {
                        Name = item.Name,
                        Description = item.Description,
                        ProductId = result.Id,
                    };
                    await tagRepository.InsertAsync(productTag);
                }

            List<List<string>> comList = new List<List<string>>();
            List<string> aList = new List<string>();

            if (productObj.ProductAttributes != null)
            {
                int sequenceValue = 1;
                foreach (var item in productObj.ProductAttributes)
                {
                    List<string> vList = new List<string>();
                    ProductAttribute productAtt = new ProductAttribute
                    {
                        Name = item.Name,
                        ProductId = result.Id,
                        SequenceValue = sequenceValue
                    };
                    var attResult = await attRepository.InsertAsync(productAtt);
                    if (item.ProductAttributeValues != null)
                    {
                        foreach (var item2 in item.ProductAttributeValues)
                        {
                            ProductAttributeValue attValue = new ProductAttributeValue
                            {
                                ProductAttributeId = attResult.Id,
                                Title = item2.Title,
                                Value = item2.Value,
                                SequenceValue = item2.SequenceValue
                            };
                            var valueResult = await attValueRepository.InsertAsync(attValue);
                            vList.Add(valueResult.Id);
                        }
                    }
                    comList.Add(vList);
                    sequenceValue++;
                }
            }

            if (comList.Count() > 0)
            {
                var combinations = VairationCombination(comList);
                int sequenceValue = 1;
                foreach (var combination in combinations)
                {
                    if (combination.Length > 0)
                    {
                        var ids = combination.Split(",");
                        var attval = string.Join("-", attValueRepository.GetByIdsAsync(ids).Result.Select(x => x.Value));
                        ProductAttributeCombination comb = new ProductAttributeCombination
                        {
                            ProductId = result.Id,
                            ProductAttributeValueIds = ids,
                            Combination = attval,
                            SequenceValue = sequenceValue
                        };

                        var combResult = await combRepository.InsertAsync(comb);
                        ProductVariation variation = new ProductVariation
                        {
                            Name = productObj.Name + " " + attval,
                            Sku = productObj.Sku + "-" + sequenceValue.ToString("D3"),
                            ModelNo = productObj.ModelNo,
                            Summary = productObj.Summary,
                            Description = productObj.Description,
                            BasePrice = productObj.BasePrice,
                            SalePrice = productObj.SalePrice,
                            CostPrice = productObj.CostPrice,
                            AssetImageId = productObj.AssetImageId,
                            AssetImageIds = productObj.AssetImageIds,
                            ProductAttributeCombinationId = combResult.Id,
                            ProductId = result.Id,
                        };
                        var variationResult = await productVariationRepository.InsertAsync(variation);
                        sequenceValue++;
                    }
                }
            }

            await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnCreateAsync), result);
            return result;
        }


        private List<string> VairationCombination(List<List<string>> domains)
        {
            return CombinationGenerator(domains, new List<string>(), new List<string>());
        }

        private List<string> CombinationGenerator(List<List<string>> domains, List<string> vector, List<string> outputVector)
        {
            if (domains.Count == vector.Count)
            {
                Console.WriteLine(string.Join("", vector));
                outputVector.Add(string.Join(",", vector));
                return outputVector;
            }
            foreach (var value in domains[vector.Count])
            {
                var newVector = vector.ToList();
                newVector.Add(value);
                outputVector = CombinationGenerator(domains, newVector, outputVector);
            }
            return outputVector;
        }


        public async Task<bool> RemoveProductAsync(string id, [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.RemoveAsync(id);

            if (result)
            {
                await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
    }
}
