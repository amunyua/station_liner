using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLinerDataEntities.Models
{
    public class UOM
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string UOMName { get; set; }
        [DisplayName("Description")]
        public string UOMDescription { get; set; }
    }
}
