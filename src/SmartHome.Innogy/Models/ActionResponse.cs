///-----------------------------------------------------------------
///   File:         ActionResponse.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:31:04
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="ActionResponse" />
    /// </summary>
    public class ActionResponse
    {
        /// <summary>
        /// Defines the Desc
        /// </summary>
        public string Desc;

        /// <summary>
        /// Defines the Type
        /// </summary>
        public string Type;

        /// <summary>
        /// Defines the Link
        /// </summary>
        public Value Link;

        /// <summary>
        /// Defines the ResultCode
        /// </summary>
        public string ResultCode;
    }
}