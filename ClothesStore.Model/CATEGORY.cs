using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesStore.Model
{
    [Table("CATEGORY")]

    public class CATEGORY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idCate { get; set; }
        [Display(Name = "Thể loại")]
        public string nameCate { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string coverCate { get; set; }
        [Display(Name = "Icon")]
        public string iconCate { get; set; }
        public virtual ICollection<PRODUCT> PRODUCT { get; set; }

    }
}