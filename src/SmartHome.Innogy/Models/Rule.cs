///-----------------------------------------------------------------
///   File:         Rule.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:34:29
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using SmartHome.Innogy.Models.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Rule" />
    /// </summary>
    public class Rule : IHasID
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the ConditionEvaluationDelay
        /// </summary>
        public int ConditionEvaluationDelay { get; set; }

        /// <summary>
        /// Gets or sets the Link
        /// </summary>
        public Value Link { get; set; }

        /// <summary>
        /// Gets or sets the Triggers
        /// </summary>
        public List<Trigger> Triggers { get; set; }

        /// <summary>
        /// Gets or sets the CustomTriggers
        /// </summary>
        public List<CustomTrigger> CustomTriggers { get; set; }

        /// <summary>
        /// Gets or sets the Constraints
        /// </summary>
        public List<Condition> Constraints { get; set; }

        /// <summary>
        /// Gets or sets the Actions
        /// </summary>
        public List<IntAction> Actions { get; set; }
    }
}
