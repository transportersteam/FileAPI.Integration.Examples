using System;
using System.IO;
using System.Threading.Tasks;
using Ftaas.Sdk.Streaming;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace FileAPI.MFT.Streaming.NetCore22
{
    public class Startup
    {
        protected IService Streaming { get; }

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
                    // Here comes the logic of retrieving the authentaction token.
                    // This logic is out of the File API scope, but as a guide, you can use something similar
                    // to what is implemented in Examples/RetrieveToken.cs.
                    //return await Task.FromResult("MyToken"); ToDo
                    return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MjIzMjY3Nn0.PBXTrHZEehGTnA4dtREyfsMJxKobl_v4xV0ej3fXbKrnHRsHyfMMGAFnpP7Mbg5cjp2Pi6S9aszOLhKTFU47e22XQdsHiuG4iWuKIMToLce1IBhfdnxD9XWD70kwUGTMSWU1gHqdyStpRB5c5P47XH55HqL0JQ4JuI3GuWuV1t1jin0zFw3NgDqiey0I-utXcQMnZ2m0Yx_lnAtnpUCOoV59alOQzdoygGUgG-J4cMChHuKrIE6oPm5DEHH7CgZfsSQql-d3iBWMPQzccAf4xyj4L9NzGmBTmYJdXnsBYSz-BumBN0hag17UDFeVdtyOn6Jsx4frEFI8EtaLMq6o2g");
                });

            // Get the Streaming.SDK service.
            var serviceProvider = services.BuildServiceProvider();
            Streaming = serviceProvider.GetRequiredService<IService>();
        }
    }
}