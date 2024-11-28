using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Infrastructure;
using Signicat.Services.AccountManagement.Entities;

namespace Signicat.AccountManagement
{
    public class AccountManagementService : SignicatBaseService, IAccountManagementService
    {
        public AccountManagementService(string clientId, string clientSecret, string organisationId):base(clientId,clientSecret,organisationId)
        {
        }
        
        public AccountManagementService(string organisationId) : base(organisationId)
        {
        }
        
        public async Task<IEnumerable<InvoiceListItem>> ListInvoicesAsync(DateTime? invoiceDateBefore, DateTime? invoiceDateAfter = null)
        {
            var url = CreateListInvoiceUrl(invoiceDateBefore, invoiceDateAfter);
            
            var response = await GetAsync<IEnumerable<InvoiceListItem>>(url);
            return response ?? Array.Empty<InvoiceListItem>();
        }

        public IEnumerable<InvoiceListItem> ListInvoices(DateTime? invoiceDateBefore, DateTime? invoiceDateAfter = null)
        {
            var url = CreateListInvoiceUrl(invoiceDateBefore, invoiceDateAfter);

            var response = Get<IEnumerable<InvoiceListItem>>(url);
            return response ?? Array.Empty<InvoiceListItem>();
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
        
        private static string CreateListInvoiceUrl(DateTime? invoiceDateBefore, DateTime? invoiceDateAfter)
        {
            string url = Urls.AccountManagementInvoices.
                AppendQueryParam("invoiceDateBefore",invoiceDateBefore ?? DateTime.Now, "yyyy-MM-dd")
                .AppendQueryParam(invoiceDateAfter is not null,  "invoiceDateAfter",invoiceDateAfter ?? DateTime.Now, "yyyy-MM-dd");
            return url;
        }
    }
}