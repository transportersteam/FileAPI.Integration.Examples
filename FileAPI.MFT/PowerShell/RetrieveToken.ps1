## Custom parameters
$clientId = "MyClientId"
$clientSecret = "MyClientSecret"
$identityAddress = "https://api.raet.com/authentication/token" # Change it if you want to use another environment.

## Retrieve token
Write-Host "Retrieving token..." -ForegroundColor Green
Write-Host ""
Write-Host "Client "-ForegroundColor Yellow -NoNewline
Write-Host $clientId -ForegroundColor White
Write-Host ""
$body = @{
	grant_type="client_credentials"
    client_id=$clientId
	client_secret=$clientSecret
}
$contentType = 'application/x-www-form-urlencoded'
$response = Invoke-WebRequest -Method POST -Uri $identityAddress -Body $body -ContentType $contentType

## Show the result
$content = $response.Content | ConvertFrom-Json
Write-Host "Authentication token: " -ForegroundColor Yellow -NoNewline 
Write-Host $content.access_token -ForegroundColor White
Write-Host ""
