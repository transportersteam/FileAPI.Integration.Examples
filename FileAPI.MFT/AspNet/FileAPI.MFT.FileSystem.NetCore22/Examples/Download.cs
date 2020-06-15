using FileAPI.MFT.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FileAPI.MFT.FileSystem.NetCore22.Examples
{
    public class Download : Startup
    {
        public Download(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task DownloadOneFile()
        {
            Output.WriteTittle("Executing FileSystem.SDK example: Download one file");

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileId = GetRandomUploadedFileId(tenantId);

            var downloadPath = Path.Combine(FilesBaseDirectory, "downloadedFile.txt");
            await FileSystem.DownloadFileAsync(fileId, downloadPath, tenantId: tenantId);

            Output.WriteLine($"File downloaded at {downloadPath}");
        }

        [Fact]
        public async Task DownloadTwoFilesInParallel()
        {
            // As the call is asynchronous, it is possible to do several calls in parallel.

            Output.WriteTittle("Executing FileSystem.SDK example: Download two files in parallel");

            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.

            // First you need a valid file ID so you can download it.
            // If you already know the ID of an uploaded file, you can use, instead, that ID.
            var fileIdFirst = GetRandomUploadedFileId(tenantId);
            var fileIdSecond = GetRandomUploadedFileId(tenantId);

            var downloadPathFirst = Path.Combine(FilesBaseDirectory, "downloadedInParallelFile_First.txt");
            var downloadPathSecond = Path.Combine(FilesBaseDirectory, "downloadedInParallelFile_Second.txt");

            var downloadTasks = new List<Task>
            {
                FileSystem.DownloadFileAsync(fileIdFirst, downloadPathFirst, tenantId: tenantId),
                FileSystem.DownloadFileAsync(fileIdSecond, downloadPathSecond, tenantId: tenantId)
            };

            // Wait for the files to be downloaded and print the results.
            // If you only care about all files being downloaded and not the order, you can use Task.WhenAll instead.
            var firstDownloadedFile = await Task.WhenAny(downloadTasks);
            downloadTasks.Remove(firstDownloadedFile);
            Output.WriteLine($"First downloaded file: {downloadPathFirst}");

            await Task.WhenAny(downloadTasks);
            Output.WriteLine($"Second downloaded file: {downloadPathSecond}");
        }

        #region Helper methods

        private static readonly Random _random = new Random();

        private string GetRandomUploadedFileId(string tenantId)
        {
            var filter = "Status eq 'All'";
            var randomUploadedFile = FileSystem.GetAvailableFilesAsync(filter: filter, tenantId: tenantId).Result.Data;

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
