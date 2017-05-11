using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLinerDataEntities.Models
{
    public class Roles
    {
        [Key]
        public long RoleId { get; set; }
        [Required]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        public int UserLevel { get; set; }

        public string Description { get; set; }
        public long CreatedBy { get; set; }
    }
}
