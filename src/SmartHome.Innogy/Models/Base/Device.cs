///-----------------------------------------------------------------
///   File:         Device.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:45:14
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models.Base
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Device" />
    /// </summary>
    public class Device : BaseUtility
    {
        /// <summary>
        /// Gets or sets the Manufacturer
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the SerialNumber
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the Capabilities
        /// </summary>
        public List<Value> Capabilities { get; set; }

        /// <summary>
        /// Gets or sets the Location
        /// </summary>
        public List<Value> Location { get; set; }

        /// <summary>
        /// Gets or sets the Tags
        /// </summary>
        public NamedList<NameValue> Tags { get; set; }
    }
}
