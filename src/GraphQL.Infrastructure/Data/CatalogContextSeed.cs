namespace GraphQL.Infrastructure.Data
{
    using GraphQL.Core.Entities;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;
    using StackExchange.Redis;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CatalogContextSeed
    {
        private static IMongoDatabase _adminDatabase;
        public static void SeedData(IMongoDatabase database)
        {
            _adminDatabase = database.Client.GetDatabase("admin");
            CreateShardCollection<Product>(database.DatabaseNamespace.DatabaseName, "Sku", "hashed", false);
            CreateShardCollection<Category>(database.DatabaseNamespace.DatabaseName, "Name", "hashed");
            InsertCategories(database.GetCollection<Category>(nameof(Category)));
            InsertBrands(database.GetCollection<Brand>(nameof(Brand)));
            InsertImages(database.GetCollection<AssetItem>(nameof(AssetItem)));
            InsertProducts(database.GetCollection<Product>(nameof(Product)), database.GetCollection<AssetItem>(nameof(AssetItem)));
        }


        private static void CreateShardCollection<T>(string dbName, string partitionKey, object val, bool isSharded = true)
        {
            try
            {
                if (!isSharded)
                {
                    // Enable sharding for the database
                    var shellCommandEnableShard = new BsonDocument
                    {
                        { "enableSharding", $"{dbName}" }
                    };
                    var commandResult2 = _adminDatabase.RunCommand<BsonDocument>(shellCommandEnableShard);
                }

                var shardKey = @"{ '" + partitionKey + "': '" + val + "' }"; // Change to your shard key field
                var shellCommand = new BsonDocument
                {
                    { "shardCollection", $"{dbName}.{typeof(T).Name}" },
                    { "key", BsonSerializer.Deserialize<BsonDocument>(shardKey) }
                };

                var commandResult = _adminDatabase.RunCommand<BsonDocument>(shellCommand);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void InsertCategories(IMongoCollection<Category> categoryCollection)
        {
            categoryCollection.DeleteMany(_ => true);
            categoryCollection.InsertMany(
                new List<Category>
                {
                    new Category
                    {
                        Id = "605fbfdda571444fd7ade05b",
                        Name ="Category-1",
                        Description = "Category Description One"
                    },
                    new Category
                    {
                        Id = "605fbfecdefb479679f08517",
                        Name ="Category-2",
                        Description = "Category Description Two",
                        ParentCategoryIds= new List<string> { "605fbfdda571444fd7ade05b" }
                    }
                });
        }


        private static void InsertBrands(IMongoCollection<Brand> brandCollection)
        {
            brandCollection.DeleteMany(_ => true);
            brandCollection.InsertMany(
                new List<Brand>
                {
                    new Brand
                    {
                        Id = "105fbfdda571444fd7ade05b",
                        Name = "Brand One"
                    },
                    new Brand
                    {
                        Id = "105fbfecdefb479679f08517",
                        Name = "Brand Two"
                    }
                });
        }

        private static void InsertImages(IMongoCollection<AssetItem> imageCollection)
        {
            imageCollection.DeleteMany(_ => true);
            imageCollection.InsertMany(
                new List<AssetItem>
                {
                    new AssetItem
                    {
                        Id = "605fbfdda571444fd7ade05b",
                        Name ="Image-1",
                        Url = "https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08510",
                        Name ="Image-2",
                        Url = "https://www.lightstalking.com/wp-content/uploads/stephanie-leblanc-JLMEZxBcXCU-unsplash.jpg"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08511",
                        Name ="Image-3",
                        Url = "https://media.istockphoto.com/id/506434660/photo/red-eyed-amazon-tree-frog.jpg?s=612x612&w=0&k=20&c=kNjvWPV83AMbCA9zqI_Bt6XKIAB1mGOnHAIf9hcSdgw="
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08512",
                        Name ="Image-4",
                        Url = "https://cdn.create.vista.com/api/media/small/104662714/stock-photo-red-eye-tree-frog-on-the-leaves"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08513",
                        Name ="Image-5",
                        Url = "https://media.istockphoto.com/id/647015980/photo/red-eyed-tree-frog.jpg?s=612x612&w=0&k=20&c=E2CWtEbUuNfmPiR4G8yTkUhBzJsUwvd0rmqVfpemDkg="
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08514",
                        Name ="Image-6",
                        Url = "https://images.ctfassets.net/hrltx12pl8hq/3Z1N8LpxtXNQhBD5EnIg8X/975e2497dc598bb64fde390592ae1133/spring-images-min.jpg"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08515",
                        Name ="Image-7",
                        Url = "https://imgv3.fotor.com/images/cover-photo-image/AI-illustration-of-a-dragon-by-Fotor-AI-text-to-image-generator.jpg"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08516",
                        Name ="Image-8",
                        Url = "https://designimages.appypie.com/aitools/ai-text-to-image/61_org.png"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08517",
                        Name ="Image-9",
                        Url = "https://img.freepik.com/free-photo/cool-scene-with-futuristic-dragon-beast_23-2151201756.jpg"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08518",
                        Name ="Image-10",
                        Url = "https://img.freepik.com/free-photo/cool-scene-with-futuristic-dragon-beast_23-2151201695.jpg"
                    },
                    new AssetItem
                    {
                        Id = "605fbfecdefb479679f08519",
                        Name ="Image-1",
                        Url = "https://img.freepik.com/photos-premium/images-dragons-couleur-images-dragons-hdimagine-images-dragons-image-dragon-image-dragon_957107-119.jpg"
                    }
                });
        }

        private static void InsertProducts(IMongoCollection<Product> productCollection, IMongoCollection<AssetItem> imageCollection)
        {
            if (!productCollection.AsQueryable().Any())
            {
                productCollection.DeleteMany(_ => true);
                var images = imageCollection.AsQueryable().ToList();
                var pList = new List<Product>();
                for (int i = 1; i <= 1000; i++)
                {
                    double price = new Random().Next(2, 50);
                    int qty = new Random().Next(1, 35);
                    int x = 10 % i;
                    pList.Add(new Product
                    {
                        //Id = "605fbfd4f0d09d08fba6bd80",
                        Name = $"Product Name  {i}",
                        Sku = RandomString(8),
                        ActualPrice = Math.Round((price * 1.17), 2),
                        Quantity = qty,
                        CategoryId = "605fbfdda571444fd7ade05b",
                        BrandId = (i % 3 == 0 ? "105fbfdda571444fd7ade05b" : "105fbfecdefb479679f08517"),
                        CategoryIds = new string[] { "605fbfdda571444fd7ade05b", "605fbfecdefb479679f08517" },
                        Description = $"Product Description {i}",
                        AssetImageId = images[x].Id,
                        AssetImageIds = new string[] { images[0].Id, images[1].Id, images[2].Id, images[3].Id, images[4].Id, images[5].Id }
                    });
                }
                productCollection.InsertMany(pList);
            }
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
