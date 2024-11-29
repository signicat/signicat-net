using System;
using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum ExtraInfoSignerType
    {
        [EnumMember(Value = "personLookup")]
        PersonLookup = 10,
    }
}