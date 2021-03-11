# Changelog 
Date | Version Changes 
--- | --- 
2021-03-11| v1.1.0          Improve pipeline to publish changelog to the example repository  After a change in the pipeline, the SDK changelog was no longer publishing to the [example repository](https://github.com/transportersteam/FileAPI.Integration.Examples/blob/master/FileAPI.Sdk/docs/Changelog.md). The change was rolled back.
2021-03-04| v1.0.0          Package is now deployed to Nuget
2021-02-18| v0.24.0         Security changes related to Dependency Confusion Vulnerability are implemented
2020-11-16| v0.23.0         Added pipeline retention for releases  Retain pipeline data when release reach REL stage
2020-10-10| v0.22.0         Update SonarQube Service Connection
2020-09-17| v0.21.0         Fixed nuget packages publishing issues
2020-09-09| v0.20.0         QA improvements
2020-08-25| v0.19.0         Fixed incomplete upload of big files when the connection is too slow
2020-07-29| v0.18.0         Added underlying http requests retrying
2020-07-21| v0.17.0         Remove ClientBufferSize, support for files longer than 2Gb  Remove ClientBufferSize, support for files longer than 2Gb
2020-07-21| v0.16.0         Solved a bug where big files (8 MB) might be uploaded corrupted.
2020-07-15| v0.15.0         Added HttpClient buffer size configuration options
2020-07-10| v0.14.0         Compatibility with .Net 4.5. Fixed some bugs. Improved responses.
2020-07-09| v0.13.0         Added timeout to download big files
2020-07-07| v0.12.0         Updates for download files to multiple folders
2020-06-16| v0.11.0         Adapt SDK for.Net Framework
2020-06-15| v0.10.0         Create documentation and deliver examples of uploads and downloads of files using .Net SDK
2020-06-11| v0.9.0          Create examples in Powershell, of uploads and downloads of files using the SDK and exposed them in Github
2020-06-01| v0.8.0          SDK adapted to .Net Framework
