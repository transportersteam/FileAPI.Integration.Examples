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
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IlJ1ZTBUZlhsU2lYRzZieXE0MHcwQ2RSN0FkM2VYNzVJIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcImU5ZTNlMmE0LTUzMzMtNDY5YS1iMDEzLTA4OWNlNTUxY2M1NVwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU1wifSIsImF1dGh6Ijoie1wicGVybWlzc2lvbnNcIjp7XCJhbGxcIjpmYWxzZSxcInZhbHVlc1wiOltcIkZ0YWFzLk1hbmFnZUZpbGVzXCJdfSxcInRlbmFudHNcIjp7XCJhbGxcIjp0cnVlLFwidmFsdWVzXCI6W119fSIsImp3dHR5cGUiOiJzeXN0ZW0iLCJleHAiOjE1OTE5NTA2MzV9.iINREOo_JR2SEBlyiytmK2Jg6IwIdppltZY4023ER51-faiuPDhyEkx10i5iYNoBgTsF5NIuQbHL_08atIWyrrR3Eu7zVhi6JUVCo1chAp1YR9l5tNz3KiCTEAC5XR8LqKM6QT5FTjbotI34UTZDTiEjboavZ8Cq50qd0rtK_5DrP4gJx-pNSo-AErs1TGJD1AcdIIHZaGHyl2CZCZn7ehzvf2STMSXtt8MjRhhL6p91tImIxSY1L967Lh_LBSrUqA6HR2RKCNncV7X5vmu3Rv5XIqzxEWkaTRGqz1VN7Y0Ax17kw7PFdd2MoRjJsJ6ELIQJ1_z1mx0f2DlfhvIsSQ");
        }
    }
}
