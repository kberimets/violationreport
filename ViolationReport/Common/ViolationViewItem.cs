using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViolationReport
{
    public abstract class ViolationViewItem
    {
        public string ViolationReason { get; set; }
        public string Actions { get; set; }
        public string Comment { get; set; }
    }
}
