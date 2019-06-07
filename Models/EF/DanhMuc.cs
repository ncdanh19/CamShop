namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        public int danhMucID { get; set; }

        [StringLength(250)]
        public string tenDanhMuc { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        public int? groupID { get; set; }

        [StringLength(10)]
        public string Target { get; set; }

        public bool? trangThai { get; set; }

        public virtual NhomDanhMuc NhomDanhMuc { get; set; }
    }
}
