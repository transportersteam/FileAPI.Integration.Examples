using System;
using System.IO;
using Ftaas.Sdk.Streaming;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace FileAPI.MFT.Streaming.NetCore22
{
    public class ExamplesBase
    {
        protected IService Streaming { get; }

        protected IConfigurationRoot Config { get; }

        protected readonly string FilesBaseDirectory = Path.Combine(Environment.CurrentDirectory, "Files");

        protected static ITestOutputHelper Output;

        public ExamplesBase(ITestOutputHelper output)
        {
            // Internal purpose only. It is used to show messages in the tests.
            Output = output;

            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            // Inject the Streaming.SDK service.
            var services = new ServiceCollection();
            services.AddStreamingService(
                options =>
                {
                    options.MftServiceBaseAddress = Config.GetValue<string>("mtf_service_base_address");
                    options.ChunkMaxBytesSize = Config.GetValue<int>("chunk_max_bytes_size");
                    options.ConcurrentConnectionsCount = Config.GetValue<byte>("concurrent_connection_count");
                },
                async (_) =>
                {
                    return await TokenProvider.GetAuthorizationTokenAsync();
                });

            // Get the Streaming.SDK service.
            var serviceProvider = services.BuildServiceProvider();
            Streaming = serviceProvider.GetRequiredService<IService>();
        }
    }
}