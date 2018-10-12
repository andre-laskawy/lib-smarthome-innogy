///-----------------------------------------------------------------
///   File:         FormulaPart.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:38:31
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="FormulaPart" />
    /// </summary>
    public class FormulaPart
    {
        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Constant
        /// </summary>
        public Value Constant { get; set; }
    }
}
