using kp_grid_app_poc.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace kp_grid_app_poc.lib
{
    internal class Mapper
    {
        internal Mapper(FileMapping mapping)
        {
            this._mapping = mapping;
        }

        private FileMapping _mapping { get; set; }

        internal IEnumerable<string> MapDocument(string[] contents)
        {
            var dataset = new List<string>();

            foreach(var line in contents)
            {
                var columns = line.Split(',');
            }

            return dataset;
        }
    }
}
