﻿namespace GraphQL.Infrastructure.Data
{
    using GraphQL.Infrastructure.Configurations;
    using MongoDB.Driver;

    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoDatabase database;
        private readonly IMongoClient client;

        public CatalogContext(MongoDbConfiguration mongoDbConfiguration)
        {
            this.client = new MongoClient(mongoDbConfiguration.ConnectionString);

            this.database = client.GetDatabase(mongoDbConfiguration.Database);

            CatalogContextSeed.SeedData(this.database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this.database.GetCollection<T>(name);
        }
    }
}
