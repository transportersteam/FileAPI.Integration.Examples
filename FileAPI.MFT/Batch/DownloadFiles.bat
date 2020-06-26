@echo off & setlocal

REM Configuration

set clientId=MyClientId
set clientSecret=MyClientSecret
set tenantId=MyTenantId

set fileId1=5297c2a5-690e-4b07-ab3e-86c19d3ce7dd
set name1="tinny file.txt"

set fileId2=5297c2a5-690e-4b07-ab3e-86c19d3ce7dd
set name2="small file.txt"

REM Retrieve token

for /f %%i in (' ^
curl -s -X POST https://api.raet.com/authentication/token ^
-H "Content-Type: application/x-www-form-urlencoded" ^
-H "Cache-Control: no-cache" ^
-d "grant_type=client_credentials&client_id=%clientId%&client_secret=%clientSecret%" ^
') do set response=%%i

set "beforeTokenKey=%response:"access_token":"=" & set "afterTokenKey=%"
set "token=%afterTokenKey:"=" & set "afterToken=%"

REM Download the files

curl https://api.raet.com/mft/v1.0/files/%fileId1%?role=subscriber ^
--header "x-raet-tenant-id: %tenantId%" ^
--header "Authorization: Bearer %token%" ^
-H "Accept: application/octet-stream" ^
--output %name1%

curl https://api.raet.com/mft/v1.0/files/%fileId2%?role=subscriber ^
--header "x-raet-tenant-id: %tenantId%" ^
--header "Authorization: Bearer %token%" ^
-H "Accept: application/octet-stream" ^
--output %name2%
