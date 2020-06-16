using Ftaas.Sdk.FileSystem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
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
                    //return await Task.FromResult("MyToken"); ToDo
                    return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MjI5NjIyOX0.Ih1FZmg8GlM8TRqM1ApnfVoJG3HSLhwTBWNz_RNYh6SQa5n54cJautcoKGebGosBg022E3pbzk-unWJmaphVvwfYW23yS500TdWQaLXgxgpo4TX7WX9H8f_0jfDOGWGBjERUhUoflsaYhwtdqCPWB0q-vFGsqoB21pCn2mavElhWXbHs5lNQhoaaE_PN47dccXzCyjQdHSno62JvXvm7wNerGE4WCsjXxifLNnwREi5oS65TWeMQQiGKYESanZFj4Np7N4WB5jjgrSDM74TL3pwtdtsP2A5JbeBHb-9KtMrIXlenj0KKECpoOXTkfJR9yLgNpCB9rRiqGpr7OPijzQ");
                });

            // Get the FileSystem.SDK service.
            var serviceProvider = services.BuildServiceProvider();
            FileSystem = serviceProvider.GetRequiredService<IService>();
        }
    }
}