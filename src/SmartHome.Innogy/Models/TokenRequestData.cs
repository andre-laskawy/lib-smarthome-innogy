///-----------------------------------------------------------------
///   File:         TokenRequestData.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:13:08
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="TokenRequestData" />
    /// </summary>
    public class TokenRequestData
    {
        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the grant.
        /// </summary>
        public string Grant_Type { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        public string Redirect_Uri { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        public string Refresh_Token { get; set; }
    }
}
