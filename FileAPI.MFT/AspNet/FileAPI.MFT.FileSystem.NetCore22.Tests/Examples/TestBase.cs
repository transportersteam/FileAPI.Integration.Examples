using Ftaas.Sdk.FileSystem;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Xunit.Abstractions;

namespace FileAPI.MFT.FileSystem.NetCore22.Tests.Examples
{
    public class TestBase
    {
        public IService FileSystem { get; set; }

        public string TenantId { get; set; }

        public readonly string UploadDirectory = Path.Combine(Environment.CurrentDirectory, @"Examples\Files\Upload");

        public static ITestOutputHelper Output;

        public TestBase()
        {
            //// This is only used to show messages in the tests (internal purpose).
            //Output = output;

            var services = new ServiceCollection();

            // Inject the FileSystem.SDK service.
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

            var serviceProvider = services.BuildServiceProvider();
            FileSystem = serviceProvider.GetRequiredService<IService>();

            // Only necessary for multi-tenant token.
            //var tenantId = "MyTenantId");
            TenantId = "6401970";
        }
    }
}