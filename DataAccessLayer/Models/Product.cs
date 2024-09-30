using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        
        [Required]
        [StringLength(50)]
        [DisplayName("Product Name")]
        [Remote("IsProductExist", "Product", AdditionalFields = "ProductId,ProductName", HttpMethod = "POST", ErrorMessage = "Product Name Already Exist")]
        public string ProductName { get; set; }
        
        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
       
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Base Price")]
        public decimal BasePrice { get; set; }
        
        [Required]
        [DisplayName("Quantity In Stock")]
        public int QuantityInStock { get; set; }

        /// For 1=Active,  0=InActive
        [Required]
        public int IsActive { get; set; }
        
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual List<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
        public virtual List<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();

        [NotMapped]
        public IEnumerable<SelectListItem> CategoryDDL { get; set; }

        [NotMapped]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
