using FileAPI.MFT.Utils;
using Ftaas.Sdk.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FileInfo = Ftaas.Sdk.Base.FileInfo;

namespace FileAPI.MFT.FileSystem.NetCore22
{
    public class ListExamples : ExamplesBase
    {
        public ListExamples(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task ListAvailableFilesWithOneHugeCall()
        {
            // The files are retrieved paginated, so if you want to retrieve all the files, you have two options:
            //     1) Do only one call with a huge page size.
            //     2) Do several calls with more manageable page size.
            // Depending on your requirements, you can choose between any of theses options.
            //
            // In this example it's shown how to do the first option: do only one call to retrieve all the available files.

            Output.WriteTittle("Executing FileSystem.SDK example: List available files with one call");

            // Configure the list.
            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.
            var pagination = new Pagination
            {
                PageIndex = 0,
                PageSize = 1000 // Maximum value. If you have more files than this amount, you will need to use the second option instead.
            };

            // List the files.
            var listResult = await FileSystem.GetAvailableFilesAsync(pagination, tenantId: tenantId);

            // Print the result.
            Output.WriteLine("Available files:");
            Output.WriteJsonPaginatedItemsWithoutData(listResult);
        }

        [Fact]
        public async Task ListAvailableFilesWithSeveralSmallCalls()
        {
            // The files are retrieved paginated, so if you want to retrieve all the files, you have two options:
            //     1) Do only one call with a huge page size.
            //     2) Do several calls with more manageable page size.
            // Depending on your requirements, you can choose between any of theses options.
            // In this example it's shown how to do the second option: do several calls to retrieve all the available files.

            Output.WriteTittle("Executing FileSystem.SDK example: List available files with several small calls");

            // Configure the list.
            // Every call will retrieve 20 files.
            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.
            var pagination = new Pagination
            {
                PageIndex = 0,
                PageSize = 20
            };

            // List the files. Do several calls to the SDK until all files are retrieved.
            PaginatedItems<FileInfo> portionListResult;
            bool areAllFilesRetrieved;
            do
            {
                portionListResult = await FileSystem.GetAvailableFilesAsync(pagination, tenantId: tenantId);
                areAllFilesRetrieved = !portionListResult.Data.Any();

                Output.WriteLine($"Call {pagination.PageIndex + 1} (PageSize = {pagination.PageSize}):");
                Output.WriteJsonPaginatedItemsWithoutData(portionListResult);

                pagination.PageIndex++;
            } while (!areAllFilesRetrieved);
        }

        [Fact]
        public async Task ListFilesFilteredByUploadDate()
        {
            // For the sake of readability, in this test instead of retreiving all files, we will just retrieve some of them.
            // It's possible to filter by upload date, status and business type.
            // For a better understanding of the filters, please review this link:
            // https://raetwiki.atlassian.net/wiki/spaces/SGW/pages/1274840537/Search+for+Files

            Output.WriteTittle("Executing FileSystem.SDK example: List filtered files");

            // Configure the list.
            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.
            var pagination = new Pagination
            {
                PageIndex = 0,
                PageSize = 3
            };

            // UploadDate filter. It will show all files that were uploaded between 2020-05-01 (00:00) and 2020-06-01 (00:00)
            var lowerDate = $"{new DateTime(2020, 05, 01).ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'}";
            var higherDate = $"{new DateTime(2020, 06, 01).ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'}";
            var filter = $"UploadDate ge {lowerDate} and UploadDate le {higherDate}";

            // List the files.
            var listResult = await FileSystem.GetAvailableFilesAsync(pagination, filter: filter, tenantId: tenantId);

            // Print the result.
            Output.WriteLine($"Available files that were uploaded between {lowerDate} and {higherDate}:");
            Output.WriteJson(listResult);
        }

        [Fact]
        public async Task ListFilesFilteredByUploadDateAndStatus()
        {
            // For the sake of readability, in this test instead of retreiving all files, we will just retrieve some of them.
            // It's possible to filter by upload date, status and business type.
            // For a better understanding of the filters, please review this link:
            // https://raetwiki.atlassian.net/wiki/spaces/SGW/pages/1274840537/Search+for+Files

            Output.WriteTittle("Executing FileSystem.SDK example: List filtered files");

            // Configure the list.
            var tenantId = "MyTenantId"; // Only necessary for multi-tenant token.
            var pagination = new Pagination
            {
                PageIndex = 0,
                PageSize = 3
            };

            // UploadDate filter. It will show all files that were uploaded between 2020-05-01 (00:00) and 2020-06-01 (00:00)
            // and has been already downloaded.
            var lowerDate = $"{new DateTime(2020, 05, 01).ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'}";
            var higherDate = $"{new DateTime(2020, 06, 01).ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'}";
            var filter = $"UploadDate ge {lowerDate} and UploadDate le {higherDate} and Status eq 'downloaded'";

            // List the files.
            var listResult = await FileSystem.GetAvailableFilesAsync(pagination, filter: filter, tenantId: tenantId);

            // Print the result.
            Output.WriteLine($"Downloaded files that were uploaded between {lowerDate} and {higherDate}:");
            Output.WriteJson(listResult);
        }
    }
}
