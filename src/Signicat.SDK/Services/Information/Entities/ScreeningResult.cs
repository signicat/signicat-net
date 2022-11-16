using System.Collections.Generic;

namespace Signicat.Information
{
    public class ScreeningResult : PagedCollection<ScreenedItem, Metadata>
    {

    }

    public class ScreenedItem
    {
        public EntityType EntityType { get; set; }
        
        public ListType ListType { get; set; }
        
        public MatchStrength MatchStrength { get; set; }
        
        /// <summary>
        /// Name of the source the item was found in
        /// </summary>
        public string SourceName { get; set; }
        
        public Name Name { get; set; }
        
        public Gender Gender { get; set; }
        
        /// <summary>
        /// Aliases for the item
        /// </summary>
        public IList<Name> Aliases { get; set; }
        
        /// <summary>
        /// Associates of the item (Only for entityType "person")
        /// </summary>
        public IList<Associate> Associates { get; set; }
        
        /// <summary>
        /// Possible dates of birth (Only for entityType "person")
        /// </summary>
        public IList<ApproximateBirth> DatesOfBirth { get; set; }
        
        /// <summary>
        /// Addresses of the entity
        /// </summary>
        public IList<Address> Addresses { get; set; }
        
        /// <summary>
        /// Comments
        /// </summary>
        public IList<NamedValue> Comments { get; set; }
        
        /// <summary>
        /// Functions
        /// </summary>
        public IList<FunctionDto> Functions { get; set; }
        
        /// <summary>
        /// Online content related to the item (Only for entityType "person")
        /// </summary>
        public IList<MediaLink> Media { get; set; }
    }
}