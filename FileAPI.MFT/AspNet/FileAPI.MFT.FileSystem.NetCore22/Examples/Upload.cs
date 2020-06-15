using FileAPI.MFT.Utils;
using Ftaas.Sdk.Base;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FileAPI.MFT.FileSystem.NetCore22.Examples
{
    public class Upload : Startup
    {
        public Upload(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task UploadOneFile()
        {
            // To upload a file you need to provide the path of the file and the BusinessType where it's going to be uploaded.
            // Also, if you have a multitenant-token, the tenantId needs to be provided.

            Output.WriteTittle("Executing FileSystem.SDK example: Upload one file");

            // Configure the file that is going to be uploaded.
            var tenantId = "MyTenantId"; // FILLME Only necessary for multi-tenant token.

            var fileName = "testFile50kb.txt";
            var filePath = Path.Combine(FilesBaseDirectory, "Data", fileName);
            var request = new FileUploadRequest
            {
                Name = "testFile50kb.txt",
                BusinessTypeId = 0 // FILLME Use the desired businessType.
            };

            // Upload the file.
            var uploadResult = await FileSystem.UploadFileAsync(request, filePath, tenantId: tenantId);

            // Print the result.
            Output.WriteLine("File was uploaded:");
            Output.WriteJson(uploadResult);
        }

        [Fact]
        public async Task UploadTwoFilesInParallel()
        {
            // As the call is asynchronous, it is possible to do several calls in parallel.

            Output.WriteTittle("Executing FileSystem.SDK example: Upload two files in parallel");

            // Configure the files that are going to be uploaded.
            var tenantId = "MyTenantId"; // FILLME Only necessary for multi-tenant token.

            var bigFileName = "testFile10mb.yml";
            var bigFilePath = Path.Combine(FilesBaseDirectory, "Data", bigFileName);
            var bigFileRequest = new FileUploadRequest
            {
                Name = "testFile10mb.yml",
                BusinessTypeId = 0 // FILLME Use the desired businessType.
            };

            var smallFileName = "testFile50kb.txt";
            var smallFilePath = Path.Combine(FilesBaseDirectory, "Data", smallFileName);
            var smallFileRequest = new FileUploadRequest
            {
                Name = "testFile50kb.txt",
                BusinessTypeId = 0 // FILLME Use the desired businessType.
            };

            // Upload the files.
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
