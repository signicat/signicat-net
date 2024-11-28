using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.AccountManagement;
using Signicat.Services.AccountManagement.Entities;

namespace Signicat.SDK.Tests.Services;

public class AccountManagementServiceTest:BaseTest
{
    private IAccountManagementService _accountManagementService;
    private const string invoiceNumberToTestWith = "SSE-.INV00006";
    public AccountManagementServiceTest()
    {
        SignicatConfiguration.SetClientCredentials(Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_CLIENT_ID"),
            Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_CLIENT_SECRET"));
        
        SignicatConfiguration.SetClientCredentials("org-prod-drab-bucket-469","pVqNJwpPFpRa0uBOC81B4MlDqZcQltL4sdm6pgCcajyKpXY5");
        
        _accountManagementService = new AccountManagementService(Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_ORGANISATIONID"));
    }

    [Test]
    public async Task ListInvoiceAsyncShouldNotBeNullAndContainMoreThenOneItem()
    {
        Console.WriteLine(SignicatConfiguration.ClientId);
        var list = (await _accountManagementService.ListInvoicesAsync(new DateTime(2024, 12, 31),new DateTime(2024, 1, 1))).ToArray(); 
        Assert.That(list, Is.Not.Null);
        Assert.That(list.Count(), Is.GreaterThan(0));
        Assert.That(Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_ORGANISATIONID"), Is.EqualTo(list[0].OrganizationId));
    }
    
    [Test]
    public void ListInvoiceShouldNotBeNullAndContainMoreThenOneItem()
    {
        var list =  _accountManagementService.ListInvoices(new DateTime(2024, 12, 31),new DateTime(2024, 1, 1)).ToArray(); 
        Assert.That(list, Is.Not.Null);
        Assert.That(list.Count(), Is.GreaterThan(0));
        Assert.That(Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_ORGANISATIONID"), Is.EqualTo(list[0].OrganizationId));
    }

    [Test]
    public async Task GetInvoiceAsyncCheckThatItsCorrect()
    {
        var invoice = await _accountManagementService.RetrieveInvoiceAsync(invoiceNumberToTestWith);
        Assert.That(invoice, Is.Not.Null);
        ValidateInvoice(invoice);
    }

    [Test]
    public void GetInvoiceCheckThatItsCorrect()
    {
        var invoice =  _accountManagementService.RetrieveInvoice(invoiceNumberToTestWith);
        Assert.That(invoice, Is.Not.Null);
        ValidateInvoice(invoice);
    }
    
    private void ValidateInvoice(Invoice invoice)
    {
        Assert.That(invoice.InvoiceNumber, Is.EqualTo(invoiceNumberToTestWith));
        Assert.That(invoice.Lines.Count(), Is.GreaterThan(0));
        Assert.That(invoice.OrganizationId, Is.EqualTo(Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_ORGANISATIONID")));
        Assert.That(invoice.OrganizationName, Is.EqualTo("Signidog AS"));
        Assert.That(invoice.UsageOrganizationId, Is.EqualTo("o-p-yClhyK69i4rUaEwP9cw9"));
        Assert.That(invoice.UsageOrganizationName, Is.EqualTo("Signidog AS"));
        Assert.That(invoice.InvoiceNumber, Is.EqualTo("SSE-.INV00006"));
        Assert.That(invoice.InvoiceDate, Is.EqualTo( DateTime.Parse("2024-01-30T11:00:00Z",new DateTimeFormatInfo(),DateTimeStyles.AssumeUniversal))); // Consider parsing to DateTimeOffset for better comparison
        Assert.That(invoice.InvoiceAddressCountryRegionISOCode, Is.EqualTo("FI"));
        Assert.That(invoice.InvoiceAddressZipCode, Is.EqualTo("02600"));
        Assert.That(invoice.TotalTaxAmount, Is.EqualTo(0.0));
        Assert.That(invoice.InvoiceAddressStreetNumber, Is.EqualTo(""));
        Assert.That(invoice.InvoiceAddressStreet, Is.EqualTo("Linnoitustie 4B"));
        Assert.That(invoice.TotalChargeAmount, Is.EqualTo(0.0));
        Assert.That(invoice.TotalDiscountAmount, Is.EqualTo(0.0));
        Assert.That(invoice.CurrencyCode, Is.EqualTo("SEK"));
        Assert.That(invoice.SalesOrderNumber, Is.EqualTo("SSE-000072"));
        Assert.That(invoice.InvoiceAddressCity, Is.EqualTo("Espoo"));
        Assert.That(invoice.InvoiceHeaderTaxAmount, Is.EqualTo(0.0));
        Assert.That(invoice.InvoiceAddressState, Is.EqualTo(""));
        Assert.That(invoice.InvoiceAddressCountryRegionId, Is.EqualTo("FIN"));
        Assert.That(invoice.CustomersOrderReference, Is.EqualTo(""));
        Assert.That(invoice.TotalInvoiceAmount, Is.EqualTo(1.0));
        Assert.That(invoice.PaymentId, Is.EqualTo("0000000609"));
        Assert.That(invoice.InvoiceCustomerAccountNumber, Is.EqualTo("SSEC00169"));
        Assert.That(invoice.SigContractRef, Is.EqualTo(""));
        Assert.That(invoice.SigDocumentRef, Is.EqualTo(""));
        Assert.That(invoice.Settled, Is.True);
    }
}