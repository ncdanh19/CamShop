namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoHang")]
    public partial class GiaoHang
    {
        public int giaoHangID { get; set; }

        public int? hoaDonID { get; set; }

        [StringLength(50)]
        public string donViGiaoHang { get; set; }

        public DateTime? ngayGiaoHang { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
