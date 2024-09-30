using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class TotalItemVM
    {
        [DisplayName("Total Category")]
        public int TotalCategory { get; set; }

        [DisplayName("Total Supplier")]
        public int TotalSupplier { get; set; }

        [DisplayName("Total Customer")]
        public int TotalCustomer { get; set; }

        [DisplayName("Total Product Type")]
        public int TotalProduct { get; set; }

        [DisplayName("Total Purchase Order")]
        public int TotalPurchaseOrder { get; set; }

        [DisplayName("Total Sales Order")]
        public int TotalSalesOrder { get; set; }
    }
}
