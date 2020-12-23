namespace RealPage.Properties.Services.WebApi.Helpers
{
    public class AppSettings
    {
        public string OriginRealPage { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string MinutesToExpire { get; set; }
    }
}
