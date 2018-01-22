using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Model
{
    [Table("PRODUCT")]
    public class PRODUCT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idPro { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string namePro { get; set; }
        [Display(Name = "Chi tiết")]
        public string detailsPro { get; set; }
        [Display(Name = "Thể loại")]
        public virtual CATEGORY CATEGORY { get; set; }
        [Display(Name = "Đối tác")]
        public virtual PARTNER PARTNER { get; set; }
        [Display(Name = "Số lượng")]
        public int? amountPro { get; set; }
        [Display(Name = "Ảnh")]
        public string coverPro { get; set; }
        [Display(Name = "Giá")]
        public int? pricePro { get; set; }
        [Display(Name = "Giảm giá")]
        public int? percentSalePro { get; set; }
        [Display(Name = "Sản phẩm hot")]
        public bool hotProduct { get; set; }
        public virtual ICollection<ORDERDETAILS> ORDERDETAILS { get; set; }

    }
}
