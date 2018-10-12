///-----------------------------------------------------------------
///   File:         TokenResponseData.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:14:37
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="TokenResponseData" />
    /// </summary>
    public class TokenResponseData
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string Access_Token { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        public string Token_Type { get; set; }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        public int Expires_In { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        public string Refresh_Token { get; set; }
    }
}
