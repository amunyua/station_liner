using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLinerDataEntities.Models
{
    public class CRUDAction
    {
        [Key]
        public long Id { get; set; }

        public string ActionCode { get; set; }

        public string Description { get; set; }
    }
}
