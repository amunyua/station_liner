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
    public class Supplier
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Postal Address")]
        public string PostalAddress { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        public string City { get; set; }
        [DisplayName("Contact One")]
        [Required]
        public string Contact1 { get; set; }

        [DisplayName("Contact Two")]
        public string Contact2 { get; set; }
        
        public string Email { get; set; }
        [DisplayName("Pin Number")]
        public string PinNumber { get; set; }
        [DisplayName("Contact person")]
        public string ContactPersonName { get; set; }
        [DisplayName("Credit Limit")]
        public double CreditLimit { get; set; }
    }

    public class SupplierProduct
    {
        [Key]
        public long Id { get; set; }

        public double Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("Suppliers")]
        public long SupplierId { get; set; }
        [ForeignKey("ProdId")]
        public long ProductId { get; set; }

        public virtual Product ProdId { get; set; }
        public virtual Supplier Suppliers{ get; set; }
    }

    public class SupplierDriver
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Name")]
        public string DriverName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [ForeignKey("Suppliers")]
        public long SupplierId { get; set; }

        public virtual Supplier Suppliers { get; set; }
    }

    public class SupplierVehicle
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }
        [DisplayName("Maximum Capacity")]
        public string MaximumCapacity { get; set; }
        [ForeignKey("Suppliers")]
        public long SupplierId { get; set; }
        public virtual Supplier Suppliers { get; set; }
    }
}
