///-----------------------------------------------------------------
///   File:         CurrentConf.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 19:25:36
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="CurrentConf" />
    /// </summary>
    public class CurrentConf
    {
        /// <summary>
        /// Defines the CurrentConfigurationVersion
        /// </summary>
        public int CurrentConfigurationVersion;

        /// <summary>
        /// Defines the Data
        /// </summary>
        public List<DeviceState> Data;
    }
}
