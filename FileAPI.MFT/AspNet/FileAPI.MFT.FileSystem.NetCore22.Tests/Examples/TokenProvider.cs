using System.Threading.Tasks;

namespace FileAPI.MFT.FileSystem.NetCore22.Examples
{
    public static class TokenProvider
    {
        public static async Task<string> GenerateAsync()
        {
            // Here comes the logic of retrieving the authorization token.
            // To get more information about how to retrieve it, please go to Ping documentation.
            // ToDo Add ping documentation.
            //return await Task.FromResult("MyToken");
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MTk0OTE2NH0.XRkBUVPQBu0hTk-O4mOcGNkkvoaNab64lbB7LKdcvPCNfDoQWc7pwzzb2JewB8ioEACVqsm3A1M5Bnbo1fvmtTsJ25-eskT180znc36QvzzkrgsImDDtjSQWcn0gY-6rtaaMKo7A9ZYobDLWzmWaSLjEQSz08SvsW2V1rmrebPdKKz22JK_AAeobNwWnIaubG0XAU-nc0GfGLw60D6A1-GgP1quMEflEKQ6C54srvw-iqslna8ARrBF8DbhniGm-ZGu3thpxkkK3W4k4h0ixEhKNZu2KkQofK_J65gyXahWTZy1RrnOm6EbyNe7K9CE25ybQd2CZUT9spZx7fUWeMg");
        }
    }
}
