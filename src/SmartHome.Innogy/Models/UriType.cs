///-----------------------------------------------------------------
///   File:         UriType.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:19:10
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System;

    /// <summary>
    /// Defines the <see cref="UriType" />
    /// </summary>
    internal class UriType
    {
        /// <summary>
        /// Request URI
        /// </summary>
        public readonly string Uri;

        /// <summary>
        /// The type
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriType"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="type">The type.</param>
        public UriType(string uri, Type type)
        {
            this.Uri = uri;
            this.Type = type;
        }
    }
}