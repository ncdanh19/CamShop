namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DanhGias = new HashSet<DanhGia>();
            HoaDons = new HashSet<HoaDon>();
        }

        public int khachHangID { get; set; }

        [StringLength(50)]
        public string hoTen { get; set; }

        [StringLength(50)]
        public string eMail { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [StringLength(11)]
        public string soDienThoai { get; set; }

        [StringLength(50)]
        public string passWord { get; set; }

        [StringLength(50)]
        public string confirmPassword { get; set; }

        public bool? trangThai { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
