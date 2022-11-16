namespace Signicat.Information
{
    /// <summary>
    /// Birth information
    /// </summary>
    public class Birth
    {
        /// <summary>
        /// Month of birth
        /// </summary>
        public string MonthOfBirth { get; set; }
        
        /// <summary>
        /// Year of birth
        /// </summary>
        public string YearOfBirth { get; set; }
        
        /// <summary>
        /// Date of birth
        /// </summary>
        public string DateOfBirth { get; set; }
        
        public Iso3166 Country { get; set; }
    }

    public class ApproximateBirth : Birth
    {
        public bool IsApproximate { get; set; }
    }
}