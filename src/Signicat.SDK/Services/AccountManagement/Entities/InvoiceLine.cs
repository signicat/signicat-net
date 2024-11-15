using System;

namespace Signicat.Services.AccountManagement.Entities
{
    public record InvoiceLine
    {
        /// <summary>
        /// The total discount amount for the line.
        /// </summary>
        public decimal LineTotalDiscountAmount { get; set; }

        /// <summary>
        /// The total tax amount for the line.
        /// </summary>
        public decimal LineTotalTaxAmount { get; set; }

        /// <summary>
        /// The currency code for the line.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The sales price.
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// The sales unit symbol.
        /// </summary>
        public string SalesUnitSymbol { get; set; }

        /// <summary>
        /// The total charge amount for the line.
        /// </summary>
        public decimal LineTotalChargeAmount { get; set; }

        /// <summary>
        /// The invoiced quantity.
        /// </summary>
        public decimal InvoicedQuantity { get; set; }

        /// <summary>
        /// The line amount.
        /// </summary>
        public decimal LineAmount { get; set; }

        /// <summary>
        /// The product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The revenue recognition contract start date.
        /// </summary>
        public DateTime RevRecContractStartDate { get; set; }

        /// <summary>
        /// The revenue recognition contract end date.
        /// </summary>
        public DateTime RevRecContractEndDate { get; set; }

        /// <summary>
        /// The Signicat contract start date.
        /// </summary>
        public DateTime SigContractStart { get; set; }

        /// <summary>
        /// The Signicat contract end date.
        /// </summary>
        public DateTime SigContractEnd { get; set; }

        /// <summary>
        /// The item number.
        /// </summary>
        public string ItemNumber { get; set; }
    }
}