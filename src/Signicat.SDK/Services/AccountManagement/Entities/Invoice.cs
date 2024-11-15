using System;
using System.Collections.Generic;


namespace Signicat.Services.AccountManagement.Entities
{
    public record Invoice
    {
        /// <summary>
        /// The ID of the organization.
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// The name of the organization.
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// The ID of the usage organization.
        /// </summary>
        public string UsageOrganizationId { get; set; }

        /// <summary>
        /// The name of the usage organization.
        /// </summary>
        public string UsageOrganizationName { get; set; }

        /// <summary>
        /// The invoice number.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// The invoice date.
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// The ISO code of the country/region for the invoice address.
        /// </summary>
        public string InvoiceAddressCountryRegionISOCode { get; set; }

        /// <summary>
        /// The zip code of the invoice address.
        /// </summary>
        public string InvoiceAddressZipCode { get; set; }

        /// <summary>
        /// The total tax amount.
        /// </summary>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// The street number of the invoice address.
        /// </summary>
        public string InvoiceAddressStreetNumber { get; set; }

        /// <summary>
        /// The street of the invoice address.
        /// </summary>
        public string InvoiceAddressStreet { get; set; }

        /// <summary>
        /// The total charge amount.
        /// </summary>
        public decimal TotalChargeAmount { get; set; }

        /// <summary>
        /// The total discount amount.
        /// </summary>
        public decimal TotalDiscountAmount { get; set; }

        /// <summary>
        /// The currency code.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The sales order number.
        /// </summary>
        public string SalesOrderNumber { get; set; }

        /// <summary>
        /// The city of the invoice address.
        /// </summary>
        public string InvoiceAddressCity { get; set; }

        /// <summary>
        /// The tax amount in the invoice header.
        /// </summary>
        public decimal InvoiceHeaderTaxAmount { get; set; }

        /// <summary>
        /// The state of the invoice address.
        /// </summary>
        public string InvoiceAddressState { get; set; }

        /// <summary>
        /// The ID of the country/region for the invoice address.
        /// </summary>
        public string InvoiceAddressCountryRegionId { get; set; }

        /// <summary>
        /// The customer's order reference.
        /// </summary>
        public string CustomersOrderReference { get; set; }

        /// <summary>
        /// The total invoice amount.
        /// </summary>
        public decimal TotalInvoiceAmount { get; set; }

        /// <summary>
        /// The payment ID.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// The customer account number on the invoice.
        /// </summary>
        public string InvoiceCustomerAccountNumber { get; set; }

        /// <summary>
        /// The Signicat contract reference.
        /// </summary>
        public string SigContractRef { get; set; }

        /// <summary>
        /// The Signicat document reference.
        /// </summary>
        public string SigDocumentRef { get; set; }

        /// <summary>
        /// Indicates whether the invoice is settled.
        /// </summary>
        public bool Settled { get; set; }

        /// <summary>
        /// Invoice lines.
        /// </summary>
        public List<InvoiceLine> Lines { get; set; }

       
    }
}