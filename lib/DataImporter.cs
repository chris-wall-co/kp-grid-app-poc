using kp_grid_app_poc.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace kp_grid_app_poc.lib
{
    public class DataImporter
    {
        public static IEnumerable<Machine> ReadCsvFile(string filePath)
        {
            var machines = new List<Machine>();

            using (var reader = new StreamReader(filePath))
            {
                var lines = reader.ReadToEnd().Split(Environment.NewLine);

                var max = lines.Length > 100 ? 100 : lines.Length;

                for (var i = 1; i < max; i++)
                {
                    var line = lines[i];
                    var values = line.Split(',');
                    
                    if (values.Length < 20)
                    {
                        continue;
                    }

                    machines.Add(new Machine
                    {
                        ComputerName = values[0],
                        Region = values[5],
                        EusArea = values[6],
                        Facility = values[7],
                        SerialNumber = values[19]
                    });

                }

            }

            return machines.AsEnumerable();
        }
    }
}
