using System.Windows.Input;

namespace kp_grid_app_poc.lib
{
    public class Commands
    {
        public static RoutedUICommand Import = new RoutedUICommand("Import command", "Import", typeof(Commands));
        public static RoutedUICommand Export = new RoutedUICommand("Export command", "Export", typeof(Commands));
    }
}
