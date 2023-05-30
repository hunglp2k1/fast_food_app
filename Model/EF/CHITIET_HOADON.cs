namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHITIET_HOADON
    {
        [Key]
        public int MaCTHD { get; set; }

        [Required]
        public int MaHD { get; set; }

        public int? SoLuong { get; set; }

        public int MaMonAn { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual MONAN MONAN { get; set; }
    }
}
