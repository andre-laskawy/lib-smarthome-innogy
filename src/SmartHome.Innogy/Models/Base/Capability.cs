///-----------------------------------------------------------------
///   File:         Capability.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:44:53
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models.Base
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Capability" />
    /// </summary>
    public class Capability : BaseUtility
    {
        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the Device
        /// </summary>
        public List<Value> Device { get; set; }
    }
}
