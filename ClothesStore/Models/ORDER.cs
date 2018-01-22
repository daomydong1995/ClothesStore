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
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            this.ORDERDETAILS = new HashSet<ORDERDETAILS>();
        }

    
        public int idOrd { get; set; }
        [Display(Name = "Tên ")]
        public string nameOrd { get; set; }
        [Display(Name = "Yêu cầu")]
        public string descriptionOrd { get; set; }
        [Display(Name = "Ngày")]
        public System.DateTime dateOrded { get; set; }
        [Display(Name = "Tổng")]
        public Nullable<int> totalPrice { get; set; }
        [Display(Name = "Tên khách hàng")]
        public Nullable<int> CUSTOMER_idCus { get; set; }
        [Display(Name = "Tên khách hàng")]
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<ORDERDETAILS> ORDERDETAILS { get; set; }
    }
}
