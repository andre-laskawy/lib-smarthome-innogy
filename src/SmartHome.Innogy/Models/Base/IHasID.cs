///-----------------------------------------------------------------
///   File:         IHasID.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:43:56
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models.Base
{
    /// <summary>
    /// Defines the <see cref="IHasID" />
    /// </summary>
    public interface IHasID
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        string ID { get; set; }
    }
}
