## Retrieve token
Write-Host "Retrieving token..." -ForegroundColor Green
$clientId = "a valid client id"
$clientSecret = "a valid client secret"
$identityAddress = "https://api.raet.com/authentication/token"
$body = @{
	grant_type="client_credentials"
    client_id=$clientId
	client_secret=$clientSecret
}
$contentType = 'application/x-www-form-urlencoded'
$response = Invoke-WebRequest -Method POST -Uri $identityAddress -Body $body -ContentType $contentType

## Show the result
$content = $response.Content | ConvertFrom-Json
Write-Host "Authentication token for client " -ForegroundColor Yellow -NoNewline
Write-Host $clientId -ForegroundColor White -NoNewLine
Write-Host ":" -ForegroundColor Yellow
Write-Host $content.access_token
