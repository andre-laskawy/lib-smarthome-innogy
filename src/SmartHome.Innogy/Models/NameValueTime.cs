///-----------------------------------------------------------------
///   File:         NameValueTime.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:26:25
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="NameValueTime" />
    /// </summary>
    public class NameValueTime : NameValue
    {
        /// <summary>
        /// Gets or sets the last changed.
        /// </summary>
        public string LastChanged { get; set; }
    }
}
