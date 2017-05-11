using System.ComponentModel.DataAnnotations;

namespace StationLinerDataEntities.Models
{
    public class BusinessRoles
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public long CreatedBy { get; set; }
    }
}