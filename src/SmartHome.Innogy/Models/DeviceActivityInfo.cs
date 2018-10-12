///-----------------------------------------------------------------
///   File:         DeviceActivityInfo.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:23:51
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System;

    /// <summary>
    /// Defines the <see cref="DeviceActivityInfo" />
    /// </summary>
    public class DeviceActivityInfo
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value.CleanID(); }
        }

        /// <summary>
        /// The identifier
        /// </summary>
        private string _id;

        /// <summary>
        /// Gets or sets the StartDate
        /// The start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// To the query.
        /// </summary>
        /// <returns></returns>
        internal string ToQuery()
        {
            return ToQuery(1);
        }

        /// <summary>
        /// To the query.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        internal string ToQuery(int page)
        {
            string qStr = null;

            qStr = _id + "/?page=" + page;

            if (StartDate != null)
                qStr = qStr + "&start=" + StartDate.ToString("yyyy-MM-dd");

            if (EndDate != null)
                qStr = qStr + "&end=" + EndDate.ToString("yyyy-MM-dd");

            return qStr;
        }
    }
}