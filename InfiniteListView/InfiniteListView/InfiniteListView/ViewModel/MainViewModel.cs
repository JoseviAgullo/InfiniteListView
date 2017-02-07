using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using InfiniteListView.Models;
using InfiniteListView.Services;
using Xamarin.Forms;

namespace InfiniteListView.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IItemService _itemService;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private bool _busy { get; set; }

        public bool IsBusy
        {
            get
            {
                return _busy;
            }
            set
            {
                _busy = value;
                OnPropertyChanged();

                LoadMoreItemsCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Item> Items { get; set; }

        public Command LoadMoreItemsCommand { get; set; }

        public MainViewModel(IItemService itemService)
        {
            _itemService = itemService;

            Items = new ObservableCollection<Item>();

            LoadMoreItemsCommand = new Command(
                () => LoadMoreItems(),
                () => !IsBusy);
        }

        private void LoadMoreItems()
        {
            try
            {
                IsBusy = true;

                var newItems = _itemService.GetItems(Items.Count);

                foreach (var newItem in newItems)
                {
                    Items.Add(newItem);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
