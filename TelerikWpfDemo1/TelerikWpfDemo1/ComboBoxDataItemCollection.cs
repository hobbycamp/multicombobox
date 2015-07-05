using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikWpfDemo1
{
    public class ComboBoxDataItemCollection : ObservableCollection<ICheckable>
    {
        public ComboBoxDataItemCollection()
        {
            this._checkedItems = new ObservableCollection<ICheckable>();
        }

        public ComboBoxDataItemCollection(NotifyCollectionChangedEventHandler handler)
            : this()
        {
            this._checkedItems.CollectionChanged += handler;
        }

        private ObservableCollection<ICheckable> _checkedItems;
        public ObservableCollection<ICheckable> CheckedItems
        {
            get
            {
                return this._checkedItems;
            }
        }

        public NotifyCollectionChangedEventHandler OnCheckedItemsChanged { get; set; }

        protected override void ClearItems()
        {
            foreach (ICheckable item in this)
            {
                item.ClearOwner();
                item.PropertyChanged -= this.OnItemPropertyChanged;
            }

            base.ClearItems();
            this.CheckedItems.Clear();
        }

        protected override void InsertItem(int index, ICheckable item)
        {
            base.InsertItem(index, item);

            item.SetOwner(this);
            item.PropertyChanged += this.OnItemPropertyChanged;
        }

        protected override void RemoveItem(int index)
        {
            this[index].ClearOwner();
            this[index].PropertyChanged -= this.OnItemPropertyChanged;

            base.RemoveItem(index);
        }

        protected override void SetItem(int index, ICheckable item)
        {
            base.SetItem(index, item);

            item.SetOwner(this);
            item.PropertyChanged += this.OnItemPropertyChanged;
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                ICheckable item = sender as ICheckable;
                if (item.IsChecked)
                {
                    if (this._checkedItems == null || !this.CheckedItems.Contains(item))
                    {
                        this.CheckedItems.Add(item);
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CheckedItems"));
                    }
                }
                else
                {
                    if (this._checkedItems != null && this.CheckedItems.Contains(item))
                    {
                        this.CheckedItems.Remove(item);
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CheckedItems"));
                    }
                }
            }
        }
    }
}
