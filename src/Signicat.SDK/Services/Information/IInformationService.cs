using System.Collections.Generic;
using System.Threading.Tasks;
using Signicat.Information.BusinessRegistry;
using Signicat.Information.Geodata;
using Signicat.Information.Organization;
using Signicat.Information.Person;
using BasicInfo = Signicat.Information.Organization.BasicInfo;
using Finance = Signicat.Information.Organization.Finance;
using SearchResult = Signicat.Information.Organization.SearchResult;

namespace Signicat.Information
{
    public interface IInformationService
    {
        /// <summary>
        ///     Retrieve basic info about an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        BasicInfo GetBasicOrganizationInfo(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve basic info about an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<BasicInfo> GetBasicOrganizationInfoAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     This endpoint returns which people are allowed to sign and act on behalf of an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Authorization GetOrganizationAuthorization(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     This endpoint returns which people are allowed to sign and act on behalf of an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<Authorization> GetOrganizationAuthorizationAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve ownership info for an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Ownership GetOrganizationOwnership(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve ownership info for an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<Ownership> GetOrganizationOwnershipAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve information about roles in an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Roles GetOrganizationRoles(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve information about roles in an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<Roles> GetOrganizationRolesAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve information about ultimate beneficial owners for an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Ubo GetOrganizationUltimateBeneficialOwners(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve information about ultimate beneficial owners for an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<Ubo> GetOrganizationUltimateBeneficialOwnersAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve financial info for an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Finance GetOrganizationFinance(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve financial info for an organization.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <param name="idType"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<Finance> GetOrganizationFinanceAsync(
            string country,
            string id,
            string idType = null,
            string source = null,
            bool? rawJson = null);

        /// <summary>
        ///     AML/CFT screening against lists with politically exposed persons (PEP), sanctions and adverse media.
        /// </summary>
        /// <param name="idType"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="listType"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        ScreeningResult OrganizationScreening(
            string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     AML/CFT screening against lists with politically exposed persons (PEP), sanctions and adverse media.
        /// </summary>
        /// <param name="idType"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="listType"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ScreeningResult> OrganizationScreeningAsync(
            string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     Search for an organization.
        /// </summary>
        /// <param name="idType"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="cursor"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        SearchResult OrganizationSearch(
            string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string cursor = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     Search for an organization.
        /// </summary>
        /// <param name="idType"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="cursor"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<SearchResult> OrganizationSearchAsync(
            string idType,
            string countries,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string cursor = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     Retrieve basic info about a person.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Person.BasicInfo GetBasicPersonInfo(
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
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve basic info about a person.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<Person.BasicInfo> GetBasicPersonInfoAsync(
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
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve address info for a person.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        AddressInfo GetPersonAddress(
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
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve address info for a person.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<AddressInfo> GetPersonAddressAsync(
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
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve finance info for a person.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Person.Finance GetPersonFinance(
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
            bool? rawJson = null);

        /// <summary>
        ///     Retrieve finance info for a person.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<Person.Finance> GetPersonFinanceAsync(
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
            bool? rawJson = null);

        /// <summary>
        ///     Verification of a persons address.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        AddressVerification PersonVerifyAddress(
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
            bool? rawJson = null);

        /// <summary>
        ///     Verification of a persons address.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="identityNumber"></param>
        /// <param name="givenName"></param>
        /// <param name="surname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="caseRef"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        Task<AddressVerification> PersonVerifyAddressAsync(
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
            bool? rawJson = null);

        /// <summary>
        ///     AML/CFT screening against lists with politically exposed persons (PEP), sanctions and adverse media.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <param name="postalCode"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="listType"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        ScreeningResult PersonScreening(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     AML/CFT screening against lists with politically exposed persons (PEP), sanctions and adverse media.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <param name="postalCode"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="listType"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ScreeningResult> PersonScreeningAsync(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            string listType = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     Search for a person. Functionality is subject to change without prior notice.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <param name="postalCode"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Person.SearchResult PersonSearch(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     Search for a person. Functionality is subject to change without prior notice.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <param name="postalCode"></param>
        /// <param name="countries"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="rawJson"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<Person.SearchResult> PersonSearchAsync(
            string dateOfBirth = null,
            string postalCode = null,
            string countries = null,
            string id = null,
            string name = null,
            string source = null,
            bool? rawJson = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        ///     Retrieves a list of business registration authorities globally.
        /// </summary>
        /// <returns></returns>
        IEnumerable<RegistrationAuthorityItem> ListRegistrationAuthorities();

        /// <summary>
        ///     Retrieves a list of business registration authorities globally.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RegistrationAuthorityItem>> ListRegistrationAuthoritiesAsync();

        /// <summary>
        ///     Retrieves detailed information about a specific registration authority.
        /// </summary>
        /// <param name="authorityCode"></param>
        /// <returns></returns>
        RegistrationAuthority GetRegistrationAuthority(string authorityCode);

        /// <summary>
        ///     Retrieves detailed information about a specific registration authority.
        /// </summary>
        /// <param name="authorityCode"></param>
        /// <returns></returns>
        Task<RegistrationAuthority> GetRegistrationAuthorityAsync(string authorityCode);

        /// <summary>
        ///     Lists all countries in the world with English name and ISO 3166-1 country code.
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        IEnumerable<CountryListItem> ListCountries(string lang = null);

        /// <summary>
        ///     Lists all countries in the world with English name and ISO 3166-1 country code.
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        Task<IEnumerable<CountryListItem>> ListCountriesAsync(string lang = null);

        /// <summary>
        ///     Retrieves basic geographical information about a country.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        CountryInfo GetCountryInfo(string countryCode, string lang = null);

        /// <summary>
        ///     Retrieves basic geographical information about a country.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        Task<CountryInfo> GetCountryInfoAsync(string countryCode, string lang = null);

        /// <summary>
        ///     Retrieves a list over top level administrative subdivisions for a country with name and ISO 3166-2 region code.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        IEnumerable<DivisionListItem> ListCountrySubdivisions(string countryCode, string lang = null);

        /// <summary>
        ///     Retrieves a list over top level administrative subdivisions for a country with name and ISO 3166-2 region code.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        Task<IEnumerable<DivisionListItem>> ListCountrySubdivisionsAsync(
            string countryCode,
            string lang = null);
    }
}