///-----------------------------------------------------------------
///   File:         LocationData.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:47:36
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models.Base
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="LocationData" />
    /// </summary>
    public class LocationData
    {
        /// <summary>
        /// Gets or sets the LocationTypes
        /// </summary>
        public List<LocationTypeID> LocationTypes { get; set; }

        /// <summary>
        /// Gets or sets the Localisation
        /// </summary>
        public LocationTypeLocalisation Localisation { get; set; }
    }
}
