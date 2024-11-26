using System.Collections.Generic;

namespace Signicat.Services.AccountManagement.Entities
{
    internal record ListInvoiceResponse
    {
        public IEnumerable<InvoiceListItem> Data { get; set; }
    }
    
    
}