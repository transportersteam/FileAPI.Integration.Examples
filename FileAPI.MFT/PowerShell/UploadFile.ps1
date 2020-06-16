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
$result = $fileSystemService.UploadFileAsync($businessTypeId,$filePath,$tenantId,$cancellationToken).GetAwaiter().GetResult()

## Show the result
$file = [ordered]@{
	"Id"=$result.Id; 
	"Name"=$result.Name; 
	"Size"=$result.Size;
	"CreationDate"=$result.CreationDate.ToString();
	"BusinessType"=[ordered]@{
		"Id"=$result.BusinessType.Id; 
		"Name"=$result.BusinessType.Name};
	"NumChunks"=$result.NumChunks;}
$file |  ConvertTo-Json -Depth 10 
