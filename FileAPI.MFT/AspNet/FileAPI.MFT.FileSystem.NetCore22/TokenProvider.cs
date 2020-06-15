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
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MjIwOTIzNn0.B2XDXN-1n4APQKUq39oXLA16Qd2Y1X3_QrdF4430B8xXkJhrENk2r7PPVuj7_5EBylK1TdopUD0A2xfF-5dEf0IwvJ11uI9IkD5dFJ2Xvusw-0Wt3uvUgnxIdWYmDl46E_ki8eBsLuZzJYhv3AG_-h3vIcZweps1G0nD-wsfJek_PLG-_yD52JbmFlym0P1zH-2MgipGBFSSzB9j2Hu2uFXSVOua8PEWMBMRDQjScmN4RcZK-D75LdgMACwh5OUSLatc2SVH24gxJ7IOBvKK32fhBQ1ZyhRly3r6wI0fYc8CmD8g2UUHAX7chf_2wjTknXSZxHDXZ4utDrH5EmbtdQ");
        }
    }
}
