namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIET_HOADON = new HashSet<CHITIET_HOADON>();
        }

        [Key]
        public int MaHD { get; set; }

        public int MaNV { get; set; }

        public DateTime? ThoiGian { get; set; }

        public int? MaKM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIET_HOADON> CHITIET_HOADON { get; set; }

        public virtual KHUYENMAI KHUYENMAI { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
