﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [DisplayName("Customer Code")]
        [StringLength(10)]
        public string CustomerCode { get; set; }
        [Required]
        [DisplayName("Contact Info")]
        [StringLength(25)]
        public string ContactInfo { get; set; }

        /// For 1=Active,  0=InActive
        [Required]
        public int IsActive { get; set; }
    }
}