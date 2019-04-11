namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string tenSlide { get; set; }

        [StringLength(500)]
        public string hinhAnh { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        public bool? trangThai { get; set; }
    }
}
