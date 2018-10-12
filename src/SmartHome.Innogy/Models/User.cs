///-----------------------------------------------------------------
///   File:         User.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:42:45
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the AccountName
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the TenantID
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        public NamedList<NameValue> Data { get; set; }
    }
}
