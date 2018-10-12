///-----------------------------------------------------------------
///   File:         IntAction.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:40:36
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IntAction" />
    /// </summary>
    public class IntAction
    {
        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Link
        /// </summary>
        public Value Link { get; set; }

        /// <summary>
        /// Gets or sets the Tags
        /// </summary>
        public List<NameValue> Tags { get; set; }

        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        public List<FormulaPart> Data { get; set; }
    }
}
