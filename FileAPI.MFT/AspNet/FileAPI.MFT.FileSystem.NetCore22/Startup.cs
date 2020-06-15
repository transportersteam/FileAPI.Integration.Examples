using Ftaas.Sdk.FileSystem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Xunit.Abstractions;

namespace FileAPI.MFT.FileSystem.NetCore22
{
    public class Startup
    {
        protected IService FileSystem { get; }

        protected IConfigurationRoot Config { get; }

        protected readonly string FilesBaseDirectory = Path.Combine(Environment.CurrentDirectory, "Files");

        protected static ITestOutputHelper Output;

        public Startup(ITestOutputHelper output)
        {
            // Internal purpose only. It is used to show messages in the tests.
            Output = output;

            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            // Inject the FileSystem.SDK service.
            var services = new ServiceCollection();
            services.AddFileSystemService(
                options =>
                {
                    options.MftServiceBaseAddress = Config.GetValue<string>("mtf_service_base_address");
                    options.ChunkMaxBytesSize = Config.GetValue<int>("chunk_max_bytes_size");
                    options.ConcurrentConnectionsCount = Config.GetValue<byte>("concurrent_connection_count");
                },
                async (_) =>
                {
                    return await TokenProvider.GetAuthenticationTokenAsync();
                });

            // Get the FileSystem.SDK service.
            var serviceProvider = services.BuildServiceProvider();
            FileSystem = serviceProvider.GetRequiredService<IService>();
        }
    }
}