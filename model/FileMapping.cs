using System;
using System.Text.Json.Serialization;

namespace kp_grid_app_poc.model
{
    public class FileMapping
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("columns")]
        public FileMappingColumn[] Columns { get; set; }
    }
}
