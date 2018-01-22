﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClothesStore.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    [Serializable]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.ORDERDETAILS = new HashSet<ORDERDETAILS>();
        }
    
        public int idPro { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string namePro { get; set; }
        [Display(Name = "Chi tiết")]
        public string detailsPro { get; set; }
        [Display(Name = "Số lượng")]
        public int? amountPro { get; set; }
        [Display(Name = "Ảnh")]
        public string coverPro { get; set; }
        [Display(Name = "Giá")]
        public int? pricePro { get; set; }
        [Display(Name = "Giảm giá")]
        public int? percentSalePro { get; set; }
        [Display(Name = "HOT")]
        public bool hotProduct { get; set; }
        [Display(Name = "Loại")]
        public int? CATEGORY_idCate { get; set; }
        [Display(Name = "Đối tác")]
        public int? PARTNER_idPart { get; set; }
       
        public virtual CATEGORY CATEGORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore] 
        [IgnoreDataMember]
        public virtual ICollection<ORDERDETAILS> ORDERDETAILS { get; set; }
        public virtual PARTNER PARTNER { get; set; }
    }
}
