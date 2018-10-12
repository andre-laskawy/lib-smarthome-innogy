///-----------------------------------------------------------------
///   File:         LocationTypes.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:47:04
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models.Base
{
    /// <summary>
    /// Defines the <see cref="LocationTypes" />
    /// </summary>
    public class LocationTypes
    {
        /// <summary>
        /// Gets or sets the Cached
        /// </summary>
        public string Cached { get; set; }

        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedTime
        /// </summary>
        public string ModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the Partition
        /// </summary>
        public string Partition { get; set; }

        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets the Data
        /// </summary>
        public LocationData Data
        {
            get { return Newtonsoft.Json.JsonConvert.DeserializeObject<LocationData>(Value); }
        }
    }
}