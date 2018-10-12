///-----------------------------------------------------------------
///   File:         Value.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:28:47
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    /// <summary>
    /// Defines the <see cref="Value" />
    /// </summary>
    public class Value
    {
        /// <summary>
        /// The value
        /// </summary>
        private string value = null;

        /// <summary>
        /// Gets the raw value.
        /// </summary>
        public object RawValue
        {
            get { return value; }
        }

        /// <summary>
        /// Gets the clean value.
        /// </summary>
        public object CleanValue
        {
            get { return value.CleanID(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Value"/> class.
        /// </summary>
        /// <param name="value">(roher) Wert</param>
        public Value(string value)
        {
            this.value = value;
        }
    }
}