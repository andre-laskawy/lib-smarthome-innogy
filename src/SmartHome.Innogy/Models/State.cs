///-----------------------------------------------------------------
///   File:         State.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:42:08
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using SmartHome.Innogy.Models.Base;

    /// <summary>
    /// Defines the <see cref="DeviceState" />
    /// </summary>
    public class DeviceState : IHasID
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        public NamedList<NameValueTime> State { get; set; }
    }
}
