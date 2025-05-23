using Microsoft.Maui.Controls.Shapes;
using System.Windows.Input;

namespace ComponentPlayground;

public class GridTest<T> : ContentView where T : IDropdownMenuItem, new()
{
	Button headerButton = new Button();
	Button footerButton = new Button();
	CollectionView bodyCollection;
	Frame frame;
	Border border;
	Grid grid = new Grid();
	bool collapsed = false;
	double fullHeight1 = 0;
	GridLength fullHeight2 = 0;
	GridLength fullHeight3 = 0;

	public static readonly BindableProperty DisplayItemsProperty = BindableProperty.Create(nameof(DisplayItems),typeof(ICollection<T>), typeof(GridTest<T>));
	public ICollection<T> DisplayItems
	{
		get => (ICollection<T>)GetValue(DisplayItemsProperty);
		set => SetValue(DisplayItemsProperty, value);
	}
	public static readonly BindableProperty ResetCommandProperty = BindableProperty.Create(nameof(ResetCommand),typeof(Command),typeof(GridTest<T>));
	public ICommand ResetCommand
	{
		get => (Command)GetValue(ResetCommandProperty); 
		set => SetValue(ResetCommandProperty, value);
	}
	public GridTest()
	{
		border = new Border();
		border.Stroke = Color.Parse("Green");
		border.StrokeThickness = 10;
		border.BackgroundColor = Color.Parse("Gray");
		//border.Padding = new Thickness(8);
		border.StrokeShape = new Rectangle();
		grid.RowDefinitions.Add(new RowDefinition
		{
			Height = 50
		});
		grid.RowDefinitions.Add(new RowDefinition());
		grid.RowDefinitions.Add(new RowDefinition
		{
			Height = 50
		});

		grid.ColumnDefinitions.Add(new ColumnDefinition());
		grid.MaximumWidthRequest = 500;
		grid.MaximumHeightRequest = 400;
		headerButton.Text = "Test!";
		headerButton.Clicked += (s, e) => { ToggleView(); };

		footerButton.Text = "Clear";
		footerButton.Clicked += (s, e) => { ClearSelection(); };
		grid.Add(headerButton,0,0);
		bodyCollection = new CollectionView
		{
			SelectionMode = SelectionMode.Multiple,
		};
		bodyCollection.ItemTemplate = new DropdownTemplate();
		bodyCollection.SelectionChanged += (s, e) =>
		{
			var prev = e.PreviousSelection;
			var current = e.CurrentSelection;
			List<object> diff;
			if (prev.Count > current.Count)
			{
				diff = prev.Except(current).ToList();

				var i = (T)diff[0];
				i.IsChecked = false;
				
			}else if(prev.Count < current.Count)
			{
				diff=current.Except(prev).ToList();

				var i = (T)diff[0];
				i.IsChecked=true;
			}

		};
		grid.Add(footerButton,0,2);
		//bodyCollection.Footer = footerButton;
		border.Content = bodyCollection;
		
		grid.Add(border,0,1);
		Content = grid;
	}
	public void SetBinding()
	{
		bodyCollection.ItemsSource = DisplayItems;
		//footerButton.Command = ResetCommand;
	}
	public void ToggleView()
	{
		if (collapsed) 
		{

			grid.RowDefinitions[1].Height = fullHeight2; 
			grid.RowDefinitions[2].Height = fullHeight3;
			bodyCollection.IsVisible = collapsed;

			bodyCollection.HeightRequest= fullHeight1;
			collapsed = false;
		}
		else
		{
			fullHeight1 = bodyCollection.HeightRequest;
			fullHeight2 = grid.RowDefinitions[1].Height;
			fullHeight3 = grid.RowDefinitions[2].Height;
			bodyCollection.HeightRequest= 0;
			grid.RowDefinitions[1].Height = 0;
			grid.RowDefinitions[2].Height = 0;
			bodyCollection.IsVisible = collapsed;
			collapsed = true;
		}
	}
	public void ClearSelection()
	{
		foreach(var item in DisplayItems)
		{
			item.IsChecked= false;
		}
		//ResetCommand.Execute(null);
		bodyCollection.SelectedItems = null;
	}
}