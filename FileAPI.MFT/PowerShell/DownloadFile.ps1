## Imports 
Write-Host "Importing libraries..." -ForegroundColor Green
& './Import.ps1'
Write-Host ""

## Configuration
Write-Host "Creating configuration..." -ForegroundColor Green
$options = new-object Ftaas.Sdk.Factory.ServiceWrapperOptions
$options.MftServiceBaseAddress = "https://api.raet.com/mft/v1.0/"
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
$token = "a valid jwt token is required"
$fileSystemService.Authorize($token)
Write-Host "Authentication token: " -ForegroundColor Yellow -NoNewline 
Write-Host $token -ForegroundColor White
Write-Host ""

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
$fileSystemService.DownloadFileAsync($fileId,$filePath,$tenantId)
