namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTK { get; set; }

        public int MaQuyen { get; set; }

        [StringLength(20)]
        public string TenTaiKhoan { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        public bool? TrangThai { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual QUYEN QUYEN { get; set; }
    }
}
