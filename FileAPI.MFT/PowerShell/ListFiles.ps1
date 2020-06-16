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
	"BusinessType"=[ordered]@{
		"Id"=$fileInfo.BusinessType.Id; 
		"Name"=$fileInfo.BusinessType.Name};
	"PublisherId"=$fileInfo.PublisherId;
	"UploadDate"=$fileInfo.UploadDate.ToString();
	"Downloaded"=$fileInfo.Downloaded}	
	$files.Add($file)| out-null
}
$resultJson = [ordered]@{"Data"=$files; "PageIndex"=$result.PageIndex; "PageSize"=$result.PageSize; "Count"=$result.Count}
$resultJson |  ConvertTo-Json -Depth 10 