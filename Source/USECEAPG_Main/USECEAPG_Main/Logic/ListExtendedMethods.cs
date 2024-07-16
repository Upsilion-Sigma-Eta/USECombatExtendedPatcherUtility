using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace USECEAPG_Main.Logic
{
    public static class ListExtendedMethods
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static bool IsNullOrEmpty(this XmlNodeList xmlNodeList)
        {
            return xmlNodeList == null || xmlNodeList.Count == 0;
        }
    }
}
