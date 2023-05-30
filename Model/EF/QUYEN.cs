namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUYEN()
        {
            TAIKHOANs = new HashSet<TAIKHOAN>();
        }

        [Key]
        public int MaQuyen { get; set; }

        [StringLength(50)]
        public string TenQuyen { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }
    }
}
