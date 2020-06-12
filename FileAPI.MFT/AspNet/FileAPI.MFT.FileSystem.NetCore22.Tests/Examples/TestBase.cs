using Ftaas.Sdk.FileSystem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Xunit.Abstractions;

namespace FileAPI.MFT.FileSystem.NetCore22.Examples
{
    public class TestBase
    {
        protected IService FileSystem { get; }

        protected readonly string UploadDirectory = Path.Combine(Environment.CurrentDirectory, @"Examples\Files\Upload");

        protected static ITestOutputHelper Output;

        protected IConfigurationRoot Config { get; }

        public TestBase(ITestOutputHelper output)
        {
            // This is used to show messages in the tests (internal purpose only).
            Output = output;

            // ToDo What the fuck, dude? Why it is not working?
            //var bar = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddYamlFile("config.yml")
            //    .Build();

            // Inject the FileSystem.SDK service.
            var services = new ServiceCollection();
            services.AddFileSystemService(
                options =>
                {
                    //options.MftServiceBaseAddress = "https://api.raet.com/mft/v1.0/";
                    options.MftServiceBaseAddress = "https://api-test.raet.com/mft/v1.0/";
                    options.ChunkMaxBytesSize = 4 * 1024 * 1024; // 4 MB
                    options.ConcurrentConnectionsCount = 6;
                },
                async (_) =>
                {
                    return await TokenProvider.GenerateAsync();
                });

            // Get the FileSystem.SDK service.
            var serviceProvider = services.BuildServiceProvider();
            FileSystem = serviceProvider.GetRequiredService<IService>();
        }
    }
}