using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesStore.Model
{
    [Table("PARTNER")]
    public class PARTNER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idPart { get; set; }
        [Display(Name = "Tên đối tác")]
        public string namePart { get; set; }
        [Display(Name = "Ảnh")]
        public  string coverPart { get; set; }
        [Display(Name = "Liên kết")]
        public string linkPart { get; set; }
        public virtual ICollection<PRODUCT> PRODUCT { get; set; }
    }
}