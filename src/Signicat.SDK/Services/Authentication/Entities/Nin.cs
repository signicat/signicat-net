namespace Signicat.Authentication
{
    public class Nin
    {
        /// <summary>
        /// The value of Nin.
        /// </summary>
        /// <example>10109001290</example>
        public string Value { get; set; }
            
        /// <summary>
        /// The issuing country of Nin.
        /// </summary>
        /// <example>NO</example>
        public string IssuingCountry	 { get; set; }
            
        /// <summary>
        /// The type of Nin.
        /// </summary>
        /// <example>BIRTH</example>
        public string @Type { get; set; }
    }
}