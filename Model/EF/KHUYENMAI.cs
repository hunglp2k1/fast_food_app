namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUYENMAI")]
    public partial class KHUYENMAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHUYENMAI()
        {
            NgayKetThucKM = DateTime.Now;
            NgayKetThucKM = DateTime.Now;
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        public int MaKM { get; set; }

        [StringLength(50)]
        public string TenKM { get; set; }

        [Column(TypeName = "text")]
        public string MoTa { get; set; }

        public double? TiLeGiamGia { get; set; }

        public DateTime? NgayBatDauKM { get; set; }

        public DateTime? NgayKetThucKM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
