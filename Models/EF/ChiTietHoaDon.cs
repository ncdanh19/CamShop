namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietHoaDon()
        {
            TraHangs = new HashSet<TraHang>();
        }

        [Key]
        public int chitietID { get; set; }

        public int? hoaDonID { get; set; }

        public int? sanPhamID { get; set; }

        public short? soLuong { get; set; }

        public double? donGia { get; set; }

        public double? giaKhuyenMai { get; set; }

        public double? thanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraHang> TraHangs { get; set; }
    }
}
