using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabsApi.Model
{
    /// <summary>
    /// Other possible Gabs.
    /// </summary>
    public class OtherGabs
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
        /// A Gabs.
        /// </summary>

        [ForeignKey("GabsId")]
        public Gabs Gabs { get; set; }

        /// <summary>
        /// Gabs Id.
        /// </summary>
        public int GabsId { get; set; }
    }
}