using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Model
{
    public partial class ClothesStoreDbContext:DbContext
    {
        public ClothesStoreDbContext() : base("name=ClothesStore")
        {
            
        }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<PARTNER> PARTNER { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<ORDERDETAILS> ORDERDETAILS { get; set; }
        public virtual DbSet<ADMIN> ADMIN { get; set; }
    }
}
