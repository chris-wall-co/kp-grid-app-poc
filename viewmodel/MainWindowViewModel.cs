using kp_grid_app_poc.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace kp_grid_app_poc.viewmodel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.FilteredList = new ObservableCollection<Machine>();
        }
        
        public ObservableCollection<Machine> FilteredList { get; private set; }

        public void Filter()
        {

        }
    }
}
