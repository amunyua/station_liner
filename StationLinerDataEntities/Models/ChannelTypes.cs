using System.ComponentModel.DataAnnotations;

namespace StationLinerDataEntities.Models
{
    public class ChannelTypes
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}