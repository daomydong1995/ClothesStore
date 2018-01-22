using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Model
{
    [Table("CUSTOMER")]

    public class CUSTOMER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idCus { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string nameCus { get; set; }
        [Display(Name = "Email")]
        public string emailCus { get; set; }
        [Display(Name = "Mật khẩu")]
        public string passCus { get; set; }
        [Display(Name = "Địa chỉ")]
        public string AdressCus { get; set; }
        [Display(Name = "Điện thoại")]
        public string phoneCus { get; set; }
        [Display(Name = "Ảnh")]
        public string avaCus { get; set; }
        public virtual ICollection<ORDER> ORDER { get; set; }

    }
}
