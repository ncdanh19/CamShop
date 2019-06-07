namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraHang")]
    public partial class TraHang
    {
        [Key]
        public int phieuTraHangID { get; set; }

        public int? hoaDonID { get; set; }

        public DateTime? ngayTra { get; set; }

        [StringLength(500)]
        public string lyDo { get; set; }

        public int? chitietHDID { get; set; }

        public virtual ChiTietHoaDon ChiTietHoaDon { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
