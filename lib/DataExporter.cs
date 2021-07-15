using kp_grid_app_poc.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace kp_grid_app_poc.lib
{
    public class DataExporter
    {
        public static string ExportCSV(IEnumerable<Machine> data)
        {
            var content = new StringBuilder();

            foreach(var m in data)
            {
                content.AppendLine($"{m.ComputerName},{m.Region},{m.EusArea},{m.Facility},{m.SerialNumber}");
            }

            return content.ToString();
        }
    }
}
