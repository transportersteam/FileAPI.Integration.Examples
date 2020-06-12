using System.Threading.Tasks;

namespace FileAPI.MFT.FileSystem.NetCore22
{
    public static class TokenProvider
    {
        public static async Task<string> GenerateAsync()
        {
            // Here comes the logic of retrieving the authorization token.
            // To get more information about how to retrieve it, please go to Ping documentation.
            // ToDo Add ping documentation.
            //return await Task.FromResult("MyToken");
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MTk2MjAyN30.byxe-mOlkMCHdT0FUCM8M8J-gNCG3-H0zl3e4lt0V8dq_h7Bw70njBTm71jBxhapkGy-dAO5EU__eqiLKSARHXjUfZvjFZrZ2LTi-4_TPB-tEfv587E6WCZCZTCp3yaoQak1FafVppGDdYmrjAUWN4-O1TAWfxXtiJYKN2rAOWbEb0o_kJgi1vcVvTvV6cLLaRT8S92sC5P2tco9xmag9C3EemVTY1QnN20hHaj63RKEOWcM_B6hcH_ul1uD_ydpnweUeugS8pXbLtHHfoTARmrMqGiYafZn3a0-lzkhnlWEGRoBT6etL5V-iaPxQ0Qr1JCp_lOUtj2kjYCoVkZeJg");
        }
    }
}
