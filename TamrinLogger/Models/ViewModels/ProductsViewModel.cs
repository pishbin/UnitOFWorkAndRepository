using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TamrinLogger.Models.ViewModels
{
    public class ProductsCreateViewModel
    {
        [DisplayName("کدمحصول")]
        public int ProductID { get; set; }
        [Required]
        [DisplayName("نام محصول")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("قیمت محصول")]
        public double Price { get; set; }

        [Required]
        [DisplayName("تعداد ")]
        public int Count { get; set; }

        [Column(TypeName = "image")]//[Column(TypeName ="image")]
        [DisplayName("تصویر محصول")]
        public byte[] Image { get; set; }

        [DefaultValue("0")]
        public bool? Delete { get; set; }

        [DefaultValue("CONVERT(datetime,GetDate())")]
        [DisplayName("تاریخ ایجاد")]
        public DateTime? CreateAt { get; set; }

        [DisplayName("نام دسته بندی ")]
        public int CategoryID { get; set; }

    }
}
