using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StationLinerDataEntities.Models
{
    public class Pump
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        [ForeignKey("Channel")]
        public long ChannelId { get; set; }
        public long CreatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool Status { get; set; }

        public virtual Channels Channel { get; set; }
    }

    public class NozzleType
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public long CreatedBy { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }

    public class Nozzle
    {
        [Key]
        public long Id { get; set; }
        [Required, DisplayName("Nozzle Name")]
        public string NozzleName { get; set; }
        public string Description { get; set; }
        [ForeignKey("NozzleTypes"),Required]
        public long NozzleType { get; set; }
        [Required,ForeignKey("Pump")]
        public long PumpId { get; set; }

        public long CreatedBy { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public virtual Pump Pump { get; set; }
        public virtual NozzleType NozzleTypes { get; set; }
    }
}