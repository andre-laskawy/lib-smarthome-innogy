///-----------------------------------------------------------------
///   File:         Interaction.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:41:05
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using SmartHome.Innogy.Models.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Interaction" />
    /// </summary>
    public class Interaction : IHasID
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets the Modified
        /// </summary>
        public string Modified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether isInternal
        /// </summary>
        public bool isInternal { get; set; }

        /// <summary>
        /// Gets or sets the FreezeTime
        /// </summary>
        public int FreezeTime { get; set; }

        /// <summary>
        /// Gets or sets the Tags
        /// </summary>
        public List<NameValue> Tags { get; set; }

        /// <summary>
        /// Gets or sets the Rules
        /// </summary>
        public List<Rule> Rules { get; set; }
    }
}
