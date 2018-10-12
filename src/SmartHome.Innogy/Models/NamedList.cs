///-----------------------------------------------------------------
///   File:         NamedList.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 17:27:47
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="NamedList{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NamedList<T> : List<T> where T : NameValue
    {
        public string this[string name]
        {
            get
            {
                List<T> vals = default(List<T>);
                vals = this.FindAll(nv => nv.Name == name);
                if (vals.Count > 0)
                {
                    return vals.First().Value;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}