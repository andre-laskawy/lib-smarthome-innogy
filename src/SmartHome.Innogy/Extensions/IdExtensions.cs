///-----------------------------------------------------------------
///   File:         IdExtensions.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:03:39
///-----------------------------------------------------------------

namespace SmartHome.Innogy
{
    /// <summary>
    /// Defines the <see cref="IdExtensions" />
    /// </summary>
    public static class IdExtensions
    {
        /// <summary>
        /// Convert to clean id
        /// </summary>
        /// <param name="rawID">The raw identifier.</param>
        /// <returns></returns>
        public static string CleanID(this string rawID)
        {
            string CleanID = "";
            if (((rawID.IndexOf("/") + 1) > 0))
            {
                CleanID = rawID.Substring(rawID.LastIndexOf("/"));
            }
            else
            {
                CleanID = rawID;
            }
            return CleanID;
        }
    }
}
