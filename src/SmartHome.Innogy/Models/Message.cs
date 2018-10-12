///-----------------------------------------------------------------
///   File:         Message.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:41:40
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using SmartHome.Innogy.Models.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Message" />
    /// </summary>
    public class Message : IHasID
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
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Class
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Read
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Gets or sets the TimeStamp
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        public NamedList<NameValue> Data { get; set; }

        /// <summary>
        /// Gets or sets the Devices
        /// </summary>
        public List<Value> Devices { get; set; }

        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public Value Product { get; set; }
    }
}
