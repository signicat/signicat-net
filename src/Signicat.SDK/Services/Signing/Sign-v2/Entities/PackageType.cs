using System.Text.Json.Serialization;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    public enum PackageType
    {
        [JsonStringEnumMemberName("PADES_CONTAINER")]
        PADES_CONTAINER
    }
}