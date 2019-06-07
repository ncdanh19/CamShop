namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        public int ID { get; set; }

        public int? khachHangID { get; set; }

        public int? sanPhamID { get; set; }

        public int? Diem { get; set; }

        [Column(TypeName = "ntext")]
        public string binhLuan { get; set; }

        [StringLength(500)]
        public string hinhAnh { get; set; }

        public DateTime? NgayDanhGia { get; set; }

        [Column(TypeName = "xml")]
        public string nhieuHinhAnh { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
