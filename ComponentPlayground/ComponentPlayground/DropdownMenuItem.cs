using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentPlayground
{
    public abstract class DropdownMenuItem
    {
        public string Label { get; set; } = string.Empty;
        public ICollection<DropdownMenuItem> Items { get; set; } = [];

    }
}
