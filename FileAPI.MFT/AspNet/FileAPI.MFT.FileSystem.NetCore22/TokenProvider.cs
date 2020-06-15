using System.Threading.Tasks;

namespace FileAPI.MFT.FileSystem.NetCore22
{
    public static class TokenProvider
    {
        public static async Task<string> GetAuthenticationTokenAsync()
        {
            // Here comes the logic of retrieving the authorization token.
            // For instance, you could use something similar to what is implemented in RetrieveTokenExamples.cs.
            //return await Task.FromResult("MyToken");
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MjIzMjY3Nn0.PBXTrHZEehGTnA4dtREyfsMJxKobl_v4xV0ej3fXbKrnHRsHyfMMGAFnpP7Mbg5cjp2Pi6S9aszOLhKTFU47e22XQdsHiuG4iWuKIMToLce1IBhfdnxD9XWD70kwUGTMSWU1gHqdyStpRB5c5P47XH55HqL0JQ4JuI3GuWuV1t1jin0zFw3NgDqiey0I-utXcQMnZ2m0Yx_lnAtnpUCOoV59alOQzdoygGUgG-J4cMChHuKrIE6oPm5DEHH7CgZfsSQql-d3iBWMPQzccAf4xyj4L9NzGmBTmYJdXnsBYSz-BumBN0hag17UDFeVdtyOn6Jsx4frEFI8EtaLMq6o2g");
        }
    }
}
