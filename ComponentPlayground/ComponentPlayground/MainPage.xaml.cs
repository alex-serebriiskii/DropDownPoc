using System.Collections.ObjectModel;

namespace ComponentPlayground
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private MainPageVm vm;
        public ObservableCollection<Item> Items = new ObservableCollection<Item>
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

        public MainPage(MainPageVm mainPageVm)
        {
            InitializeComponent();

            BindingContext = mainPageVm;
            vm = mainPageVm;
            GridTest<Item> test = new GridTest<Item>
            {
                DisplayItems = vm.Items,
                ResetCommand = vm.ResetSelectionCommand 
            };
            test.SetBinding();
            maincell.Add(test);
            Grid manyGrid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                },
                RowDefinitions =
                {
                    new RowDefinition(),
                }

            };
            var gt1 = new GridTest<Item>
            {
                    DisplayItems = vm.Items1
            };
            var gt2 = new GridTest<Item>
            {
                    DisplayItems = vm.Items2
            };
            var gt3 = new GridTest<Item>
            {
                    DisplayItems = vm.Items3
            };
            gt1.SetBinding();
            gt2.SetBinding();
            gt3.SetBinding();
            manyGrid.Add(gt1, 0);
            manyGrid.Add(gt2, 1);
            manyGrid.Add(gt3, 2);
            manyGrid.ColumnSpacing = 3;
            maincell.Add(manyGrid, 2, 0);
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
