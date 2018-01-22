using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Model
{
    [Table("ORDER")]

    public class ORDER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idOrd { get; set; }
        [Display(Name = "Đơn đặt hàng")]
        public string nameOrd { get; set; }
        [Display(Name = "Khách hàng")]
        public virtual CUSTOMER CUSTOMER { get; set; }
        [Display(Name = "Chi tiết")]
        public string descriptionOrd { get; set; }
        [Display(Name = "Ngày")]
        public DateTime dateOrded { get; set; }
        [Display(Name = "Đơn giá")]
        public int? totalPrice { get; set; }
        public virtual ICollection<ORDERDETAILS> ORDERDETAILS { get; set; }
    }
}
