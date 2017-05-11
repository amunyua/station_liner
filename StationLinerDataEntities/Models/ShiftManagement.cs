using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StationLinerDataEntities.Models
{
    public class Shift
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("Channels"),DisplayName("Channel")]
        public long ChannelId { get; set; }

        public DateTime StartTime { get ; set; }

        public DateTime EndTime { get; set; }

        public Boolean Status { get; set; }
        public Boolean IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public virtual Channels Channels { get; set; }


    }
}