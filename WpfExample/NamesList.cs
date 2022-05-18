using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFExample
{
    public class NamesList : INotifyPropertyChanged
    {
        string firstName = "";
        string lastName = "";
        string selectedName;

        AddCommand addNameCommand = new AddCommand();
        public AddCommand AddNameCommand
        {
            get { return addNameCommand; }
        }

        RemoveCommand removeNameCommand = new RemoveCommand();
        public RemoveCommand RemoveNameCommand
        {
            get { return removeNameCommand; }
        }

        public NamesList()
        {
            Names = new ObservableCollection<string>();
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string SelectedName
        {
            get { return selectedName; }
            set
            {
                if (selectedName != value)
                {
                    selectedName = value;
                    OnPropertyChanged("SelectedName");
                }
            }
        }

        public ObservableCollection<string> Names { get; private set; }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}