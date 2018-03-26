using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypCoreLibrary.Event
{
    public class RenameDataEntryEventArgs
    {
        public string OldName { get; set; } = String.Empty;
        public string NewName { get; set; } = String.Empty;
    }
}
