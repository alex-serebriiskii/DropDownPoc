using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ComponentPlayground;

public class CollectionViewTest : ContentView
{
	//string[] items = ["Item1", "Item2", "Item3"];
	ObservableCollection<Item> items = new ObservableCollection<Item>
	{
		new Item
		{
			Text = "Item 1",
			Selected = false
		},
		new Item
		{
			Text = "Item 2",
			Selected = false
		},
		new Item
		{
			Text = "Item 3",
			Selected = false
		}

	};
	Button headerButton = new Button();
	Button footerButton = new Button();
	CollectionView collectionView = new CollectionView();
	bool collapsed = false;
	double fullHeight = 0;
	public CollectionViewTest()
	{
		collectionView.ItemsSource = items;
		collectionView.ItemTemplate = new DataTemplate(() =>
		{
			var hlo = new HorizontalStackLayout();
			var label = new Label { IsEnabled = true};
            label.SetBinding(Label.TextProperty, new Binding("Text"));
			var cbox = new CheckBox();
			cbox.SetBinding(CheckBox.IsCheckedProperty, new Binding("IsChecked",BindingMode.TwoWay));
			
			hlo.Children.Add(label);
			hlo.Children.Add(cbox);
			return hlo;
		});
		headerButton.Text = "Test!";
		headerButton.Clicked += (sender, args) => { ToggleView(); };

		footerButton.Text = "Clear";
		footerButton.Clicked += (sender, args) => { ClearChecked(); };
		collectionView.Header = headerButton;
		collectionView.SelectionChanged += OnSelectionChanged;
		collectionView.Footer = footerButton;
		Content = collectionView; 
	}
	public void ToggleView()
	{
		if (collapsed) 
		{
			collectionView.HeightRequest = fullHeight;	
			collapsed = false;
		}
		else
		{
			fullHeight = collectionView.Height;
			var cutSize = headerButton.Height;
			collectionView.HeightRequest = cutSize;
			collapsed = true;
		}
	}
	public void ClearChecked()
	{
		foreach(var i in items)
		{
			i.IsChecked= false;
		}
	}
	public void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{

	}
	
}
