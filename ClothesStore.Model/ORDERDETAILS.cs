using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesStore.Model
{
    [Table("ORDERDETAILS")]
    public class ORDERDETAILS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idOrdDe { get; set; }
        [Display(Name = "Sản phẩm")]
        public PRODUCT PRODUCT { get; set; }
        [Display(Name = "Giá")]
        public int unitPriceOrdDe { get; set; }
        [Display(Name = "Đơn giá")]
        public ORDER ORDER { get; set; }
    }
}