using kp_grid_app_poc.lib;
using kp_grid_app_poc.model;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace kp_grid_app_poc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Get a reference to the tasks collection.
            var _items = (Machines)this.Resources["machines"];
         }

        private void UngroupButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
            if (cvTasks != null)
            {
                cvTasks.GroupDescriptions.Clear();
            }
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
            if (cvTasks != null && cvTasks.CanGroup == true)
            {
                cvTasks.GroupDescriptions.Clear();
                cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("Region"));
                cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("EusArea"));
                cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("Facility"));
            }
        }

        private void CompleteFilter_Changed(object sender, RoutedEventArgs e)
        {
            // Refresh the view to apply filters.
            CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource).Refresh();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            var t = e.Item as Machine;
            if (t != null)
            {
                // apply filters
                var cnFilter = filterComputerName.Text;
                var rgFilter = filterRegion.Text;
                var eaFilter = filterEusArea.Text;
                var faFilter = filterFacility.Text;


                e.Accepted = true;

                if (!string.IsNullOrWhiteSpace(cnFilter) && !string.IsNullOrWhiteSpace(t.ComputerName))
                {
                    e.Accepted = e.Accepted && t.ComputerName.Contains(cnFilter, System.StringComparison.InvariantCultureIgnoreCase);
                }

                if (!string.IsNullOrWhiteSpace(rgFilter) && !string.IsNullOrWhiteSpace(t.Region))
                {
                    e.Accepted = e.Accepted && t.Region.Contains(rgFilter, System.StringComparison.InvariantCultureIgnoreCase);
                }

                if (!string.IsNullOrWhiteSpace(eaFilter) && !string.IsNullOrWhiteSpace(t.EusArea))
                {
                    e.Accepted = e.Accepted && t.EusArea.Contains(eaFilter, System.StringComparison.InvariantCultureIgnoreCase);
                }

                if (!string.IsNullOrWhiteSpace(faFilter) && !string.IsNullOrWhiteSpace(t.Facility))
                {
                    e.Accepted = e.Accepted && t.Facility.Contains(faFilter, System.StringComparison.InvariantCultureIgnoreCase);
                }
            }
        }

        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Import_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files|*.csv";
            dialog.DefaultExt = ".csv";

            if (dialog.ShowDialog() == true)
            {
                var list = DataImporter.ReadCsvFile(dialog.FileName);
                var _items = (Machines)this.Resources["machines"];
                
                foreach(var machine in list)
                {
                    _items.Add(machine);
                }
            }
        }

        private void Export_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "CSV Files|*.csv";
            dialog.DefaultExt = ".csv";

            if (dialog.ShowDialog() == true)
            {
                var dv = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
                var list = dv.Cast<Machine>();
                var content = DataExporter.ExportCSV(list);
                File.WriteAllText(dialog.FileName, content);
            }
        }
    }
}
