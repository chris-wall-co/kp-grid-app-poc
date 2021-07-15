using kp_grid_app_poc.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace kp_grid_app_poc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Mappings = new List<FileMapping>();

        }

        public static List<FileMapping> Mappings { get; private set; }
    }
}
