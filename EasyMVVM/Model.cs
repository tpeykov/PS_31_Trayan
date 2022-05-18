using System;
using System.Collections.ObjectModel;

namespace EasyMVVM
{
    public class Model
    {
        ObservableCollection<string> data = new ObservableCollection<string>();
        public ObservableCollection<string> GetData()
        {
            data.Add("First Entry");
            data.Add("Second Entry");
            data.Add("Third Entry");
            return data;
        }
    }
}