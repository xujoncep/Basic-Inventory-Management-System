using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class PurchaseReportVM
    {
        public List<PurchaseOrderVM> PurchaseOrderList { get; set; }

        [DisplayName("Product")]
        public int? ProductId { get; set; }

        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Total Quantity")]
        public int TotalQuantity { get; set; }

        [DisplayName("Grand Total Price")]
        public decimal GrandTotalPrice { get; set; }

        public IEnumerable<SelectListItem> ProductDDL { get; set; }
    }
}
