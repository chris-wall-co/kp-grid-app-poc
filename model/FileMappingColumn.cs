using System.Text.Json.Serialization;

namespace kp_grid_app_poc.model
{
    public class FileMappingColumn
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("header")]
        public string Header { get; set; }

        [JsonPropertyName("source")]
        public int SourceColumn { get; set; }

        [JsonPropertyName("destination")]
        public string DestinationColumn { get; set; }
    }
}
