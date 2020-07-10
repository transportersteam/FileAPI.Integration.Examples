## Imports 
& './Import.ps1'

## Import get service module
Import-Module ".\GetService.psm1" -Force

## Custom parameters
$tenantId = "MyTenantId" # Only necessary for multi-tenant token.
$longFileId = "FileId" # Id of a big file that is going to be downloaded.
$fileId = "FileId" # Id of another file that is going to be downloaded.
$longFilePath = "DownloadPathWithFileName" # Path where the big file is going to be downloaded (the path must include the file name).
$filePath = "DownloadPathWithFileName" # Path where the other file is going to be downloaded (the path must include the file name).

$mftServiceBaseAddress = "https://api.raet.com/mft/v1.0/" # Change it if you want to use another environment.
$token = "MyToken" # Authentication token. You can use RetrieveToken.ps1 to get one.
$clientTimeout = 180 # 60x3 = three minutes before giving timeout error 

## Download file
Write-Host "Download file..." -ForegroundColor Green
Write-Host "File id: " -ForegroundColor Yellow -NoNewline 
Write-Host $fileId -ForegroundColor White
Write-Host "File path: " -ForegroundColor Yellow -NoNewline 
Write-Host $filePath -ForegroundColor White
Write-Host "Tenant id (optional): " -ForegroundColor Yellow -NoNewline 
Write-Host $tenantId -ForegroundColor White
## Instance the fileSystemService with a longer timeout will allow to wait more for big files
$fileSystemService = GetFileApiFileSystemService $mftServiceBaseAddress $token $clientTimeout
$cancellationToken = new-object System.Threading.CancellationToken
$result = $fileSystemService.DownloadFileAsync($longFileId,$longFilePath,$tenantId,$cancellationToken).GetAwaiter().GetResult()

## The cancelation token source can be used to specify a shorter timeout
$tokenSource = new-object System.Threading.CancellationTokenSource
$tokenSource.CancelAfter(300)
$result = $fileSystemService.DownloadFileAsync($fileId,$filePath,$tenantId,$tokenSource.Token).GetAwaiter().GetResult()
