namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CamShopDbContext : DbContext
    {
        public CamShopDbContext()
            : base("name=CamShopDbContext")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<GiaoHang> GiaoHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<NhomDanhMuc> NhomDanhMucs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<ThuongHieu> ThuongHieux { get; set; }
        public virtual DbSet<TraHang> TraHangs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.image)
                .IsFixedLength();

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<GiaoHang>()
                .Property(e => e.donViGiaoHang)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasOptional(e => e.ThanhToan)
                .WithRequired(e => e.HoaDon);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiHang1)
                .HasForeignKey(e => e.loaiHang);

            modelBuilder.Entity<NhomDanhMuc>()
                .HasMany(e => e.DanhMucs)
                .WithOptional(e => e.NhomDanhMuc)
                .HasForeignKey(e => e.groupID);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.SanPhams)
                .Map(m => m.ToTable("SanPhamTag").MapLeftKey("sanPhamID").MapRightKey("tagID"));

            modelBuilder.Entity<Tag>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<ThuongHieu>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.ThuongHieu1)
                .HasForeignKey(e => e.thuongHieu);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.eMail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.soDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.maKhach);
        }

    }
}
