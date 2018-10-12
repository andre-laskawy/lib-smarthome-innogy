///-----------------------------------------------------------------
///   File:         Condition.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:37:55
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Condition" />
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Tags
        /// </summary>
        public List<NameValue> Tags { get; set; }

        /// <summary>
        /// Gets or sets the LEqP
        /// </summary>
        public LFormulaPart LEqP { get; set; }

        /// <summary>
        /// Gets or sets the Operator
        /// </summary>
        public FormulaPart Operator { get; set; }

        /// <summary>
        /// Gets or sets the REqP
        /// </summary>
        public FormulaPart REqP { get; set; }
    }
}
