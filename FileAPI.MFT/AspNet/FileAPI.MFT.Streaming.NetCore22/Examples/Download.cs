using FileAPI.MFT.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FileInfo = Ftaas.Sdk.Base.FileInfo;

namespace FileAPI.MFT.Streaming.NetCore22.Examples
{
    public class Download : Startup
    {
        public Download(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task DownloadOneFile()
        {
            #region Custom parameters

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            #endregion

            Output.WriteTittle("Executing Streaming.SDK example: Download one file");

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileInfo = GetRandomUploadedFile(tenantId);
            var fileId = fileInfo.FileId.ToString();

            using (var ms = new MemoryStream())
            {
                await Streaming.DownloadFileAsync(fileId, ms, tenantId: tenantId);

                Assert.Equal(fileInfo.FileSize, ms.Length);
                Output.WriteLine($"File <{fileId}>. Content downloaded.");
            }
        }

        [Fact]
        public async Task DownloadOneFileAndSaveItInFileSystem()
        {
            #region Custom parameters

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            #endregion

            Output.WriteTittle("Executing Streaming.SDK example: Download one file and save the content in a file system");

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileInfo = GetRandomUploadedFile(tenantId);
            var fileId = fileInfo.FileId.ToString();

            var filePath = Path.Combine(FilesBaseDirectory, "downloadedFile.txt");
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await Streaming.DownloadFileAsync(fileId, fs, tenantId: tenantId);

                Assert.Equal(fileInfo.FileSize, fs.Length);
                Assert.True(File.Exists(filePath), $"File was not downloaded correctly to {filePath}");
                Output.WriteLine($"File <{fileId}> downloaded at {filePath}");
            }
        }

        [Fact]
        public async Task DownloadTwoFilesInParallel()
        {
            #region Custom parameters

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            #endregion

            // As the call is asynchronous, it is possible to do several calls in parallel.

            Output.WriteTittle("Executing Streaming.SDK example: Download two files in parallel");

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileInfoFirst = GetRandomUploadedFile(tenantId);
            var fileIdFirst = fileInfoFirst.FileId.ToString();

            var fileInfoSecond = GetRandomUploadedFile(tenantId);
            var fileIdSecond = fileInfoSecond.FileId.ToString();

            using (var msFirstFile = new MemoryStream())
            using (var msSecondFile = new MemoryStream())
            {
                Output.WriteLine($"Downloading files <{fileIdFirst}> and <{fileIdSecond}>.");

                var downloadTasks = new List<Task>
                {
                    Streaming.DownloadFileAsync(fileIdFirst, msFirstFile, tenantId: tenantId),
                    Streaming.DownloadFileAsync(fileIdSecond, msSecondFile, tenantId: tenantId)
                };

                // Wait for the files to be downloaded and print the results.
                // If you only care about all files being downloaded and not the order, you can use Task.WhenAll instead.
                var firstDownloadedFile = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(firstDownloadedFile);
                
                Assert.True(fileInfoFirst.FileSize == msFirstFile.Length || fileInfoSecond.FileSize == msSecondFile.Length,
                    "The downloaded stream doesn't contain the uploaded content.");
                Output.WriteLine($"File <{fileIdFirst}>. Content downloaded.");

                await Task.WhenAny(downloadTasks);

                Assert.True(fileInfoFirst.FileSize == msFirstFile.Length && fileInfoSecond.FileSize == msSecondFile.Length,
                     "The downloaded stream doesn't contain the uploaded content.");
                Output.WriteLine($"File <{fileIdSecond}>. Content downloaded.");
            }
        }

        #region Helper methods

        private static readonly Random _random = new Random();

        private FileInfo GetRandomUploadedFile(string tenantId)
        {
            var filter = "Status eq 'All'";
            var randomUploadedFile = Streaming.GetAvailableFilesAsync(filter: filter, tenantId: tenantId).Result.Data;

            if (!randomUploadedFile.Any())
                throw new ArgumentOutOfRangeException(
                    $"No uploaded file for tenantId <{tenantId}>. Please, execute the UploadExamples tests before theses.");

            return randomUploadedFile
                .ElementAt(_random.Next(randomUploadedFile.Count()));
        }

        #endregion
    }
}
