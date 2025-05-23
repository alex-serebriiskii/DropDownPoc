using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentPlayground
{
    public partial class Item : ObservableObject, IDropdownMenuItem
	{
		public string Text { get; set; } = string.Empty;
		[ObservableProperty] bool isChecked = false;	
		public bool Selected { get; set; }
	}
}
