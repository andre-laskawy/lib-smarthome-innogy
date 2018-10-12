///-----------------------------------------------------------------
///   File:         CustomTrigger.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:36:50
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="CustomTrigger" />
    /// </summary>
    public class CustomTrigger
    {
        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Link
        /// </summary>
        public Value Link { get; set; }

        /// <summary>
        /// Gets or sets the Properties
        /// </summary>
        public List<NameValue> Properties { get; set; }
    }
}