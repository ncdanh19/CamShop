namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advertisement")]
    public partial class Advertisement
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string tenQuangcao { get; set; }

        [StringLength(500)]
        public string hinhAnh { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        [StringLength(500)]
        public string ghiChu { get; set; }

        public bool? trangThai { get; set; }
    }
}
