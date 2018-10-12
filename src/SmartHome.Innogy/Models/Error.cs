///-----------------------------------------------------------------
///   File:         Error.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:08:15
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using SmartHome.Innogy.Enums;

    /// <summary>
    /// Defines the <see cref="InnogyError" />
    /// </summary>
    public class InnogyError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public ErrorCodes ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
    }
}
