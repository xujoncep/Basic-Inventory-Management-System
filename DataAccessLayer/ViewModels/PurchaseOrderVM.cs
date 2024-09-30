using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class PurchaseOrderVM
    {
        public int PurchaseOrderId { get; set; }


        [DisplayName("Product")]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }


        [DisplayName("Supplier")]
        public int? SupplierId { get; set; }

        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }


        public int Quantity { get; set; }

        [DisplayName("Unit Price")]
        public decimal PurchasePrice { get; set; }

        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }
    }
}
