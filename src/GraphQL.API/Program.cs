namespace GraphQL.API
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Limits.MaxRequestBufferSize = 114096;
                        options.Limits.MaxRequestLineSize = 114096;
                        //options.Limits.MaxQueryStringLength = 4096; // Set your desired max query string length here
                    })
                    .UseStartup<Startup>();
                    //webBuilder.ConfigureAppConfiguration((context, config) =>
                    //{
                    //    config.SetBasePath(Directory.GetCurrentDirectory())
                    //          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    //          .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    //          .AddJsonFile("hosting.json", optional: true)  // Include hosting.json if needed
                    //          .AddEnvironmentVariables();
                    //}).UseStartup<Startup>();
                    //webBuilder.UseStartup<Startup>();
                    //webBuilder.ConfigureKestrel(options =>
                    //{
                    //    options.Limits.MaxRequestBodySize = 302768;
                    //});
                });
    }
}
