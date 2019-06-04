namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string passWord { get; set; }

        [Required]
        [StringLength(50)]
        public string hoTen { get; set; }

        [Required]
        [StringLength(50)]
        public string eMail { get; set; }

        [Required]
        [StringLength(50)]
        public string diaChi { get; set; }

        [Required]
        [StringLength(11)]
        public string soDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
