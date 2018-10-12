///-----------------------------------------------------------------
///   File:         LFormulaPart.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:39:14
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="LFormulaPart" />
    /// </summary>
    public class LFormulaPart : FormulaPart
    {
        /// <summary>
        /// Gets or sets the Function
        /// </summary>
        public InFunction Function { get; set; }
    }
}
