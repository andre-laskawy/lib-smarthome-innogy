///-----------------------------------------------------------------
///   File:         BaseUtility.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:44:36
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models.Base
{
    /// <summary>
    /// Defines the <see cref="BaseUtility" />
    /// </summary>
    public abstract class BaseUtility : IHasID
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }
    }
}
