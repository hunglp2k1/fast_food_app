namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HinhAnh = "~/Content/img/add.jpg";
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        public int MaNV { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ & Tên")]
        public string HoTenNV { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(20)]
        public string SDT { get; set; }

        [Display(Name = "Ngày Sinh")]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Giới tính")]
        public bool? GioiTinh { get; set; }

        public int MaCV { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
