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
