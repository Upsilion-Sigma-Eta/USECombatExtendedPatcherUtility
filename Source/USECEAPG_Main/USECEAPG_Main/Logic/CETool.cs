using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class CETool : VanillaCompatTool
    {
        public double ArmorPenetrationSharp { get; set; }
        public double ArmorPenetrationBlunt { get; set; }
        public string RestrictedGeneder { get; set; }
        public string RequiredAttachments { get; set; }
    }
}
