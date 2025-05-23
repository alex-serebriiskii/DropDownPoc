using System.Security.Cryptography.X509Certificates;

namespace ComponentPlayground;

public class AbsoluteLayoutTest : ContentView
{
	public static readonly BindableProperty DropdownMenuItemsProperty = BindableProperty.Create(nameof(DropdownMenuItems),typeof(ICollection<DropdownMenuItem>),typeof(AbsoluteLayoutTest));
	public ICollection<DropdownMenuItem> DropdownMenuItems
	{
		get => (ICollection<DropdownMenuItem>)GetValue(DropdownMenuItemsProperty);
		set => SetValue(DropdownMenuItemsProperty, value);
	}

	public AbsoluteLayoutTest()
	{
		
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
	private AbsoluteLayout BuildLayout()
	{
		var layout = new AbsoluteLayout();
		foreach (var menuItem in DropdownMenuItems)
		{
		}
		return layout;
	}
}