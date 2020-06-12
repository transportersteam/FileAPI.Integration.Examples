using System;
using System.IO;
using Ftaas.Sdk.Streaming;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace FileAPI.MFT.Streaming.NetCore22
{
    public class ExamplesBase
    {
        protected IService Streaming { get; }

        protected static ITestOutputHelper Output;

        protected readonly string UploadDirectory = Path.Combine(Environment.CurrentDirectory, @"Files\Upload");

        public ExamplesBase(ITestOutputHelper output)
        {
            // This is used to show messages in the tests (internal purpose only).
            Output = output;

            // Inject the Streaming.SDK service.
            var services = new ServiceCollection();
            services.AddStreamingService(
                options =>
                {
                    options.MftServiceBaseAddress = "https://api-test.raet.com/mft/v1.0/";
                    options.ChunkMaxBytesSize = 4 * 1024 * 1024; // 4 MB
                    options.ConcurrentConnectionsCount = 6;
                },
                async (_) =>
                {
                    return await TokenProvider.GenerateAsync();
                });

            // Get the Streaming.SDK service.
            var serviceProvider = services.BuildServiceProvider();
            Streaming = serviceProvider.GetRequiredService<IService>();
        }
    }
}