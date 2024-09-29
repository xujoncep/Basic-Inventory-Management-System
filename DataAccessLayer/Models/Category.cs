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
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

   
        /// For 1=Active,  0=InActive
        [Required]
        public int IsActive { get; set; }
    }
}
