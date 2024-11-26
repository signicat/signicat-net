using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Services.AccountManagement.Entities;

namespace Signicat.AccountManagement
{
    public interface IAccountManagement
    {
        /// <summary>
        /// List invoices
        /// </summary>
        /// <param name="invoiceDateBefore"></param>
        /// <param name="invoiceDateAfter"></param>
        /// <returns></returns>
        Task<IEnumerable<InvoiceListItem>> ListInvoicesAsync(DateTime? invoiceDateBefore, DateTime? invoiceDateAfter);
        
        /// <summary>
        /// List invoices
        /// </summary>
        /// <param name="invoiceDateBefore"></param>
        /// <param name="invoiceDateAfter"></param>
        /// <returns></returns>
        IEnumerable<InvoiceListItem> ListInvoices(DateTime? invoiceDateBefore, DateTime? invoiceDateAfter);

        /// <summary>
        /// Retrieve single invoice with details and lines
        /// </summary>
        /// <param name="invoiceNumber">The invoice number</param>
        /// <returns></returns>
        Task<Invoice> RetrieveInvoiceAsync(string invoiceNumber);
        
        /// <summary>
        /// Retrieve single invoice with details and lines
        /// </summary>
        /// <param name="invoiceNumber">The invoice number</param>
        /// <returns></returns>
        Invoice RetrieveInvoice(string invoiceNumber);

        /// <summary>
        /// Downloads the invoice PDF file
        /// </summary>
        /// <param name="invoiceNumber">The invoice number</param>
        /// <returns>Byte array containing the invoice PDF</returns>
        Task<Stream> DownloadInvoiceAsync(string invoiceNumber);
        
        
        /// <summary>
        /// Downloads the invoice PDF file
        /// </summary>
        /// <param name="invoiceNumber">The invoice number</param>
        /// <returns>Byte array containing the invoice PDF</returns>
        Stream DownloadInvoice(string invoiceNumber);
    }
}