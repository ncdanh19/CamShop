namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPhamTag")]
    public partial class SanPhamTag
    {
        public int ID { get; set; }

        public int? sanPhamID { get; set; }

        public int? tagID { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
