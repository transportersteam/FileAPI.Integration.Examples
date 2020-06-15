using FileAPI.MFT.Utils;
using Ftaas.Sdk.Base;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FileAPI.MFT.Streaming.NetCore22.Examples
{
    public class Upload : Startup
    {
        public Upload(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async void UploadOneFile()
        {
            // To upload a file you need to provide the path of the file and the BusinessType where it's going to be uploaded.
            // Also, if you have a multitenant-token, the tenantId needs to be provided.

            Output.WriteTittle("Executing Streaming.SDK example: Upload one file by Stream");

            // Configure the file that is going to be uploaded.
            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            var fileContent = "Cats have contributed to the extinction of 33 different species. Humans might be the next ones.";
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));

            var request = new FileUploadRequest
            {
                Name = "testStreamFile.txt",
                BusinessTypeId = 0 // Use the desired businessType.
            };

            // Upload the file.
            var uploadResult = await Streaming.UploadFileAsync(request, ms, tenantId: tenantId);

            // Print the result.
            Output.WriteLine("File was uploaded:");
            Output.WriteJson(uploadResult);
        }

        [Fact]
        public async void UploadOneFileByStreamFromFile()
        {
            // To upload a file you need to provide the path of the file and the BusinessType where it's going to be uploaded.
            // Also, if you have a multitenant-token, the tenantId needs to be provided.

            Output.WriteTittle("Executing Streaming.SDK example: Upload one file by Stream from file");

            // Configure the file that is going to be uploaded.
            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            var fileName = "testFile.txt";
            var filePath = Path.Combine(FilesBaseDirectory, "Data", fileName);


            // Read a file and store the content into the MemoryStream.
            // If you want to upload directly from the file, check the examples of FileApi.MFT.FileSystem.
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);


                    var request = new FileUploadRequest
                    {
                        Name = "testStreamFile.txt",
                        BusinessTypeId = 0 // Use the desired businessType.
                    };

                    // Reset the position of the memory stream.
                    ms.Position = 0;

                    // Upload the file.
                    var uploadResult = await Streaming.UploadFileAsync(request, ms, tenantId: tenantId);


                    // Print the result.
                    Output.WriteLine("File was uploaded:");
                    Output.WriteJson(uploadResult);
                }
            }
        }

        [Fact]
        public async Task UploadTwoFilesInParallel()
        {
            // As the call is asynchronous, it is possible to do several calls in parallel.

            Output.WriteTittle("Executing Streaming.SDK example: Upload two files in parallel by Stream");

            // Configure the files that are going to be uploaded.
            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            // Create file content and the file request of the first file.
            var file1Content = "Cats have contributed to the extinction of 33 different species. Humans might be the next ones.";
            var ms1 = new MemoryStream(Encoding.UTF8.GetBytes(file1Content));
            var firstFileRequest = new FileUploadRequest
            {
                Name = "testFile1.yml",
                BusinessTypeId = 8000
            };

            // Create file content and file request of the second file.
            var file2Content = "The largest cat breed is the Ragdoll. Male Ragdolls weigh between 12 and 20 lbs (5.4-9.0 k). Females weigh between 10 and 15 lbs (4.5-6.8 k).";
            var ms2 = new MemoryStream(Encoding.UTF8.GetBytes(file2Content));
            var secondFileRequest = new FileUploadRequest
            {
                Name = "testFile2.txt",
                BusinessTypeId = 0 // Use the desired businessType.
            };

            // Upload the files.
            var uploadTasks = new List<Task<FileUploadInfo>>
            {
                Streaming.UploadFileAsync(firstFileRequest, ms1, tenantId: tenantId),
                Streaming.UploadFileAsync(secondFileRequest, ms2, tenantId: tenantId)
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
