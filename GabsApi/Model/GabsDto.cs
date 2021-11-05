using System.Collections.Generic;

namespace GabsApi.Model
{
    /// <summary>
    /// The Gabs Dto.
    /// </summary>
    public class GabsDto
    {
        /// <summary>
        /// The Gabs Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Gabs name.
        /// </summary>
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
        public ICollection<OtherGabsDto> GabsList { get; set; } = new List<OtherGabsDto>();
    }
}