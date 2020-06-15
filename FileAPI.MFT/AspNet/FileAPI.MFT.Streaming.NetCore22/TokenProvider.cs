using System.Threading.Tasks;

namespace FileAPI.MFT.Streaming.NetCore22
{
    public static class TokenProvider
    {
        public static async Task<string> GenerateAsync()
        {
            // Here comes the logic of retrieving the authorization token.
            // To get more information about how to retrieve it, please go to Ping documentation.
            // ToDo Add ping documentation.
            //return await Task.FromResult("MyToken");
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MjIyMDY5N30.JZ6AWx02ebEw9cuebehY4XSrnf3l1CS_pxCZvam8T3f5HmBBQhfIWR10N1SzX-gv7m7xHycscNi6yrFEEkPifL_15v2FLMJZaSPF4kTn5h9vjBip5Gs9t6of2DhZR-LTMyL8jVEoT7DihF_kP4vv5P-jl3--YGqL4TYL9QUoCJ-uygtjlwcd9eboUWxH9j37W7_LIebBsHGJW9aUk8VA85Og1loQetbLXhP_iq1hQPWquySUGDRbBvuKYIkZc3DW0N8TAGvleqfyJ5toU1RVu9lua0e9vfdMAtZltDyWyilSmoPTXAZNdh1AoGnzgFvkp-VZtV46anvpHHwJT54BRA");
        }
    }
}
