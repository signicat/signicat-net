using System.Collections.Generic;
using System.Threading.Tasks;
using Signicat.Infrastructure;

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
        public Organization.BasicInfo GetBasicOrganizationInfo(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Organization.BasicInfo>(url);
        }

        /// <inheritdoc />
        public Task<Organization.BasicInfo> GetBasicOrganizationInfoAsync(string country, string id,
            string idType = null, string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Organization.BasicInfo>(url);
        }

        /// <inheritdoc />
        public Organization.Authorization GetOrganizationAuthorization(
            string country,
            string id, string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/authorization",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Organization.Authorization>(url);
        }

        /// <inheritdoc />
        public Task<Organization.Authorization> GetOrganizationAuthorizationAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/authorization",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Organization.Authorization>(url);
        }

        /// <inheritdoc />
        public Organization.Ownership GetOrganizationOwnership(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ownership",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Organization.Ownership>(url);
        }

        /// <inheritdoc />
        public Task<Organization.Ownership> GetOrganizationOwnershipAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ownership",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Organization.Ownership>(url);
        }

        /// <inheritdoc />
        public Organization.Roles GetOrganizationRoles(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/roles",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Organization.Roles>(url);
        }

        /// <inheritdoc />
        public Task<Organization.Roles> GetOrganizationRolesAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/roles",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Organization.Roles>(url);
        }

        /// <inheritdoc />
        public Organization.Ubo GetOrganizationUltimateBeneficialOwners(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ultimate-beneficial-owners",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Organization.Ubo>(url);
        }

        /// <inheritdoc />
        public Task<Organization.Ubo> GetOrganizationUltimateBeneficialOwnersAsync(string country, string id,
            string idType = null, string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams(
                $"{Urls.Information}/countries/{country}/organizations/{id}/ultimate-beneficial-owners",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Organization.Ubo>(url);
        }

        /// <inheritdoc />
        public Organization.Finance GetOrganizationFinance(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/finance",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Organization.Finance>(url);
        }

        /// <inheritdoc />
        public Task<Organization.Finance> GetOrganizationFinanceAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/organizations/{id}/finance",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Organization.Finance>(url);
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/organizations/screening",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "listType", listType },
                    { "offset", offset },
                    { "limit", limit }
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/organizations/screening",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "listType", listType },
                    { "offset", offset },
                    { "limit", limit }
                });

            return GetAsync<ScreeningResult>(url);
        }

        /// <inheritdoc />
        public Organization.SearchResult OrganizationSearch(
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/organizations/search",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "cursor", cursor },
                    { "offset", offset },
                    { "limit", limit }
                });

            return Get<Organization.SearchResult>(url);
        }

        /// <inheritdoc />
        public Task<Organization.SearchResult> OrganizationSearchAsync(string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string cursor = null,
            int? offset = null,
            int? limit = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/organizations/search",
                new Dictionary<string, object>()
                {
                    { "idType", idType },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "cursor", cursor },
                    { "offset", offset },
                    { "limit", limit }
                });

            return GetAsync<Organization.SearchResult>(url);
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Person.BasicInfo>(url);
        }

        /// <inheritdoc />
        public Person.AddressInfo GetPersonAddress(
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Person.AddressInfo>(url);
        }

        /// <inheritdoc />
        public Task<Person.AddressInfo> GetPersonAddressAsync(
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Person.AddressInfo>(url);
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/finance",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/finance",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Person.Finance>(url);
        }

        /// <inheritdoc />
        public Person.AddressVerification PersonVerifyAddress(
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address/verify",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return Get<Person.AddressVerification>(url);
        }

        /// <inheritdoc />
        public Task<Person.AddressVerification> PersonVerifyAddressAsync(
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/countries/{country}/persons/address/verify",
                new Dictionary<string, object>()
                {
                    { "identityNumber", identityNumber },
                    { "givenName", givenName },
                    { "surname", surname },
                    { "dateOfBirth", dateOfBirth },
                    { "caseRef", caseRef },
                    { "street", street },
                    { "streetNumber", streetNumber },
                    { "postalCode", postalCode },
                    { "city", city },
                    { "source", source },
                    { "rawJson", rawJson }
                });

            return GetAsync<Person.AddressVerification>(url);
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/persons/screening",
                new Dictionary<string, object>()
                {
                    { "dateOfBirth", dateOfBirth },
                    { "postalCode", postalCode },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "listType", listType },
                    { "offset", offset },
                    { "limit", limit }
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/persons/screening",
                new Dictionary<string, object>()
                {
                    { "dateOfBirth", dateOfBirth },
                    { "postalCode", postalCode },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "listType", listType },
                    { "offset", offset },
                    { "limit", limit }
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/persons/search",
                new Dictionary<string, object>()
                {
                    { "dateOfBirth", dateOfBirth },
                    { "postalCode", postalCode },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "offset", offset },
                    { "limit", limit }
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
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/persons/search",
                new Dictionary<string, object>()
                {
                    { "dateOfBirth", dateOfBirth },
                    { "postalCode", postalCode },
                    { "countries", countries },
                    { "id", id },
                    { "name", name },
                    { "source", source },
                    { "rawJson", rawJson },
                    { "offset", offset },
                    { "limit", limit }
                });

            return GetAsync<Person.SearchResult>(url);
        }

        /// <inheritdoc />
        public IEnumerable<BusinessRegistry.RegistrationAuthorityItem> ListRegistrationAuthorities()
        {
            return Get<IEnumerable<BusinessRegistry.RegistrationAuthorityItem>>($"{Urls.Information}/businessregistry");
        }

        /// <inheritdoc />
        public Task<IEnumerable<BusinessRegistry.RegistrationAuthorityItem>> ListRegistrationAuthoritiesAsync()
        {
            return GetAsync<IEnumerable<BusinessRegistry.RegistrationAuthorityItem>>(
                $"{Urls.Information}/businessregistry");
        }

        /// <inheritdoc />
        public BusinessRegistry.RegistrationAuthority GetRegistrationAuthority(string authorityCode)
        {
            return Get<BusinessRegistry.RegistrationAuthority>($"{Urls.Information}/businessregistry/{authorityCode}");
        }

        /// <inheritdoc />
        public Task<BusinessRegistry.RegistrationAuthority> GetRegistrationAuthorityAsync(string authorityCode)
        {
            return GetAsync<BusinessRegistry.RegistrationAuthority>(
                $"{Urls.Information}/businessregistry/{authorityCode}");
        }

        /// <inheritdoc />
        public IEnumerable<Geodata.CountryListItem> ListCountries(string lang = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/geodata/countries",
                new Dictionary<string, object>()
                {
                    { "lang", lang }
                });

            return Get<IEnumerable<Geodata.CountryListItem>>(url);
        }

        /// <inheritdoc />
        public Task<IEnumerable<Geodata.CountryListItem>> ListCountriesAsync(string lang = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/geodata/countries",
                new Dictionary<string, object>()
                {
                    { "lang", lang }
                });

            return GetAsync<IEnumerable<Geodata.CountryListItem>>(url);
        }

        /// <inheritdoc />
        public Geodata.CountryInfo GetCountryInfo(string countryCode, string lang = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}",
                new Dictionary<string, object>()
                {
                    { "lang", lang }
                });

            return Get<Geodata.CountryInfo>(url);
        }

        /// <inheritdoc />
        public Task<Geodata.CountryInfo> GetCountryInfoAsync(string countryCode, string lang = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}",
                new Dictionary<string, object>()
                {
                    { "lang", lang }
                });

            return GetAsync<Geodata.CountryInfo>(url);
        }

        /// <inheritdoc />
        public IEnumerable<Geodata.DivisionListItem> ListCountrySubdivisions(string countryCode, string lang = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}/subdivisions",
                new Dictionary<string, object>()
                {
                    { "lang", lang }
                });

            return Get<IEnumerable<Geodata.DivisionListItem>>(url);
        }

        /// <inheritdoc />
        public Task<IEnumerable<Geodata.DivisionListItem>> ListCountrySubdivisionsAsync(string countryCode,
            string lang = null)
        {
            var url = APIHelper.AppendQueryParams($"{Urls.Information}/geodata/countries/{countryCode}/subdivisions",
                new Dictionary<string, object>()
                {
                    { "lang", lang }
                });

            return GetAsync<IEnumerable<Geodata.DivisionListItem>>(url);
        }
    }
}