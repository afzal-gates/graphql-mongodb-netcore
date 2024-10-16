namespace GraphQL.API
{
    using GraphQL.API.Configurations;
    using GraphQL.API.Extensions;
    using GraphQL.API.Mutations;
    using GraphQL.API.Queries;
    using GraphQL.API.Resolvers;
    using GraphQL.API.Subscriptions;
    using GraphQL.API.Types;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;
    using GraphQL.Infrastructure.Repositories;
    using HotChocolate.Types.Pagination;
    using HotChocolate.AspNetCore.Authorization;
    //using HotChocolate.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MongoDB.Bson;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using System.Reflection;
    using GraphQL.Core.Entities;
    using StackExchange.Redis;

    public class Startup
    {
        private readonly ApiConfiguration apiConfiguration;
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.apiConfiguration = configuration.Get<ApiConfiguration>();
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var signingKey = new SymmetricSecurityKey(
            //Encoding.UTF8.GetBytes("MySuperSecretKey"));

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters =
            //            new TokenValidationParameters
            //            {
            //                ValidIssuer = "https://auth.chillicream.com",
            //                ValidAudience = "https://graphql.chillicream.com",
            //                ValidateIssuerSigningKey = true,
            //                IssuerSigningKey = signingKey
            //            };
            //    });

            services.AddAuthenticationServices(_configuration);
            services.AddAuthorizationServices(_configuration);
            // Configurations
            services.AddSingleton(this.apiConfiguration.MongoDbConfiguration);

            // Repositories
            services.AddSingleton<ICatalogContext, CatalogContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAssetItemRepository, AssetItemRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductAttributeCombinationRepository, ProductAttributeCombinationRepository>();
            services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddScoped<IProductAttributeValueRepository, ProductAttributeValueRepository>();
            services.AddScoped<IProductTagRepository, ProductTagRepository>();
            services.AddScoped<IProductStockRepository, ProductStockRepository>();
            services.AddScoped<IProductVariationRepository, ProductVariationRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuaration = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuaration);
            });

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3001", "http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));

            // GraphQL
            services
                //.AddMemoryCache()
                .AddGraphQLServer()
                .AddAuthorization()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .SetPagingOptions(new PagingOptions
                {
                    MaxPageSize = 1000
                })
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<ProductQuery>()
                    .AddTypeExtension<CategoryQuery>()
                    .AddTypeExtension<BrandQuery>()
                    .AddTypeExtension<AssetQuery>()
                    .AddTypeExtension<SupplierQuery>()
                    .AddTypeExtension<SellerQuery>()
                    .AddTypeExtension<BuyerQuery>()
                    .AddTypeExtension<OrderQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<AssetMutation>()
                    .AddTypeExtension<BasketMutation>()
                    .AddTypeExtension<BrandMutation>()
                    .AddTypeExtension<BuyerMutation>()
                    .AddTypeExtension<CategoryMutation>()
                    .AddTypeExtension<CouponMutation>()
                    .AddTypeExtension<DeliveryMethodMutation>()
                    .AddTypeExtension<OrderMutation>()
                    .AddTypeExtension<ProductMutation>()
                    .AddTypeExtension<RefundMutation>()
                    .AddTypeExtension<SellerMutation>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<ProductSubscriptions>()
                .AddType<AssetItemType>()
                .AddType<BrandType>()
                .AddType<CategoryType>()
                .AddType<ProductType>()
                .AddType<ProductAttributeType>()
                .AddType<ProductAttributeValueType>()
                .AddType<ProductAttributeCombinationType>()
                .AddType<ProductVariationType>()
                .AddType<BuyerType>()
                .AddType<SellerType>()
                .AddType<BasketType>()
                //.AddType<SupplierType>()

                .AddType<AssetImageResolver>()
                .AddType<BrandResolver>()
                .AddType<ProductAttributeCombinationResolver>()
                .AddType<ProductAttributeValueResolver>()
                .AddType<ProductAttributeResolver>()
                .AddType<ProductStockResolver>()
                .AddType<ProductTagResolver>()
                .AddType<ProductVariationResolver>()
                .AddType<CategoryResolver>()
                .AddType<AddressResolver>()
                .AddType<BasketItemResolver>()
                //.UseAutomaticPersistedQueryPipeline()
                .AddInMemorySubscriptions()
                //.AddInMemoryQueryStorage()
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("ApiCorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/api/graphql");
                //.RequireAuthorization();
                //.ToJson();
            });
        }
    }
}
