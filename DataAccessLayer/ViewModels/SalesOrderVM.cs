using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class SalesOrderVM
    {
        public int SalesOrderId { get; set; }


        [DisplayName("Product")]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }


        [DisplayName("Customer")]
        public int? CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }


        public int Quantity { get; set; }

        [DisplayName("Unit Price")]
        public decimal SalePrice { get; set; }

        [DisplayName("Sale Date")]
        public DateTime SaleDate { get; set; }

        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }
    }
}
