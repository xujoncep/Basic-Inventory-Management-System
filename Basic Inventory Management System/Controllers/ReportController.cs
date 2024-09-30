using ClosedXML.Excel;
using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.IService;

namespace Basic_Inventory_Management_System.Controllers
{
    public class ReportController : Controller
    {
        
        
            private readonly IReportService _reportService;
            private readonly IDDLService _ddlService;

            public ReportController(IReportService reportService, IDDLService ddlService)
            {
                _reportService = reportService;
                _ddlService = ddlService;
            }

            public async Task<IActionResult> Inventory()
            {
                InventoryReportVM model = new InventoryReportVM();
                model.CategoryDDL = await _ddlService.GetCategoryDDL();
                ViewBag.ShowResult = false;
                return View(model);
            }


            [HttpPost]
            public async Task<IActionResult> Inventory(InventoryReportVM model)
            {
                var data = await _reportService.GetInventoryReport(model);
                data.CategoryDDL = await _ddlService.GetCategoryDDL();
                ViewBag.ShowResult = true;
                return View(data);
            }


            public async Task<FileResult> DownloadInventory(InventoryReportVM model)
            {
                var data = await _reportService.GetInventoryReport(model);

                using (var wbook = new XLWorkbook())
                {
                    var ws = wbook.Worksheets.Add("Inventory Report");

                    //header
                    List<(string Title, int? Width, bool Align_Center, bool Align_Right)> headers =
                        new List<(string Title, int? Width, bool Align_Center, bool Align_Right)>()
                        {
                        (Title: "Product Name", Width: 15, Align_Center: false, Align_Right: false),
                        (Title: "Category Name", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Base Price", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Quantity In Stock", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Total Price", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "IsActive", Width: 15, Align_Center: false, Align_Right: false)
                        };

                    int row = 1, col = 1;

                    for (int i = 0; i < headers.Count; i++)
                    {
                        ws.Cell(row, col).Value = headers[i].Title;

                        if (headers[i].Width != null)
                            ws.Column(col).Width = (int)headers[i].Width;

                        if (headers[i].Align_Center)
                            ws.Column(col).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        else if (headers[i].Align_Right)
                            ws.Column(col).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                        col++;
                    }
                    ws.Row(row).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    ws.Row(row).Style.Font.Bold = true;

                    row++;

                    foreach (var item in model.ProductList)
                    {
                        col = 1;
                        ws.Cell(row, col++).Value = item.ProductName;
                        ws.Cell(row, col++).Value = item.CategoryName;
                        ws.Cell(row, col++).Value = item.BasePrice;
                        ws.Cell(row, col++).Value = item.QuantityInStock;
                        ws.Cell(row, col++).Value = item.TotalPrice;
                        ws.Cell(row, col++).Value = item.IsActive == 1 ? "Yes" : "No";

                        row++;
                    }
                    ws.Columns().AdjustToContents();

                    using (var stream = new System.IO.MemoryStream())
                    {
                        wbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Inventory_Report_" + System.DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt") + ".xlsx");
                    }
                }
            }

        public async Task<IActionResult> Purchase()
        {
            PurchaseReportVM model = new PurchaseReportVM();
            model.ProductDDL = await _ddlService.GetProductDDL();
            ViewBag.ShowResult = false;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Purchase(PurchaseReportVM model)
        {
            var data = await _reportService.GetPurchaseReport(model);
            data.ProductDDL = await _ddlService.GetProductDDL();
            ViewBag.ShowResult = true;
            return View(data);
        }



        public async Task<FileResult> DownloadPurchase(PurchaseReportVM model)
        {
            var data = await _reportService.GetPurchaseReport(model);

            using (var wbook = new XLWorkbook())
            {
                var ws = wbook.Worksheets.Add("Pruchase Orders Report");

                //header
                List<(string Title, int? Width, bool Align_Center, bool Align_Right)> headers =
                    new List<(string Title, int? Width, bool Align_Center, bool Align_Right)>()
                    {
                        (Title: "Purchase Date", Width: 15, Align_Center: false, Align_Right: false),
                        (Title: "Product Name", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Supplier Name", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Unit Price", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Quantity", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Total Price", Width: 25, Align_Center: false, Align_Right: false),
                    };

                int row = 1, col = 1;

                for (int i = 0; i < headers.Count; i++)
                {
                    ws.Cell(row, col).Value = headers[i].Title;

                    if (headers[i].Width != null)
                        ws.Column(col).Width = (int)headers[i].Width;

                    if (headers[i].Align_Center)
                        ws.Column(col).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    else if (headers[i].Align_Right)
                        ws.Column(col).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                    col++;
                }
                ws.Row(row).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Row(row).Style.Font.Bold = true;

                row++;

                foreach (var item in model.PurchaseOrderList)
                {
                    col = 1;
                    ws.Cell(row, col++).Value = item.PurchaseDate.ToString("dd/MMM/yyyy");
                    ws.Cell(row, col++).Value = item.ProductName;
                    ws.Cell(row, col++).Value = item.SupplierName;
                    ws.Cell(row, col++).Value = item.PurchasePrice;
                    ws.Cell(row, col++).Value = item.Quantity;
                    ws.Cell(row, col++).Value = item.TotalPrice;

                    row++;
                }
                ws.Columns().AdjustToContents();

                using (var stream = new System.IO.MemoryStream())
                {
                    wbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Purchase_Orders_Report_" + System.DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt") + ".xlsx");
                }
            }
        }



        public async Task<IActionResult> Sales()
        {
            SalesReportVM model = new SalesReportVM();
            model.ProductDDL = await _ddlService.GetProductDDL();
            ViewBag.ShowResult = false;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Sales(SalesReportVM model)
        {
            var data = await _reportService.GetSalesReport(model);
            data.ProductDDL = await _ddlService.GetProductDDL();
            ViewBag.ShowResult = true;
            return View(data);
        }



        public async Task<FileResult> DownloadSales(SalesReportVM model)
        {
            var data = await _reportService.GetSalesReport(model);

            using (var wbook = new XLWorkbook())
            {
                var ws = wbook.Worksheets.Add("Sales Orders Report");

                //header
                List<(string Title, int? Width, bool Align_Center, bool Align_Right)> headers =
                    new List<(string Title, int? Width, bool Align_Center, bool Align_Right)>()
                    {
                        (Title: "Sale Date", Width: 15, Align_Center: false, Align_Right: false),
                        (Title: "Product Name", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Customer Name", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Unit Price", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Quantity", Width: 25, Align_Center: false, Align_Right: false),
                        (Title: "Total Price", Width: 25, Align_Center: false, Align_Right: false),
                    };

                int row = 1, col = 1;

                for (int i = 0; i < headers.Count; i++)
                {
                    ws.Cell(row, col).Value = headers[i].Title;

                    if (headers[i].Width != null)
                        ws.Column(col).Width = (int)headers[i].Width;

                    if (headers[i].Align_Center)
                        ws.Column(col).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    else if (headers[i].Align_Right)
                        ws.Column(col).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                    col++;
                }
                ws.Row(row).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Row(row).Style.Font.Bold = true;

                row++;

                foreach (var item in model.SalesOrderList)
                {
                    col = 1;
                    ws.Cell(row, col++).Value = item.SaleDate.ToString("dd/MMM/yyyy");
                    ws.Cell(row, col++).Value = item.ProductName;
                    ws.Cell(row, col++).Value = item.CustomerName;
                    ws.Cell(row, col++).Value = item.SalePrice;
                    ws.Cell(row, col++).Value = item.Quantity;
                    ws.Cell(row, col++).Value = item.TotalPrice;

                    row++;
                }
                ws.Columns().AdjustToContents();

                using (var stream = new System.IO.MemoryStream())
                {
                    wbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sales_Orders_Report_" + System.DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt") + ".xlsx");
                }
            }
        }

    }
 }
