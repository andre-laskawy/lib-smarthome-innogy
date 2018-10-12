///-----------------------------------------------------------------
///   File:         InFunction.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:39:55
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="InFunction" />
    /// </summary>
    public class InFunction
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
        /// Gets or sets the Parameters
        /// </summary>
        public List<FormulaPart> Parameters { get; set; }
    }
}
