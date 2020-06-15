# File API Powershell Examples

**AspNet** folder includes a collection of examples that show how to integrate the **File API SDKs** with **.Net Core**.

## Getting Started 

Download **AspNet** folder.

Inside the folder there is a solution called **FileAPI.MFT**. This solution contains two projects:
  - **FileAPI.MFT.FileSystem.NetCore22**. This project provides examples of how to integrate **FileSystem SDK** using **.Net Core 2.2**.
  - **FileAPI.MFT.Streaming.NetCore22**. This projects provides examples of how to integrate **Streaming SDK** using **.Net Core 2.2**.

The examples are in the **Examples** folder and they are created as tests methods. So for trying them you have to run them.

Most of the examples require custom information (like the tenant ID you want to use, the business type you want to upload the files to...). This required data is commented in the examples with a **"FILL ME"**. Fill the required data before running the examples.

**NOTE: If you are having errors when excuting the examples. Most likely will be caused because the custom information is not correctly provided.**

## Projects structure

Both projects has the same structure:
  - **Example** folder contains all the examples as test methods.
  - **Files** folder works as an internal file system. It also provides some sample files.
  - **config.json** contains some information that is going to be repeated through the examples.
  - **Startup.cs** initialize the examples and injects the SDK.

## Running Examples

Please, refer the to [Microsoft documentation](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019).

The examples are populated with some logs. They are stored internally and shown after an example is executed. To see these logs go the **Test Explorer**, choose the executed test and press **Open additional output for this result**. You can get more information [here](https://xunit.net/docs/capturing-output).

## Authors

**Visma - Transporters Team**

