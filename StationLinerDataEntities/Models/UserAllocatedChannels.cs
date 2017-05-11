using System.ComponentModel.DataAnnotations.Schema;

namespace StationLinerDataEntities.Models
{
    public class UserAllocatedChannels
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        [ForeignKey("Channels")]
        public long ChannelId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Channels Channels { get; set; }
//        public virtual
    }
}