using System.Collections.ObjectModel;

namespace ComponentPlayground;

public partial class DropdownMenuBar : ContentView
{
	public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(string), typeof(MenuBar), "top");
	public string Orientation
	{
		get => (string)GetValue(OrientationProperty);
		set => SetValue(OrientationProperty, value);
	}

	public static readonly BindableProperty StackPositionProperty = BindableProperty.Create(nameof(StackPosition), typeof(string), typeof(MenuBar), "left");
	public string StackPosition
	{
		get => (string)GetValue(StackPositionProperty);
		set => SetValue(StackPositionProperty, value); 
	}
	public DropdownMenuBar()
	{
		Collection<DefaultDropdownMenuItem> Items = new Collection<DefaultDropdownMenuItem>
		{
			new DefaultDropdownMenuItem
			{
				Label = "First Item"
			},
			new DefaultDropdownMenuItem
			{
				Label = "Second Item",
				Items = new Collection<DropdownMenuItem> {
					new DefaultDropdownMenuItem
                    {
                        Label = "Inner Item"
                    }
				}
			},
			new DefaultDropdownMenuItem
			{
				Label = "Third Item"
			}

		};

		InitializeComponent();
	}
}