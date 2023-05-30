namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("MONAN")]
    public partial class MONAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONAN()
        {
            Anh = "~/Content/img/add.jpg";
            CHITIET_HOADON = new HashSet<CHITIET_HOADON>();
        }

        [Key]
        public int MaMonAn { get; set; }

        [Display(Name = "Tên món ăn")]
        [StringLength(50)]
        public string TenMonAn { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "text")]
        public string MoTa { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Hình ảnh")]
        [StringLength(50)]
        public string Anh { get; set; }

        public int MaLoaiMonAn { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0}")]        
        
        [Display(Name = "Giá")]
        public double? Gia { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIET_HOADON> CHITIET_HOADON { get; set; }

        public virtual LOAIMONAN LOAIMONAN { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
