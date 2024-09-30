using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class InventoryReportVM
    {
        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        public IEnumerable<SelectListItem> CategoryDDL { get; set; }


        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Total Quantity")]
        public int TotalQuantity { get; set; }

        [DisplayName("Grand Total Price")]
        public decimal GrandTotalPrice { get; set; }

        public List<Product> ProductList { get; set; }
    }
}
