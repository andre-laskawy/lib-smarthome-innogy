///-----------------------------------------------------------------
///   File:         DeviceActivity.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:32:05
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="DeviceActivity" />
    /// </summary>
    public class DeviceActivity
    {
        /// <summary>
        /// Defines the Activities
        /// </summary>
        public List<Activity> Activities;

        /// <summary>
        /// Defines the Count
        /// </summary>
        public int Count;

        /// <summary>
        /// Defines the Desc
        /// </summary>
        public string Desc;

        /// <summary>
        /// Defines the Returned
        /// </summary>
        public int Returned;
    }
}