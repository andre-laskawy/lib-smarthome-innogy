///-----------------------------------------------------------------
///   File:         InAction.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:30:36
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="InAction" />
    /// </summary>
    public class InAction
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
        /// Defines the TimeStamp
        /// </summary>
        public string TimeStamp;

        /// <summary>
        /// Defines the Link
        /// </summary>
        public Value2 Link;

        /// <summary>
        /// Defines the Data
        /// </summary>
        public List<ActionData> Data;
    }
}