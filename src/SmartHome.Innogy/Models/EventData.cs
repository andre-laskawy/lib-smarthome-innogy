///-----------------------------------------------------------------
///   File:         EventData.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:32:45
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="EventData" />
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the TimeStamp
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Link
        /// </summary>
        public Value Link { get; set; }

        /// <summary>
        /// Gets or sets the Properties
        /// </summary>
        public NamedList<NameValueTime> Properties { get; set; }
    }
}