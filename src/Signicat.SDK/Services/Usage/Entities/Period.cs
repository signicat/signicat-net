#nullable enable
namespace Signicat.Services.Usage.Entities
{
    public record Period
    {
        /// <summary>
        /// First date
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Last date
        /// </summary>
        public string End { get; set; }
    }
}