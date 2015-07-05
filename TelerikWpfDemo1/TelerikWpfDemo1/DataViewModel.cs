using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace TelerikWpfDemo1
{
    public class DataViewModel : ViewModelBase
    {
        public DataViewModel()
        {
            this.Item1Collection = new ComboBoxDataItemCollection(this.OnItem1Checked);
            this.Item1Collection.Add(new ComboBoxItem1()
            {
                Text = "Odd"
            });

            this.Item1Collection.Add(new ComboBoxItem1()
            {
                Text = "Even"
            });

            this.Item2Collection = new ComboBoxDataItemCollection();
//            foreach (var i in Enumerable.Range(0, 10))
//            {
//                this.Item2Collection.Add(new ComboBoxItem1()
//                {
//                    Text = i.ToString()
//                });
//            }
        }

        private void OnItem1Checked(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Item2Collection.Clear();
            foreach (var odd in this.Item1Collection)
            {
                if (odd.Text.Equals("Odd"))
                {
                    foreach (var i in Enumerable.Range(0, 10))
                    {
                        if (i % 2 == 1)
                        {
                            this.Item2Collection.Add(new ComboBoxItem1()
                            {
                                Text = i.ToString()
                            });
                        }
                    }
                } else if (odd.Text.Equals("Even"))
                {
                    foreach (var i in Enumerable.Range(0, 10))
                    {
                        if (i % 2 == 0)
                        {
                            this.Item2Collection.Add(new ComboBoxItem1()
                            {
                                Text = i.ToString()
                            });
                        }
                    }
                }
            }
            this.OnPropertyChanged("Item2Collection");
        }


        public ComboBoxDataItemCollection Item1Collection { get; private set; }

        public ComboBoxDataItemCollection Item2Collection { get; private set; }
    }
}
