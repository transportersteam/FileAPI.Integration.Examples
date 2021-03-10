
File API SDKs
=========

[![Build Status](https://dev.azure.com/raet/RaetOnline/_apis/build/status/Team%20Transporters/FTaaS/Ftaas.Sdk?branchName=master)](https://dev.azure.com/raet/RaetOnline/_build/latest?definitionId=4631&branchName=master)

Library that allows to send and receive files to the File API.
It comes in two different flavors: [VismaRaet.FileApi.Sdk.FileSystem](#vismaraet.fileapi.sdk.filesystem) and [VismaRaet.FileApi.Sdk.Streaming](#vismaraet.fileapi.sdk.streaming). The first one allows 
to send and receive files directly on your file system, while the second is more configurable, as the source of the files are streams.

# VismaRaet.FileApi.Sdk.FileSystem #

Integrate with File API with file system sources, sending and downloading files from and into directories.


## Getting started ##

1. Install the file system Nuget package into your ASP.NET Core application.

    ```
    Package Manager : Install-Package VismaRaet.FileApi.Sdk.FileSystem -Version 1.0.0
    CLI : dotnet add package VismaRaet.FileApi.Sdk.FileSystem --version 1.0.0
    ```

2. In the `ConfigureServices` method of `Startup.cs`, register the FileSystem integrator.

    ```csharp
    using Ftaas.Sdk.FileSystem;
    ```

    ```csharp
    services.AddFileSystemService(
                            options =>
                            {
                                options.MftServiceBaseAddress = mftService;
                                options.ChunkMaxBytesSize = Configuration.GetValue<int>("chunk_max_bytes_size");
                                options.ClientTimeout = Configuration.GetValue<int>("client_timeout");
                                options.ConcurrentConnectionsCount = Configuration.GetValue<byte>("concurrent_connections");
                            },
                            async (serviceProvider) =>
                            {
                                await serviceProvider.GetRequiredService<ISecureStore>().TryRetrieveAsync<string>($"ftaascli:{mftService}", out var serializedLoginSession);
                                var loginSession = JsonConvert.DeserializeObject<LoginSession>(serializedLoginSession);
                                var bearerToken = loginSession.AuthorizationToken;
                                bearerToken.ValidateJwtToken();
                                return bearerToken;
                            });
    ```

    `IServiceCollection AddFileSystemService(
            this IServiceCollection services,
            Action<ServiceConfigurationOptions> optionsConfiguration,
            Func<IServiceProvider, Task<string>> bearerTokenFactory)`\
    `optionConfiguration`: File API base address, maximum chunk size (0 - 4194304 bytes) and number of concurrent connections (1 - 6).\
    `bearerTokenFactory`: Function that retrieves an authorization token.

## Usage ##

### Upload ###

`UploadFileAsync` uploads a file and returns the metadata of the file created on the File API: The Id can be used to download the file by the subscribers.

_NOTE: If the file size is greater than the maximum chunk size configured, it will be uploaded by chunks._

#### Task<FileUploadInfo> UploadFileAsync(FileUploadRequest request, string filePath, string tenantId, CancellationToken cancellationToken) ####
`request`: composed by fileName and bussinessTypeId.\
`filePath`: absolute path of the file to upload.\
`tenantId`: (optional) tenantId.\
`cancellationToken`: (optional) the CancellationToken that the upload task will observe.

### Download ###

`DownloadFileAsync` downloads the requested file on the specified path.

_NOTE: If the file already exists, it will be replaced with the downloaded one._

#### Task DownloadFileAsync(string fileId, string filePath, string tenantId, CancellationToken cancellationToken) ####
`fileId`: GUID of the file to download.\
`filePath`: absolute path of the file to download.\
`tenantId`: (optional) tenantId.\
`cancellationToken`: (optional) the CancellationToken that the download task will observe.

### List ###

`GetAvailableFilesAsync` retrieves a list of metadatas of the available files.

_NOTE: Files that have already been downloaded won't be listed unless it's specified by the filters._

#### Task<PaginatedItems<FileInfo>> GetAvailableFilesAsync(long businessTypeId, Pagination pagination, string tenantId, CancellationToken cancellationToken) ####
`businessTypeId`: (optional) if specified, only the files of this bussiness type will be listed.\
`pagination`: (optional) if specified, the list will have the specified items size and will be the index page. If not, the first twenty files metadata will be retrieved.\
`tenantId`: (optional) tenantId.\
`cancellationToken`: (optional) the CancellationToken that the list task will observe.

# VismaRaet.FileApi.Sdk.Streaming #

Integrate with the File API with stream sources.

## Getting started ##

1. Install the streams Nuget package into your ASP.NET Core application.

    ```
    Package Manager : Install-Package VismaRaet.FileApi.Sdk.Streaming -Version 1.0.0
    CLI : dotnet add package VismaRaet.FileApi.Sdk.Streaming --version 1.0.0
    ```

2. In the `ConfigureServices` method of `Startup.cs`, register the Streaming integrator.

    ```csharp
    using Ftaas.Sdk.Streaming;
    ```
    
    ```csharp
    services.AddStreamingService(
                            options =>
                            {
                                options.MftServiceBaseAddress = mftService;
                                options.ChunkMaxBytesSize = Configuration.GetValue<int>("chunk_max_bytes_size");
                                options.ConcurrentConnectionsCount = Configuration.GetValue<byte>("concurrent_connections");
                            },
                            async (serviceProvider) =>
                            {
                                await serviceProvider.GetRequiredService<ISecureStore>().TryRetrieveAsync<string>($"ftaascli:{mftService}", out var serializedLoginSession);
                                var loginSession = JsonConvert.DeserializeObject<LoginSession>(serializedLoginSession);
                                var bearerToken = loginSession.AuthorizationToken;
                                bearerToken.ValidateJwtToken();
                                return bearerToken;
                            });
    ```

    `IServiceCollection AddStreamingService(
            this IServiceCollection services,
            Action<ServiceConfigurationOptions> optionsConfiguration,
            Func<IServiceProvider, Task<string>> bearerTokenFactory)`\
    `optionConfiguration`: File API base address, maximum chunk size (0 - 4194304 bytes) and number of concurrent connections (1 - 6).\
    `bearerTokenFactory`: Function that retrieves an authorization token.

## Usage ##

### Upload ###

`UploadFileAsync` uploads a file and returns the metadata of the file created on the File API: The Id can be used to download the file by the subscribers.

_NOTE: If the file size is greater than the maximum chunk size configured, it will be uploaded by chunks._

#### Task<FileUploadInfo> UploadFileAsync(FileUploadRequest request, Stream fileStream, string tenantId, CancellationToken cancellationToken) ####
`request`: composed by fileName and bussinessTypeId.\
`fileStream`: stream containing the bytes of the file.\
`tenantId`: (optional) tenantId.\
`cancellationToken`: (optional) the CancellationToken that the upload task will observe.

### Download ###

`DownloadFileAsync` downloads the requested file on the specified path.

#### Task DownloadFileAsync(string fileId, Stream fileStream, string tenantId, CancellationToken cancellationToken) ####
`fileId`: GUID of the file to download.\
`fileStream`: stream where the bytes of the file will be stored.\
`tenantId`: (optional) tenantId.\
`cancellationToken`: (optional) the CancellationToken that the download task will observe.

### List ###

`GetAvailableFilesAsync` retrieves a list of metadatas of the available files.

_NOTE: Files that have already been downloaded won't be listed unless it's specified by the filters._

#### Task<PaginatedItems<FileInfo>> GetAvailableFilesAsync( long businessTypeId, Pagination pagination, string tenantId, CancellationToken cancellationToken) ####
`businessTypeId`: (optional) if specified, only the files of this bussiness type will be listed.\
`pagination`: (optional) if specified, the list will have the specified items size and will be the index page. If not, the first twenty files metadata will be retrieved.\
`tenantId`: (optional) tenantId.\
`cancellationToken`: (optional) the CancellationToken that the list task will observe.
