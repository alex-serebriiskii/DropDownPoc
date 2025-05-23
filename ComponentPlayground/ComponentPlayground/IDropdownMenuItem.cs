using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentPlayground
{
    public interface IDropdownMenuItem
    {
        string Text { get; set; }
        bool IsChecked { get; set; }
    }
}
