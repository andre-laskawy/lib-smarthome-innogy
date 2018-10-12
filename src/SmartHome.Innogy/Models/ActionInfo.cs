///-----------------------------------------------------------------
///   File:         ActionInfo.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:21:48
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ActionInfo" />
    /// </summary>
    public class ActionInfo
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private string _id;

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value.CleanID(); }
        }

        /// <summary>
        /// Gets or sets the Setting
        /// </summary>
        public string Setting { get; set; }

        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Überfüht die Aktions-Infos in das Innogy-Format
        /// </summary>
        /// <returns></returns>
        internal InAction ToInAction()
        {

            InAction inAct = new InAction();

            inAct.Desc = "/desc/device/SHC.RWE/1.0/action/SetState";
            inAct.Type = "device/SHC.RWE/1.0/action/SetState";
            inAct.TimeStamp = DateTime.Now.ToString("yy-MM-dd hh:mm:ss");

            inAct.Link = new Value2 { Value = "/capability/" + ID };

            inAct.Data = new List<ActionData>();
            inAct.Data.Add(new ActionData
            {
                Constant = new Value2 { Value = Value },
                Name = Setting,
                Type = "/entity/Constant"
            });
            return inAct;
        }
    }
}