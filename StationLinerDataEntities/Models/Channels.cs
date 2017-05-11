using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StationLinerDataEntities.Models
{
    public class Channels
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Channel Name"), Required]

        public string ChannelName { get; set; }
        [DisplayName("Channel Description")]
        public string ChannelDescription { get; set; }
        [DisplayName("ChannelType")]
        [ForeignKey("Types")]
        public long? ChannelType { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Boolean IsDeleted { get; set; }

        public virtual ChannelTypes Types { get; set; }

    }
}