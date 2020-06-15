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
$fileSystemService.GetAvailableFilesAsync($tenantId,$pagination,$cancellationToken).GetAwaiter().GetResult() | ConvertTo-Json