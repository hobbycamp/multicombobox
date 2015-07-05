using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikWpfDemo1
{
    public interface ICheckable : INotifyPropertyChanged
    {
        bool IsChecked { get; set; }

        string Text { get; set; }

        void ClearOwner();

        void SetOwner(ComboBoxDataItemCollection owner);
    }
}
