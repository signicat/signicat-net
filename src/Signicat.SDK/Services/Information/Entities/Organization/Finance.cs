using System.Collections.Generic;

namespace Signicat.Information.Organization
{
    public class Finance
    {
        public CreditRatingDto CreditRating { get; set; }
        
        /// <summary>
        /// Number of payment remarks registered on the organization
        /// </summary>
        public int? NumberOfPaymentRemarks { get; set; }
        
        /// <summary>
        /// Account figures
        /// </summary>
        public IList<ProfitAndLoss> ProfitAndLoss { get; set; }
        
        /// <summary>
        /// Key figures
        /// </summary>
        public IList<KeyFigures> KeyFigures { get; set; }
        
        public Metadata Metadata { get; set; }
    }
    
    /// <summary>
    /// Credit score information
    /// </summary>
    public class CreditRatingDto {
        
        /// <summary>
        /// Credit rating score
        /// </summary>
        public string Score { get; set; }
        
        /// <summary>
        /// Name of the rating system used
        /// </summary>
        public string RatingSystem { get; set; }
        
        /// <summary>
        /// A description of the code
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Link to the rating used if available
        /// </summary>
        public string Link { get; set; }
        
        /// <summary>
        /// Year of the score
        /// </summary>
        public int? Year { get; set; }
    }

    public class ProfitAndLoss : FiscalYear
    {
        /// <summary>
        /// Gross revenue
        /// </summary>
        public long? Turnover { get; set; }
        
        /// <summary>
        /// Revenue after deducting the cost of goods
        /// </summary>
        public long? GrossProfit  { get; set; }

        /// <summary>
        /// Revenue after deducting operating, interest, and tax expenses
        /// </summary>
        public long? NetProfit { get; set; }
        
        /// <summary>
        /// Revenue after deducting tax expenses
        /// </summary>
        public long? NetProfitAfterTax  { get; set; }
    }

    public class KeyFigures : FiscalYear
    {
        /// <summary>
        /// Value of the organization
        /// </summary>
        public long? NetWorth { get; set; }
    }

    public class FiscalYear
    {
        /// <summary>
        /// Fiscal year
        /// </summary>
        public int? Year { get; set; }
        
        /// <summary>
        /// ISO 4217 currency code
        /// </summary>
        public string Currency { get; set; }
    }
}