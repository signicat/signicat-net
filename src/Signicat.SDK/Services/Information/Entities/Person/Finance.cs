using System.Collections.Generic;

namespace Signicat.Information.Person
{
    public class Finance
    {
        public CreditScore CreditScore { get; set; }

        /// <summary>
        ///     Number of payment remarks registered on the individual
        /// </summary>
        public int? NumberOfPaymentRemarks { get; set; }

        /// <summary>
        ///     Financial information
        /// </summary>
        public IList<FinanceInfo> IncomeAndWealth { get; set; }

        public Metadata Metadata { get; set; }
    }

    /// <summary>
    ///     Credit score information
    /// </summary>
    public class CreditScore
    {
        /// <summary>
        ///     Credit score value
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        ///     Name of the scoring system used
        /// </summary>
        public string ScoringSystem { get; set; }

        /// <summary>
        ///     Link to the scoring used if available
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        ///     Year of the score
        /// </summary>
        public int? Year { get; set; }
    }

    public class FinanceInfo
    {
        /// <summary>
        ///     Year the info is from
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        ///     ISO 4217 currency code
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        ///     Income before deductions
        /// </summary>
        public long? GrossIncome { get; set; }

        /// <summary>
        ///     Income after deductions
        /// </summary>
        public long? NetIncome { get; set; }

        /// <summary>
        ///     Value of everything owned by the individual
        /// </summary>
        public long? Wealth { get; set; }
    }
}