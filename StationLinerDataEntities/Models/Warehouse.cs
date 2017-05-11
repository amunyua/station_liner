using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLinerDataEntities.Models
{
    public class WarehouseType
    {
        public long Id { get; set; }
        [Required]
        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
    public class Warehouse
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Warehouse Name"), Required]
        public string WarehouseName { get; set; }
        [DisplayName("Warehohuse location")]
        public string WarehouseLocation { get; set; }
        [DisplayName("Warehouse Type")]
        [ForeignKey("WarehouseTypeId")]
        public long WarehouseType { get; set; }
        [DisplayName("Maximum Capacity")]
        public double? MaximumCapacity { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual WarehouseType WarehouseTypeId { get; set; }
     }

    public class WarehouseProduct
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Item ReoderLevel")]
        public double ReorderLevel { get; set; }
        [DisplayName("Available Stock")]
        public double AvailableStock { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("Warehouses")]
        public long WarehouseId { get; set; }
        [ForeignKey("ProdId")]
        public long ProductId { get; set; }

        public virtual Product ProdId { get; set; }
        public virtual Warehouse Warehouses { get; set; }
    }

    public class TankDetails
    {
        public long Id { get; set; }

        public long WarehouseId { get; set; }


    }
}
