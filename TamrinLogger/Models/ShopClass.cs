using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TamrinLogger.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Column(TypeName="image")]//[Column(TypeName ="image")]
        public byte[] Image { get; set; }

        [DefaultValue("0")]
        public bool? Delete { get; set; }

       //[DefaultValue("CONVERT(datetime,GetDate())")]
        public DateTime? CreateAt { get; set; }


        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
  


    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public int Title { get; set; }
        public string Descreption { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
