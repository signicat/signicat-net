namespace Signicat.Services.Signing.Express.Entities
{
    public class AppSignatureMethod
    {
        public SignatureMethod? Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
    }
}