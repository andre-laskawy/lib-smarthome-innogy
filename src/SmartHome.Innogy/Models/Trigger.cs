///-----------------------------------------------------------------
///   File:         Trigger.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:35:13
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Trigger" />
    /// </summary>
    public class Trigger
    {
        /// <summary>
        /// Gets or sets the EventType
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the Link
        /// </summary>
        public Value Link { get; set; }

        /// <summary>
        /// Gets or sets the Tags
        /// </summary>
        public List<NameValue> Tags { get; set; }

        /// <summary>
        /// Gets or sets the Conditions
        /// </summary>
        public List<Condition> Conditions { get; set; }
    }
}