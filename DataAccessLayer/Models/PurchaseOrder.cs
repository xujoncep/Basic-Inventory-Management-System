using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseOrderId { get; set; }


        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }


        [DisplayName("Supplier")]
        public int? SupplierId { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum Quantity is 1")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Unit Price")]
        [Range(0.01, 999999999999999.99)]
        public decimal PurchasePrice { get; set; }


        [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.Now.Date;


        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> ProductDDL { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> SupplierDDL { get; set; }
    }
}
