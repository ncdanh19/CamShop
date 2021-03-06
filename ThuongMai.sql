USE [ThuongMai]
GO
ALTER TABLE [dbo].[TraHang] DROP CONSTRAINT [FK__TraHang__hoaDonI__59FA5E80]
GO
ALTER TABLE [dbo].[ThanhToan] DROP CONSTRAINT [FK__ThanhToan__hoaDo__59063A47]
GO
ALTER TABLE [dbo].[SanPhamTag] DROP CONSTRAINT [FK__SanPhamTa__tagID__5812160E]
GO
ALTER TABLE [dbo].[SanPhamTag] DROP CONSTRAINT [FK__SanPhamTa__sanPh__571DF1D5]
GO
ALTER TABLE [dbo].[SanPham] DROP CONSTRAINT [FK__SanPham__thuongH__5629CD9C]
GO
ALTER TABLE [dbo].[SanPham] DROP CONSTRAINT [FK__SanPham__loaiHan__5535A963]
GO
ALTER TABLE [dbo].[HoaDon] DROP CONSTRAINT [FK__HoaDon__maKhach__5441852A]
GO
ALTER TABLE [dbo].[GiaoHang] DROP CONSTRAINT [FK__GiaoHang__hoaDon__534D60F1]
GO
ALTER TABLE [dbo].[DanhMuc] DROP CONSTRAINT [FK__DanhMuc__groupID__52593CB8]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] DROP CONSTRAINT [FK__ChiTietHo__sanPh__5165187F]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] DROP CONSTRAINT [FK__ChiTietHo__hoaDo__5070F446]
GO
ALTER TABLE [dbo].[SanPham] DROP CONSTRAINT [DF_SanPham_NgayTao]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[TraHang]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[TraHang]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[ThuongHieu]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[ThanhToan]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[Tag]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[Slide]
GO
/****** Object:  Table [dbo].[SanPhamTag]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[SanPhamTag]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[SanPham]
GO
/****** Object:  Table [dbo].[NhomDanhMuc]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[NhomDanhMuc]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[LoaiHang]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[HoaDon]
GO
/****** Object:  Table [dbo].[GiaoHang]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[GiaoHang]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[Footer]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[DanhMuc]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP TABLE [dbo].[ChiTietHoaDon]
GO
USE [master]
GO
/****** Object:  Database [ThuongMai]    Script Date: 4/4/2019 11:38:43 AM ******/
DROP DATABASE [ThuongMai]
GO
/****** Object:  Database [ThuongMai]    Script Date: 4/4/2019 11:38:43 AM ******/
CREATE DATABASE [ThuongMai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ThuongMai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ThuongMai.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ThuongMai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ThuongMai_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ThuongMai] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ThuongMai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ThuongMai] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ThuongMai] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ThuongMai] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ThuongMai] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ThuongMai] SET ARITHABORT OFF 
GO
ALTER DATABASE [ThuongMai] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ThuongMai] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ThuongMai] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ThuongMai] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ThuongMai] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ThuongMai] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ThuongMai] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ThuongMai] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ThuongMai] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ThuongMai] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ThuongMai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ThuongMai] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ThuongMai] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ThuongMai] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ThuongMai] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ThuongMai] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ThuongMai] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ThuongMai] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ThuongMai] SET  MULTI_USER 
GO
ALTER DATABASE [ThuongMai] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ThuongMai] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ThuongMai] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ThuongMai] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ThuongMai] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ThuongMai] SET QUERY_STORE = OFF
GO
USE [ThuongMai]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[chitietID] [int] IDENTITY(1,1) NOT NULL,
	[hoaDonID] [int] NULL,
	[sanPhamID] [int] NULL,
	[soLuong] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[chitietID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[danhMucID] [int] IDENTITY(1,1) NOT NULL,
	[tenDanhMuc] [nvarchar](250) NULL,
	[URL] [nvarchar](500) NULL,
	[groupID] [int] NULL,
	[Target] [varchar](10) NULL,
	[trangThai] [bit] NULL,
	[image] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[danhMucID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[ID] [nchar](10) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[trangThai] [bit] NULL,
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoHang]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoHang](
	[giaoHangID] [int] IDENTITY(1,1) NOT NULL,
	[hoaDonID] [int] NULL,
	[donViGiaoHang] [varchar](50) NULL,
	[ngayGiaoHang] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[giaoHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[hoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[maKhach] [int] NULL,
	[loaiHoaDon] [nvarchar](50) NULL,
	[trangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[hoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[loaiHangID] [int] IDENTITY(1,1) NOT NULL,
	[tenLoai] [nvarchar](50) NULL,
	[MetaTitle] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[loaiHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomDanhMuc]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomDanhMuc](
	[nhomID] [int] IDENTITY(1,1) NOT NULL,
	[tenNhom] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[nhomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[sanPhamID] [int] IDENTITY(1,1) NOT NULL,
	[loaiHang] [int] NULL,
	[thuongHieu] [int] NULL,
	[tenSanPham] [nvarchar](100) NULL,
	[donGia] [float] NULL,
	[moTa] [ntext] NULL,
	[hinhAnh] [nvarchar](500) NULL,
	[nhieuHinhAnh] [xml] NULL,
	[NgayTao] [datetime] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[Hot] [datetime] NULL,
	[soLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhamTag]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamTag](
	[sanPhamID] [int] NOT NULL,
	[tagID] [int] NOT NULL,
 CONSTRAINT [PK_SanPhamTag] PRIMARY KEY CLUSTERED 
(
	[sanPhamID] ASC,
	[tagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tenSlide] [nvarchar](50) NOT NULL,
	[hinhAnh] [nvarchar](500) NULL,
	[URL] [nvarchar](500) NULL,
	[trangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[tagID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[tagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[hoaDonID] [int] NOT NULL,
	[ngayThanhToan] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[hoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[thuongHieuID] [int] IDENTITY(1,1) NOT NULL,
	[tenThuongHieu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[thuongHieuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TraHang]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraHang](
	[phieuTraHangID] [int] IDENTITY(1,1) NOT NULL,
	[hoaDonID] [int] NULL,
	[ngayTra] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[phieuTraHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/4/2019 11:38:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[passWord] [varchar](50) NOT NULL,
	[hoTen] [nvarchar](50) NULL,
	[eMail] [varchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
	[soDienThoai] [char](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (1, N'Máy ảnh', N'/may-anh', 1, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (2, N'Ống kính', N'/ong-kinh', 1, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (3, N'Phụ kiện', N'/phu-kien', 1, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (4, NULL, N'/cart', 1, N'_self', 1, N'/Assets/client/images/cart.png                    ')
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (5, NULL, N'/login', 1, N'_blank', 1, N'/Assets/client/images/user.png                    ')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
INSERT [dbo].[Footer] ([ID], [Content], [trangThai]) VALUES (N'footer    ', N'<div class="container wrap">
            <div class="logo2">
                <a href="index.html"><img src="images/logo2.png" alt="" /></a>
            </div>
            <div class="ftr-menu">
                <ul>
                    <li><a href="#">Giới thiệu</a></li>
                    <li><a href="#">Liên hệ</a></li>
                </ul>
            </div>
            <div class="clearfix"></div>
        </div>', 1)
SET IDENTITY_INSERT [dbo].[LoaiHang] ON 

INSERT [dbo].[LoaiHang] ([loaiHangID], [tenLoai], [MetaTitle]) VALUES (1, N'Máy ảnh', N'may-anh')
SET IDENTITY_INSERT [dbo].[LoaiHang] OFF
SET IDENTITY_INSERT [dbo].[NhomDanhMuc] ON 

INSERT [dbo].[NhomDanhMuc] ([nhomID], [tenNhom]) VALUES (1, N'Menu Chính')
SET IDENTITY_INSERT [dbo].[NhomDanhMuc] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (1, 1, 1, N'Sony', 100000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:14.283' AS DateTime), N'may-anh', NULL, 10)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (2, 1, 1, N'Cannon', 200000, N' Vivamus ante lorem, eleifend nec interdum non, ullamcorper et arcu. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.eleifend nec interdum non, ullamcorper et arcu. Class aptent taciti sociosqu ad litora torquent per conubia nostra. ', N'/Assets/client/images/cam2.jpg', NULL, CAST(N'2019-04-03T08:19:32.593' AS DateTime), N'may-anh', NULL, 100)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (3, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, 100)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (4, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, 100)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (5, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, NULL)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (6, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, NULL)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (7, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, NULL)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (8, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, NULL)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (9, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, NULL)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (10, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', NULL, NULL)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (11, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-04T10:24:31.663' AS DateTime), N'may-anh', NULL, NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (1, N'slide1', N'/Assets/client/images/b1.jpg', N'#', 1)
INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (2, N'slide2', N'/Assets/client/images/b2.jpg', N'#', 1)
INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (3, N'slide3', N'/Assets/client/images/b3.jpg', N'#', 1)
INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (4, N'slide4', N'/Assets/client/images/b4.jpg', N'#', 1)
SET IDENTITY_INSERT [dbo].[Slide] OFF
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

INSERT [dbo].[ThuongHieu] ([thuongHieuID], [tenThuongHieu]) VALUES (1, N'Cannon')
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [userName], [passWord], [hoTen], [eMail], [diaChi], [soDienThoai]) VALUES (1, N'admin', N'123', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([hoaDonID])
REFERENCES [dbo].[HoaDon] ([hoaDonID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([sanPhamID])
REFERENCES [dbo].[SanPham] ([sanPhamID])
GO
ALTER TABLE [dbo].[DanhMuc]  WITH CHECK ADD FOREIGN KEY([groupID])
REFERENCES [dbo].[NhomDanhMuc] ([nhomID])
GO
ALTER TABLE [dbo].[GiaoHang]  WITH CHECK ADD FOREIGN KEY([hoaDonID])
REFERENCES [dbo].[HoaDon] ([hoaDonID])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([maKhach])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([loaiHang])
REFERENCES [dbo].[LoaiHang] ([loaiHangID])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([thuongHieu])
REFERENCES [dbo].[ThuongHieu] ([thuongHieuID])
GO
ALTER TABLE [dbo].[SanPhamTag]  WITH CHECK ADD FOREIGN KEY([sanPhamID])
REFERENCES [dbo].[SanPham] ([sanPhamID])
GO
ALTER TABLE [dbo].[SanPhamTag]  WITH CHECK ADD FOREIGN KEY([tagID])
REFERENCES [dbo].[Tag] ([tagID])
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD FOREIGN KEY([hoaDonID])
REFERENCES [dbo].[HoaDon] ([hoaDonID])
GO
ALTER TABLE [dbo].[TraHang]  WITH CHECK ADD FOREIGN KEY([hoaDonID])
REFERENCES [dbo].[HoaDon] ([hoaDonID])
GO
USE [master]
GO
ALTER DATABASE [ThuongMai] SET  READ_WRITE 
GO
