using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Model
{
    [Table("ADMIN")]
    public class ADMIN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("userid")]
        public int? userid { get; set; }
        [Display(Name ="Tên đăng nhập")]
        public string username { get; set; }
        [Display(Name = "Mật khẩu")]
        public string password { get; set; }
        [Display(Name = "Họ tên")]
        public string fullname { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string avatar { get; set; }
        [Display(Name = "Admin")]
        public int isAdmin { get; set; }
        [Display(Name = "Quyền")]
        public int allowed { get; set; }
    }
}
