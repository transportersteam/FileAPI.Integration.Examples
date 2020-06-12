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

## List files
Write-Host "Listing files..." -ForegroundColor Green
$tenantId = "a valid tenant id"
Write-Host "Tenant id (optional): " -ForegroundColor Yellow -NoNewline 
Write-Host $tenantId -ForegroundColor White
$fileSystemService.GetAvailableFilesAsync($tenantId).GetAwaiter().GetResult() | ConvertTo-Json
