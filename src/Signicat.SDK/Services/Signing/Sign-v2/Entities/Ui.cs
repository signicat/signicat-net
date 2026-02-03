namespace Signicat.Services.Signing.Sign_v2.Entities
{
    public class Ui
    {
        /// <summary>
        /// Specifies the language to be used in the signing UI. Defaults to "en"
        ///   <see cref="Constants.Languages" />
        /// <example>"da" "de" "en" "fi" "nb" "nn" "sv"</example>
        /// </summary>
        public string Language { get; set; }
    }
}