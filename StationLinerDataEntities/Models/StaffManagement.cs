using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StationLinerDataEntities.Models
{
    public class Staff
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { set; get; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PIN { get; set; }
        [Required]
        public string IdNumber { get; set; }
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [DisplayName("Channel"),
        ForeignKey("Channels")]
        public long ChannelId { get; set; }
        [ForeignKey("Roles")]
        [Required]
        public long Role { get; set; }
        [DisplayName("Business Role"), ForeignKey("BusinessRoles")]
        [Required]
        public long BusinessRole { get; set; }

        public long? UserId { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public long CreatedBy { get; set; }


        public virtual Channels Channels { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual BusinessRoles BusinessRoles { get; set; }
    }
}