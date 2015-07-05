using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelerikWpfDemo1
{
    public class ComboBoxItem1 : ICheckable
    {
        private string _text;
        private bool _isChecked;

        public ComboBoxDataItemCollection Owner { get; private set; }

        public void SetOwner(ComboBoxDataItemCollection owner)
        {
            this.Owner = owner;
        }

        public void ClearOwner()
        {
            this.Owner = null;
        }

        public bool IsChecked
        {
            get
            {
                return this._isChecked;
            }
            set
            {
                if (this._isChecked != value)
                {
                    this._isChecked = value;
                    this.OnPropertyChanged("IsChecked");
                }
            }
        }

        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                if (this._text != value)
                {
                    this._text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
