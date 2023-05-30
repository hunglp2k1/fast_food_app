namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIMONAN")]
    public partial class LOAIMONAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIMONAN()
        {
            MONANs = new HashSet<MONAN>();
        }

        [Key]
        public int MaLoaiMonAn { get; set; }

        [Display(Name = "Loại món ăn")]
        [StringLength(50)]
        public string TenLoaiMonAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MONAN> MONANs { get; set; }
    }
}
