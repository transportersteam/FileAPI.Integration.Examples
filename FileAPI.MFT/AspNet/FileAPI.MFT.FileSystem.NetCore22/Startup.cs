using Ftaas.Sdk.FileSystem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileAPI.MFT.FileSystem.NetCore22
{
    public class Startup
    {
        protected IService FileSystem { get; }

        protected IConfigurationRoot Config { get; }

        protected readonly string FilesBaseDirectory = Path.Combine(Environment.CurrentDirectory, "Files");

        public Startup()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            // Inject the FileSystem.SDK service.
            // ToDo Write what do the options do.
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
                    // Here comes the logic of retrieving the authentaction token.
                    // This logic is out of the File API scope, but as a guide, you can use something similar
                    // to what is implemented in Examples/RetrieveToken.cs.
                    return await Task.FromResult("MyToken");
                });

            // Get the FileSystem.SDK service.
            var serviceProvider = services.BuildServiceProvider();
            FileSystem = serviceProvider.GetRequiredService<IService>();
        }
    }
}