using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Infrastructure;
using Signicat.Services.AccountManagement.Entities;

namespace Signicat.AccountManagement
{
    public class AccountManagement: SignicatBaseService, IAccountManagement
    {
        public async Task<IEnumerable<InvoiceListItem>> ListInvoicesAsync(DateTime? invoiceDateBefore, DateTime? invoiceDateAfter)
        {
            var response = await GetAsync<ListInvoiceResponse>(Urls.AccountManagementInvoices);
            return response?.Data ?? Array.Empty<InvoiceListItem>();
        }

        public IEnumerable<InvoiceListItem> ListInvoices(DateTime? invoiceDateBefore, DateTime? invoiceDateAfter)
        {
            var response = Get<ListInvoiceResponse>(Urls.AccountManagementInvoices);
            return response?.Data ?? Array.Empty<InvoiceListItem>();
        }

        public Task<Invoice> RetrieveInvoiceAsync(string invoiceNumber)
        {
            return GetAsync<Invoice>($"{Urls.AccountManagementInvoices}/{invoiceNumber}");
        }

        public Invoice RetrieveInvoice(string invoiceNumber)
        {
            return Get<Invoice>($"{Urls.AccountManagementInvoices}/{invoiceNumber}");
        }

        public Task<Stream> DownloadInvoiceAsync(string invoiceNumber)
        {
            return GetFileAsync($"{Urls.AccountManagementInvoices}/{invoiceNumber}/pdf");
        }

        public Stream DownloadInvoice(string invoiceNumber)
        {
            return GetFile($"{Urls.AccountManagementInvoices}/{invoiceNumber}/pdf");
        }
    }
}