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
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MjIxODU0N30.HXL9BwG1kO7V-KopVz7GWxmWFyiC7sMZMm_ma19ZuRfk91DyU1N_UqxTJ2LMPXQaP1V1CU9T-koUbUVA_lAEugF4u7N4C20c5px_CBDaljCd3QwxcoD3C5O_-Yp9q1gztEtAXYVboFoRMKXhKaMuO9wVSPvL5Qji-9bi5Ze3LF3uu6wwzd-gs8aZq4BNelDOj-E3j0jD-rxjp-8Mf6f7RrB9Ej3qfrGWhL1txjkljD7vlBjl5kL044hoNq6-jqdETfpQuo19uQX-loBUiRqOOOh0mgt_kkF7d_DO2mzMeyzFkfgTh829gBQ_AdriO0dQpPO27_ywAyLFHzPZLNgfdQ");
        }
    }
}
