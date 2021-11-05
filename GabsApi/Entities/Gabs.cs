using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GabsApi.Model
{
    /// <summary>
    /// Gabs entity.
    /// </summary>
    public class Gabs
    {
        /// <summary>
        /// The Gabs Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Gabs name.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// The Gabs Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The Gabs description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A list containing new Gabs.
        /// </summary>
        public ICollection<OtherGabs> GabsList { get; set; } = new List<OtherGabs>();
    }
}