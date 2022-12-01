namespace Signicat.Information.BusinessRegistry
{
    public class RegistrationAuthority : RegistrationAuthorityBase
    {
        /// <summary>
        ///     Localized name of the responsible organization
        /// </summary>
        public string ResponsibleOrgLocalizedName { get; set; }

        /// <summary>
        ///     Name of the responsible organization
        /// </summary>
        public string ResponsibleOrgInternationalName { get; set; }

        /// <summary>
        ///     Website
        /// </summary>
        public string Website { get; set; }
    }
}