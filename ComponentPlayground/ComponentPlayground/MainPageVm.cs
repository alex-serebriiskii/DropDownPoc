using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComponentPlayground
{
    [INotifyPropertyChanged]
    public partial class MainPageVm
    {
        [ObservableProperty]
        public ObservableCollection<Item> items;
        [ObservableProperty]
        public ObservableCollection<Item> items1;
        [ObservableProperty]
        public ObservableCollection<Item> items2;
        [ObservableProperty]
        public ObservableCollection<Item> items3;

	    public ICommand ResetSelectionCommand { get; private set; }
        public MainPageVm()
        {
            Random r = new Random();
            ResetSelectionCommand = new Command(() =>
            {
                foreach(var item in items)
                {
                    item.IsChecked = false;
                }
            });
            items = new ObservableCollection<Item>
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
            items1 = new ObservableCollection<Item>();
            items2 = new ObservableCollection<Item>();
            items3 = new ObservableCollection<Item>();
            int ct = 4;
            for (int i = 0; i < r.Next(4, 8); i++)
            {
                items1.Add(new Item
                {
                    Text = "Item" + ct.ToString(),
                    Selected = false
                });
                ct++;
            }
            for (int i = 0; i < r.Next(4, 8); i++)
            {
                items2.Add(new Item
                {
                    Text = "Item" + ct.ToString(),
                    Selected = false
                });
                ct++;
            }
            for (int i = 0; i < r.Next(4, 8); i++)
            {
                items3.Add(new Item
                {
                    Text = "Item" + ct.ToString(),
                    Selected = false
                });
                ct++;
            }

        }
    }
}
