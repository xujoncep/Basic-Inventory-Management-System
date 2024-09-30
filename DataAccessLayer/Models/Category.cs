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
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [Remote("IsCategoryExist", "Category", AdditionalFields = "CategoryId,CategoryName", HttpMethod = "POST", ErrorMessage = "Category Already Exist")]
        [StringLength(50)]
        public string CategoryName { get; set; }

   
        /// For 1=Active,  0=InActive
        [Required]
        public int IsActive { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
