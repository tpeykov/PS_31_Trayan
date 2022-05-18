using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<string> BackingProperty;
        public ObservableCollection<string> BoundProperty
        {
            get { return BackingProperty; }
            set { BackingProperty = value; PropChanged("BoundProperty"); }
        }

        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }
    }
}