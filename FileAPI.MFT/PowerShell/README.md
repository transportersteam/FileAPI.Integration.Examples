# File API Powershell Examples

PowerShell folder includes a collection of examples that show how to integrate the File API SDK with Powershell.

## Getting Started

Download PowerShell folder. Required data is commented in the example powershell scripts. Fill required data and run the example scripts as described in Running Examples section.

### Prerequisites

Minimim requirement is PowerShell V3. For PowerShell V3 before running the scripts TLS setting must be set by using the following PowerShell script:

```powershell
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12 -bor [Net.SecurityProtocolType]::Tls11 -bor [Net.SecurityProtocolType]::Tls
```

## Running Examples

Powershell scripts provide examples for listing, downloading and uploading files from File Api. Each operation starts with importing the required libraries and getting a file system service instance. Each powershell script is explained in below sub sections.

### Importing libraries

The powershell script **Import.ps1** imports the required libraries.

```powershell
## Imports 
Write-Host "Importing libraries..." -ForegroundColor Green
Import-Module .\libraries\Newtonsoft.Json.dll
Import-Module .\libraries\Microsoft.Extensions.Logging.Abstractions.dll
Import-Module .\libraries\Microsoft.Extensions.Logging.dll
Import-Module .\libraries\Microsoft.Extensions.DependencyInjection.Abstractions.dll
Import-Module .\libraries\Microsoft.Extensions.DependencyInjection.dll
Import-Module .\libraries\Ftaas.Sdk.Base.dll
Import-Module .\libraries\Ftaas.Sdk.Streaming.dll
Import-Module .\libraries\Ftaas.Sdk.FileSystem.dll
Import-Module .\libraries\Ftaas.Sdk.Factory.dll
Write-Host ""
```

### Get service module

The powershell module **GetService.psm1** creates a returns a file system service instance. 

```powershell
function GetFileApiFileSystemService{
    Param(
		[parameter(Mandatory=$true)]
		$mftServiceBaseAddress,
		
		[parameter(Mandatory=$true)]
		$token
    )
    ## Configuration
	Write-Host "Creating configuration..." -ForegroundColor Green
	$options = new-object Ftaas.Sdk.Factory.ServiceWrapperOptions
	$options.MftServiceBaseAddress = $mftServiceBaseAddress
	Write-Host "MFT service base address: " -ForegroundColor Yellow -NoNewline 
	Write-Host $options.MftServiceBaseAddress -ForegroundColor White
	Write-Host ""
	## Get service
	Write-Host "Creating service..." -ForegroundColor Green
	$serviceFactory = new-object Ftaas.Sdk.Factory.ServiceFactory
	$fileSystemService = $serviceFactory.GetServiceInstance($options)
	Write-Host ""
	## Authorize service
	Write-Host "Authorizing service..." -ForegroundColor Green
	$fileSystemService.Authorize($token)
	Write-Host "Authentication token: " -ForegroundColor Yellow -NoNewline 
	Write-Host $token -ForegroundColor White
	Write-Host ""
	return $fileSystemService
}
```

### Listing files

The powershell script **ListFiles.ps1** lists the available files. Following parameters need to be provided:

- **$mftServiceBaseAddress**: File Api end point (Production end point: https://api.raet.com/mft/v1.0/)
- **$token**: Jwt token (needs to be obtained using client id and client secret from Identity Api).
- **$tenantId**: Tenant id the files belong (is optional)

```powershell
## Imports 
& './Import.ps1'

## Import get service module
Import-Module ".\GetService.psm1" -Force

## List files
Write-Host "Listing files..." -ForegroundColor Green
$tenantId = "a valid tenant id"
Write-Host "Tenant id (optional): " -ForegroundColor Yellow -NoNewline 
Write-Host $tenantId -ForegroundColor White
$mftServiceBaseAddress = "https://api.raet.com/mft/v1.0/"
$token = "a valid jwt token is required"
$fileSystemService = GetFileApiFileSystemService $mftServiceBaseAddress $token
$pagination = new-object Ftaas.Sdk.Base.Pagination
$cancellationToken = new-object System.Threading.CancellationToken
$result = $fileSystemService.GetAvailableFilesAsync($tenantId,$pagination,$cancellationToken).GetAwaiter().GetResult() 

## Show the result
$files = New-Object System.Collections.ArrayList 
foreach($fileInfo in $result.Data) 
{	
	$file = [ordered]@{
	"FileId"=$fileInfo.FileId; 
	"FileName"=$fileInfo.FileName; 
	"FileSize"=$fileInfo.FileSize;
	"TenantId"=$fileInfo.TenantId;
	"businessType"=[ordered]@{
		"Id"=$fileInfo.BusinessType.Id; 
		"Name"=$fileInfo.BusinessType.Name};
	"PublisherId"=$fileInfo.PublisherId;
	"UploadDate"=$fileInfo.UploadDate.ToString();
	"Downloaded"=$fileInfo.Downloaded}	
	$files.Add($file)| out-null
}
$resultJson = [ordered]@{"Data"=$files; "PageIndex"=$result.PageIndex; "PageSize"=$result.PageSize; "Count"=$result.Count}
$resultJson |  ConvertTo-Json -Depth 10 
```

### Downloading a file

The powershell script **DownloadFile.ps1** downloads the file specified by file id. Following parameters need to be provided:

- **$mftServiceBaseAddress**: File Api end point (Production end point: https://api.raet.com/mft/v1.0/)
- **$token**: Jwt token (needs to be obtained using client id and client secret from Identity Api).
- **$tenantId**: Tenant id the files belong (is optional).
- **$fileId**: Identifier of the file.
- **$filePath**: Full file name describing where the file will be downloaded (ex: c:\files\myFile.txt)

```powershell
## Imports 
& './Import.ps1'

## Import get service module
Import-Module ".\GetService.psm1" -Force

## Download file
Write-Host "Download file..." -ForegroundColor Green
$fileId = "a valid file id required"
$filePath = "a valid file path required"
$tenantId = "a valid tenant id"
Write-Host "File id: " -ForegroundColor Yellow -NoNewline 
Write-Host $fileId -ForegroundColor White
Write-Host "File path: " -ForegroundColor Yellow -NoNewline 
Write-Host $filePath -ForegroundColor White
Write-Host "Tenant id (optional): " -ForegroundColor Yellow -NoNewline 
Write-Host $tenantId -ForegroundColor White
$mftServiceBaseAddress = "https://api.raet.com/mft/v1.0/"
$token = "a valid jwt token is required"
$fileSystemService = GetFileApiFileSystemService $mftServiceBaseAddress $token
$cancellationToken = new-object System.Threading.CancellationToken
$fileSystemService.DownloadFileAsync($fileId,$filePath,$tenantId,$cancellationToken).GetAwaiter().GetResult()
```

### Uploading a file

The powershell script **UploadFile.ps1** uploads a file to File Api. Following parameters need to be provided:

- **$mftServiceBaseAddress**: File Api end point (Production end point: https://api.raet.com/mft/v1.0/)
- **$token**: Jwt token (needs to be obtained using client id and client secret from Identity Api).
- **$tenantId**: Tenant id the files belong (is optional).
- **$businessTypeId**: Associated business type id of the file..
- **$filePath**: Full file name describing where the file will be downloaded (ex: c:\files\myFile.txt)

```powershell
## Imports 
& './Import.ps1'

## Import get service module
Import-Module ".\GetService.psm1" -Force

## Upload file
Write-Host "Uploading file..." -ForegroundColor Green
$businessTypeId = 0
$filePath = "a valid file path required"
$tenantId = "a valid tenant id"
Write-Host "Bussiness type id: " -ForegroundColor Yellow -NoNewline 
Write-Host $businessTypeId -ForegroundColor White
Write-Host "File name with path: " -ForegroundColor Yellow -NoNewline 
Write-Host $filePath -ForegroundColor White
Write-Host "Tenant id (optional): " -ForegroundColor Yellow -NoNewline 
Write-Host $tenantId -ForegroundColor White
$mftServiceBaseAddress = "https://api.raet.com/mft/v1.0/"
$token = "a valid jwt token is required"
$fileSystemService = GetFileApiFileSystemService $mftServiceBaseAddress $token
$cancellationToken = new-object System.Threading.CancellationToken
$fileSystemService.UploadFileAsync($businessTypeId,$filePath,$tenantId,$cancellationToken).GetAwaiter().GetResult() | ConvertTo-Json

```

## Authors

**Visma - Transporters Team**

