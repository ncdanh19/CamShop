namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            Tags = new HashSet<Tag>();
        }

        public int sanPhamID { get; set; }

        public int? loaiHang { get; set; }

        public int? thuongHieu { get; set; }

        [StringLength(100)]
        public string tenSanPham { get; set; }

        public double? donGia { get; set; }

        [Column(TypeName = "ntext")]
        public string moTa { get; set; }

        [StringLength(500)]
        public string hinhAnh { get; set; }

        [Column(TypeName = "xml")]
        public string nhieuHinhAnh { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public DateTime? Hot { get; set; }

        public int? soLuong { get; set; }

        [StringLength(500)]
        public string MetaKeyword { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiHang LoaiHang1 { get; set; }

        public virtual ThuongHieu ThuongHieu1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
