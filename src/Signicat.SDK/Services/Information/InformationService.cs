using System.Collections.Generic;
using System.Threading.Tasks;
using Signicat.Information.BusinessRegistry;
using Signicat.Information.Geodata;
using Signicat.Information.Organization;
using Signicat.Information.Person;
using Signicat.Infrastructure;
using BasicInfo = Signicat.Information.Organization.BasicInfo;
using Finance = Signicat.Information.Organization.Finance;
using SearchResult = Signicat.Information.Organization.SearchResult;

namespace Signicat.Information
{
    public class InformationService : SignicatBaseService, IInformationService
    {
        public InformationService()
        {
        }

        public InformationService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
        }

        /// <inheritdoc />
        public BasicInfo GetBasicOrganizationInfo(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<BasicInfo>(url);
        }

        /// <inheritdoc />
        public Task<BasicInfo> GetBasicOrganizationInfoAsync(string country, string id,
            string idType = null, string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<BasicInfo>(url);
        }

        /// <inheritdoc />
        public Authorization GetOrganizationAuthorization(
            string country,
            string id, string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/authorization",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<Authorization>(url);
        }

        /// <inheritdoc />
        public Task<Authorization> GetOrganizationAuthorizationAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/authorization",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<Authorization>(url);
        }

        /// <inheritdoc />
        public Ownership GetOrganizationOwnership(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ownership",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<Ownership>(url);
        }

        /// <inheritdoc />
        public Task<Ownership> GetOrganizationOwnershipAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ownership",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<Ownership>(url);
        }

        /// <inheritdoc />
        public Roles GetOrganizationRoles(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/roles",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<Roles>(url);
        }

        /// <inheritdoc />
        public Task<Roles> GetOrganizationRolesAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/roles",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<Roles>(url);
        }

        /// <inheritdoc />
        public Ubo GetOrganizationUltimateBeneficialOwners(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ultimate-beneficial-owners",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<Ubo>(url);
        }

        /// <inheritdoc />
        public Task<Ubo> GetOrganizationUltimateBeneficialOwnersAsync(string country, string id,
            string idType = null, string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ultimate-beneficial-owners",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<Ubo>(url);
        }

        /// <inheritdoc />
        public Finance GetOrganizationFinance(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/finance",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<Finance>(url);
        }

        /// <inheritdoc />
        public Task<Finance> GetOrganizationFinanceAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/finance",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<Finance>(url);
        }

        /// <inheritdoc />
        public ScreeningResult OrganizationScreening(
            string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/organizations/screening",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"listType", listType},
                    {"offset", offset},
                    {"limit", limit}
                });

            return Get<ScreeningResult>(url);
        }

        /// <inheritdoc />
        public Task<ScreeningResult> OrganizationScreeningAsync(
            string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/organizations/screening",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"listType", listType},
                    {"offset", offset},
                    {"limit", limit}
                });

            return GetAsync<ScreeningResult>(url);
        }

        /// <inheritdoc />
        public SearchResult OrganizationSearch(
            string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string cursor = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/organizations/search",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"cursor", cursor},
                    {"offset", offset},
                    {"limit", limit}
                });

            return Get<SearchResult>(url);
        }

        /// <inheritdoc />
        public Task<SearchResult> OrganizationSearchAsync(string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string cursor = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/organizations/search",
                new Dictionary<string, object>
                {
                    {"idType", idType},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"cursor", cursor},
                    {"offset", offset},
                    {"limit", limit}
                });

            return GetAsync<SearchResult>(url);
        }

        /// <inheritdoc />
        public Person.BasicInfo GetBasicPersonInfo(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<Person.BasicInfo>(url);
        }

        /// <inheritdoc />
        public Task<Person.BasicInfo> GetBasicPersonInfoAsync(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<Person.BasicInfo>(url);
        }

        /// <inheritdoc />
        public AddressInfo GetPersonAddress(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<AddressInfo>(url);
        }

        /// <inheritdoc />
        public Task<AddressInfo> GetPersonAddressAsync(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<AddressInfo>(url);
        }

        /// <inheritdoc />
        public Person.Finance GetPersonFinance(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/finance",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<Person.Finance>(url);
        }

        /// <inheritdoc />
        public Task<Person.Finance> GetPersonFinanceAsync(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/finance",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<Person.Finance>(url);
        }

        /// <inheritdoc />
        public AddressVerification PersonVerifyAddress(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address/verify",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return Get<AddressVerification>(url);
        }

        /// <inheritdoc />
        public Task<AddressVerification> PersonVerifyAddressAsync(
            string country,
            string identityNumber = null,
            string givenName = null,
            string surname = null,
            string dateOfBirth = null,
            string caseRef = null,
            string street = null,
            string streetNumber = null,
            string postalCode = null,
            string city = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address/verify",
                new Dictionary<string, object>
                {
                    {"identityNumber", identityNumber},
                    {"givenName", givenName},
                    {"surname", surname},
                    {"dateOfBirth", dateOfBirth},
                    {"caseRef", caseRef},
                    {"street", street},
                    {"streetNumber", streetNumber},
                    {"postalCode", postalCode},
                    {"city", city},
                    {"source", source},
                    {"rawJson", rawJson}
                });

            return GetAsync<AddressVerification>(url);
        }

        /// <inheritdoc />
        public ScreeningResult PersonScreening(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/persons/screening",
                new Dictionary<string, object>
                {
                    {"dateOfBirth", dateOfBirth},
                    {"postalCode", postalCode},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"listType", listType},
                    {"offset", offset},
                    {"limit", limit}
                });

            return Get<ScreeningResult>(url);
        }

        /// <inheritdoc />
        public Task<ScreeningResult> PersonScreeningAsync(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/persons/screening",
                new Dictionary<string, object>
                {
                    {"dateOfBirth", dateOfBirth},
                    {"postalCode", postalCode},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"listType", listType},
                    {"offset", offset},
                    {"limit", limit}
                });

            return GetAsync<ScreeningResult>(url);
        }

        /// <inheritdoc />
        public Person.SearchResult PersonSearch(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/persons/search",
                new Dictionary<string, object>
                {
                    {"dateOfBirth", dateOfBirth},
                    {"postalCode", postalCode},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"offset", offset},
                    {"limit", limit}
                });

            return Get<Person.SearchResult>(url);
        }

        /// <inheritdoc />
        public Task<Person.SearchResult> PersonSearchAsync(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            int? offset = null,
            int? limit = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/persons/search",
                new Dictionary<string, object>
                {
                    {"dateOfBirth", dateOfBirth},
                    {"postalCode", postalCode},
                    {"countries", countries},
                    {"id", id},
                    {"name", name},
                    {"source", source},
                    {"rawJson", rawJson},
                    {"offset", offset},
                    {"limit", limit}
                });

            return GetAsync<Person.SearchResult>(url);
        }

        /// <inheritdoc />
        public IEnumerable<RegistrationAuthorityItem> ListRegistrationAuthorities()
        {
            return Get<IEnumerable<RegistrationAuthorityItem>>($"{Urls.Information}/businessregistry");
        }

        /// <inheritdoc />
        public Task<IEnumerable<RegistrationAuthorityItem>> ListRegistrationAuthoritiesAsync()
        {
            return GetAsync<IEnumerable<RegistrationAuthorityItem>>(
                $"{Urls.Information}/businessregistry");
        }

        /// <inheritdoc />
        public RegistrationAuthority GetRegistrationAuthority(string authorityCode)
        {
            return Get<RegistrationAuthority>($"{Urls.Information}/businessregistry/{authorityCode}");
        }

        /// <inheritdoc />
        public Task<RegistrationAuthority> GetRegistrationAuthorityAsync(string authorityCode)
        {
            return GetAsync<RegistrationAuthority>(
                $"{Urls.Information}/businessregistry/{authorityCode}");
        }

        /// <inheritdoc />
        public IEnumerable<CountryListItem> ListCountries(string lang = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/geodata/countries",
                new Dictionary<string, object>
                {
                    {"lang", lang}
                });

            return Get<IEnumerable<CountryListItem>>(url);
        }

        /// <inheritdoc />
        public Task<IEnumerable<CountryListItem>> ListCountriesAsync(string lang = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/geodata/countries",
                new Dictionary<string, object>
                {
                    {"lang", lang}
                });

            return GetAsync<IEnumerable<CountryListItem>>(url);
        }

        /// <inheritdoc />
        public CountryInfo GetCountryInfo(string countryCode, string lang = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}",
                new Dictionary<string, object>
                {
                    {"lang", lang}
                });

            return Get<CountryInfo>(url);
        }

        /// <inheritdoc />
        public Task<CountryInfo> GetCountryInfoAsync(string countryCode, string lang = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}",
                new Dictionary<string, object>
                {
                    {"lang", lang}
                });

            return GetAsync<CountryInfo>(url);
        }

        /// <inheritdoc />
        public IEnumerable<DivisionListItem> ListCountrySubdivisions(string countryCode, string lang = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}/subdivisions",
                new Dictionary<string, object>
                {
                    {"lang", lang}
                });

            return Get<IEnumerable<DivisionListItem>>(url);
        }

        /// <inheritdoc />
        public Task<IEnumerable<DivisionListItem>> ListCountrySubdivisionsAsync(string countryCode,
            string lang = null)
        {
            var url = ApiHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}/subdivisions",
                new Dictionary<string, object>
                {
                    {"lang", lang}
                });

            return GetAsync<IEnumerable<DivisionListItem>>(url);
        }
    }
}