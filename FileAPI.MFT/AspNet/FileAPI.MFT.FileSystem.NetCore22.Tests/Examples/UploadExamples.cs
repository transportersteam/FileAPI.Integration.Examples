using Ftaas.Sdk.Base;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FileAPI.MFT.FileSystem.NetCore22.Tests.Examples
{
    public class UploadTests : TestBase
    {
        public UploadTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task UploadOneFile()
        {
            // To upload a file you need to provide the path of the file and the BusinessType where it's going to be uploaded.
            // Also, if you have a multitenant-token, the tenantId needs to be provided.

            Output.WriteTittle("Executing example: Upload one file");

            // Configure the file that is going to be uploaded.
            //var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.
            var tenantId = "6401970";

            var fileName = "testFile50kb.txt";
            var filePath = Path.Combine(UploadDirectory, fileName);
            var request = new FileUploadRequest
            {
                Name = "testFile50kb.txt",
                BusinessTypeId = 8000
            };

            // Upload the file
            var uploadResult = await FileSystem.UploadFileAsync(request, filePath, tenantId: tenantId);

            // Print the result
            Output.WriteLine("File was uploaded:");
            Output.WriteJson(uploadResult);
        }

        [Fact]
        public async Task UploadTwoFilesInParallel()
        {
            // As the call is asynchronous, it is possible to do several calls in parallel.

            Output.WriteTittle("Executing example: Upload two files in parallel");

            // Configure the files that are going to be uploaded.
            //var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.
            var tenantId = "6401970";

            var bigFileName = "testFile10mb.yml";
            var bigFilePath = Path.Combine(UploadDirectory, bigFileName);
            var bigFileRequest = new FileUploadRequest
            {
                Name = "testFile10mb.yml",
                BusinessTypeId = 8000
            };

            var smallFileName = "testFile50kb.txt";
            var smallFilePath = Path.Combine(UploadDirectory, smallFileName);
            var smallFileRequest = new FileUploadRequest
            {
                Name = "testFile50kb.txt",
                BusinessTypeId = 8000
            };

            // Upload the files
            var uploadTasks = new List<Task<FileUploadInfo>>
            {
                FileSystem.UploadFileAsync(bigFileRequest, bigFilePath, tenantId: tenantId),
                FileSystem.UploadFileAsync(smallFileRequest, smallFilePath, tenantId: tenantId)
            };

            // Wait for the files to be uploaded and print the results.
            // If you only care about all files being uploaded and not the order, you can use Task.WhenAll instead.
            var firstUploadedFile = await Task.WhenAny(uploadTasks);
            uploadTasks.Remove(firstUploadedFile);

            Output.WriteLine("First uploaded file:");
            Output.WriteJson(firstUploadedFile.Result);

            var secondUploadedFile = await Task.WhenAny(uploadTasks);

            Output.WriteLine("Second uploaded file:");
            Output.WriteJson(secondUploadedFile.Result);
        }
    }
}
