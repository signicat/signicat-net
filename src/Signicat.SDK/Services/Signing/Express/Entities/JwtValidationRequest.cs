namespace Signicat.Services.Signing.Express.Entities
{
    public class JwtValidationRequest
    {
        /// <summary>
        /// The JWT to validate.
        /// </summary>
        public string Jwt { get; set; }
    }
}