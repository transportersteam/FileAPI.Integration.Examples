using FileAPI.MFT.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FileAPI.MFT.Streaming.NetCore22
{
    public class DownloadExamples : ExamplesBase
    {
        public DownloadExamples(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task DownloadOneFile()
        {
            Output.WriteTittle("Executing Streaming.SDK example: Download one file");

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileId = GetRandomUploadedFileId(tenantId);

            using (var ms = new MemoryStream())
            {
                await Streaming.DownloadFileAsync(fileId, ms, tenantId: tenantId);
                Output.WriteLine($"File downloaded <{fileId}>.");
            }
        }

        [Fact]
        public async Task DownloadOneFileAndSaveItInFileSystem()
        {
            Output.WriteTittle("Executing Streaming.SDK example: Download one file and save the content in a file system");

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileId = GetRandomUploadedFileId(tenantId);

            var filePath = Path.Combine(FilesBaseDirectory, "downloadedFile.txt");
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await Streaming.DownloadFileAsync(fileId, fs, tenantId: tenantId);
                Output.WriteLine($"File downloaded at {filePath}");
            }
        }

        [Fact]
        public async Task DownloadTwoFilesInParallel()
        {
            // As the call is asynchronous, it is possible to do several calls in parallel.

            Output.WriteTittle("Executing Streaming.SDK example: Download two files in parallel");

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileIdFirst = GetRandomUploadedFileId(tenantId);
            var fileIdSecond = GetRandomUploadedFileId(tenantId);

            using (var msFirstFile = new MemoryStream())
            using (var msSecondFile = new MemoryStream())
            {
                var downloadTasks = new List<Task>
                {
                    Streaming.DownloadFileAsync(fileIdFirst, msFirstFile, tenantId: tenantId),
                    Streaming.DownloadFileAsync(fileIdSecond, msSecondFile, tenantId: tenantId)
                };

                // Wait for the files to be downloaded and print the results.
                // If you only care about all files being downloaded and not the order, you can use Task.WhenAll instead.
                var firstDownloadedFile = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(firstDownloadedFile);
                Output.WriteLine($"File Downloaded <{fileIdFirst}>");

                await Task.WhenAny(downloadTasks);
                Output.WriteLine($"File Downloaded <{fileIdSecond}>");
            }
        }

        #region Helper methods

        private static readonly Random _random = new Random();

        private string GetRandomUploadedFileId(string tenantId)
        {
            var filter = "Status eq 'All'";
            var randomUploadedFile = Streaming.GetAvailableFilesAsync(filter: filter, tenantId: tenantId).Result.Data;

            if (!randomUploadedFile.Any())
                throw new ArgumentOutOfRangeException(
                    $"No uploaded file for tenantId: {tenantId}. Please, execute the UploadExamples tests before theses.");

            return randomUploadedFile
                .ElementAt(_random.Next(randomUploadedFile.Count()))
                .FileId.ToString();
        }

        #endregion
    }
}
