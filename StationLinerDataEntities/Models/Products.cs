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
    public  class ProductProperty
    {
        public long ProductProperty_id { get; set; }
        public string ProductProperty_Name { get; set; }
        public string ProductProperty_Description { get; set; }
        public Nullable<System.DateTime> ProductProperty_DateCreated { get; set; }
        public Nullable<bool> ProductProperty_IsActive { get; set; }
        public Nullable<bool> ProductProperty_IsDeleted { get; set; }
        public Nullable<bool> IsAddApproved { get; set; }
        public Nullable<bool> IsDelApproved { get; set; }
        public Nullable<bool> IsEditApproved { get; set; }
        public Nullable<int> IsDeletedFlag { get; set; }
        public Nullable<bool> IsbeingDeleted { get; set; }
        public Nullable<bool> IsbeingEdited { get; set; }
        public Nullable<bool> IsbeingAdded { get; set; }
        public bool IsSelected { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
    }

    public class ProductType
    {
        public long ProductType_id { get; set; }
        public string ProductType_Name { get; set; }
        public string ProductType_Description { get; set; }
        public Nullable<bool> ProductType_IsActive { get; set; }
        public Nullable<bool> ProductType_IsDeleted { get; set; }
        public Nullable<System.DateTime> ProductType_DateCreated { get; set; }
        public Nullable<bool> IsAddApproved { get; set; }
        public Nullable<bool> IsDelApproved { get; set; }
        public Nullable<bool> IsEditApproved { get; set; }
        public Nullable<int> ProductType_IsDeletedFlag { get; set; }
        public Nullable<bool> ProductType_IsbeingDeleted { get; set; }
        public Nullable<bool> ProductType_IsbeingEdited { get; set; }
        public Nullable<bool> ProductType_IsbeingAdded { get; set; }
        public Nullable<bool> IsAddApprovedFirstApvr { get; set; }
        public Nullable<bool> IsAddApprovedSecondApvr { get; set; }
        public Nullable<bool> IsDelApprovedFirstApvr { get; set; }
        public Nullable<bool> IsDelApprovedSecondApvr { get; set; }
        public Nullable<bool> IsEditApprovedFirstApvr { get; set; }
        public Nullable<bool> IsEditApprovedSecondApvr { get; set; }
        public string ReasonEditFirstApvr { get; set; }
        public string ReasonEditSecondApvr { get; set; }
        public string ReasonDelFirstApvr { get; set; }
        public string ReasonDelSecondApvr { get; set; }
        public string ReasonAddFirstApvr { get; set; }
        public string ReasonAddSecondApvr { get; set; }
        public string CF1 { get; set; }
        public string CF2 { get; set; }
        public string CF3 { get; set; }
        public string CF4 { get; set; }
        public string CF5 { get; set; }
        public string CF6 { get; set; }
        public string CF7 { get; set; }
        public string CF8 { get; set; }
        public string CF9 { get; set; }
        public string CF10 { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
    }
    
    
    public class Product
    {
        [Key]
        public long Product_id { get; set; }
        [Required]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        [DisplayName("Product Name"),Required]
        public string Product_Name { get; set; }
       
        [DisplayName("Product Description")]
        public string Product_Description { get; set; }
        [ForeignKey("ProdCategory"), DisplayName("Category")]
        public long ProductCategoryId { get; set; }
        [DisplayName("Refernce Code")]
        public string ProductRefCode { get; set; }

        [Required]
        public bool Sellable { get; set; }
        
        [DisplayName("Unit Of Measure")]
        [ForeignKey("UnitOfMeasure")]
        public long? Uom { get; set; }

//        [DefaultValue(DateTime)]
        public DateTime? CreatedAt { get; set; }

        public virtual UOM UnitOfMeasure { get; set; }
        public virtual ProductCategory ProdCategory { get; set; }
    }

    public class ProductCategory
    {
        [Key]
        public long Id { get; set; }

        [DisplayName("Parent Category")]
        [ForeignKey("ProductCategoryId")]
        public long? ParentCategory { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public virtual ProductCategory ProductCategoryId { get; set; }
    }
}
