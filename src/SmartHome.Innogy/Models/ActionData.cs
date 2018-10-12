///-----------------------------------------------------------------
///   File:         ActionData.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:30:01
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="ActionData" />
    /// </summary>
    public class ActionData
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
        public Value2 Constant { get; set; }
    }
}
