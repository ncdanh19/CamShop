use master
create database TM
USE [TM]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 26/4/2019 7:16:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[chitietID] [int] IDENTITY(1,1) NOT NULL,
	[hoaDonID] [int] NULL,
	[sanPhamID] [int] NULL,
	[soLuong] [smallint] NULL,
	[thanhTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[chitietID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 26/4/2019 7:16:12 PM ******/
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
/****** Object:  Table [dbo].[Footer]    Script Date: 26/4/2019 7:16:13 PM ******/
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
/****** Object:  Table [dbo].[GiaoHang]    Script Date: 26/4/2019 7:16:13 PM ******/
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
/****** Object:  Table [dbo].[HoaDon]    Script Date: 26/4/2019 7:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[hoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[maKhach] [int] NULL,
	[loaiHoaDon] [nvarchar](50) NULL,
	[trangThai] [bit] NULL,
	[ngayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[hoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 26/4/2019 7:16:14 PM ******/
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
/****** Object:  Table [dbo].[NhomDanhMuc]    Script Date: 26/4/2019 7:16:15 PM ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 26/4/2019 7:16:16 PM ******/
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
/****** Object:  Table [dbo].[SanPhamTag]    Script Date: 26/4/2019 7:16:16 PM ******/
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
/****** Object:  Table [dbo].[Slide]    Script Date: 26/4/2019 7:16:18 PM ******/
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
/****** Object:  Table [dbo].[Tag]    Script Date: 26/4/2019 7:16:18 PM ******/
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
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 26/4/2019 7:16:19 PM ******/
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
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 26/4/2019 7:16:20 PM ******/
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
/****** Object:  Table [dbo].[TraHang]    Script Date: 26/4/2019 7:16:20 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 26/4/2019 7:16:21 PM ******/
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

INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (1, N'Máy ảnh', N'may-anh', 1, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (2, N'Ống kính', N'ong-kinh', 1, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (3, N'Phụ kiện', N'phu-kien', 1, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (4, NULL, N'cart', 1, N'_self', 0, N'/Assets/client/images/cart.png                    ')
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (5, NULL, N'login', 1, N'_blank', 0, N'/Assets/client/images/user.png                    ')
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (6, N'Máy ảnh', N'may-anh', 2, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (7, N'Ống kính', N'ong-kinh', 2, N'_self', 1, NULL)
INSERT [dbo].[DanhMuc] ([danhMucID], [tenDanhMuc], [URL], [groupID], [Target], [trangThai], [image]) VALUES (8, N'Phụ kiện', N'phu-kien', 2, N'_self', 1, NULL)
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
INSERT [dbo].[LoaiHang] ([loaiHangID], [tenLoai], [MetaTitle]) VALUES (2, N'Ống kính', N'ong-kinh')
INSERT [dbo].[LoaiHang] ([loaiHangID], [tenLoai], [MetaTitle]) VALUES (3, N'Phụ kiện', N'phu-kien')
SET IDENTITY_INSERT [dbo].[LoaiHang] OFF
SET IDENTITY_INSERT [dbo].[NhomDanhMuc] ON 

INSERT [dbo].[NhomDanhMuc] ([nhomID], [tenNhom]) VALUES (1, N'Menu Chính')
INSERT [dbo].[NhomDanhMuc] ([nhomID], [tenNhom]) VALUES (2, N'Menu Trái')
SET IDENTITY_INSERT [dbo].[NhomDanhMuc] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (1, 1, 2, N'Sony', 100000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:14.283' AS DateTime), N'may-anh', CAST(N'2019-04-05T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (2, 1, 1, N'Cannon', 200000, N' Vivamus ante lorem, eleifend nec interdum non, ullamcorper et arcu. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.eleifend nec interdum non, ullamcorper et arcu. Class aptent taciti sociosqu ad litora torquent per conubia nostra. ', N'/Assets/client/images/cam2.jpg', NULL, CAST(N'2019-04-03T08:19:32.593' AS DateTime), N'may-anh', CAST(N'2019-04-30T00:00:00.000' AS DateTime), 100)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (3, 1, 1, N'Cannon', 40000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/cam3.jpg', NULL, CAST(N'2019-04-03T08:19:48.630' AS DateTime), N'may-anh', CAST(N'2019-04-09T00:00:00.000' AS DateTime), 100)
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
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (14, 2, 1, N'Ống kính Canon EF50mm F/1.8 STM', 256000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/ongkinh/Ong-kinh-Canon-EF50mm-jpg.jpg', NULL, CAST(N'2019-04-13T13:50:36.547' AS DateTime), N'ong-kinh', NULL, 2)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (15, 2, 1, N'Ống Kính Sigma 17-50mm f/2.8 EX DC OS HSM', 625500, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/ongkinh/sigma-1750mm-f28-ex-dc-os-hsm-for-canon.jpg', NULL, CAST(N'2019-04-13T13:54:26.313' AS DateTime), N'ong-kinh', NULL, 5)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (16, 2, 1, N'Ống kính Canon EF-S18-55mm f/3.5-5.6 IS STM', 1532000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/ongkinh/canon-efs-1855mm-f3556-is-stm.jpg', NULL, CAST(N'2019-04-13T13:57:03.430' AS DateTime), N'ong-kinh', NULL, 8)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (17, 2, 4, N'Ống Kính Nikon AF-S NIKKOR 50mm f/1.8G', 740000, N' The first mechanically-propelled, two-wheeled vehicle may have been built by Kirkpatrick MacMillan, a Scottish blacksmith, in 1839, although the claim is often disputed. He is also associated with the first recorded instance of a cycling traffic offense, when a Glasgow newspaper in 1842 reported an accident in which an anonymous "gentleman from Dumfries-shire... bestride a velocipede... of ingenious design" knocked over a little girl in Glasgow and was fined five
                            The word bicycle first appeared in English print in The Daily News in 1868, to describe "Bysicles and trysicles" on the "Champs Elysées and Bois de Boulogne.
                        ', N'/Assets/client/images/ongkinh/Ong-Kinh-AF-S-NIKKOR-50mm-f1-8G.jpg', NULL, CAST(N'2019-04-13T13:58:28.690' AS DateTime), N'ong-kinh', NULL, 6)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (18, 2, 3, N'Ống Kính Fujifilm (Fujinon) XF 18-55mm F2.8-4 R LM OIS', 605000, N'Text demo', N'/Assets/client/images/ongkinh/Ong-kinh-FUJINON-XF18-55mmF2-8-4-R-LM-OIS.jpg', NULL, CAST(N'2019-04-13T14:01:09.400' AS DateTime), N'ong-kinh', NULL, 4)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (19, 2, 2, N'Ống Kính Sony SEL 50mm F1.8 SEL50F18', 7890000, N'Text demo 2222', N'/Assets/client/images/ongkinh/sony-sel-50mm-f18-sel50f18-den.jpg', NULL, CAST(N'2019-04-13T14:03:54.087' AS DateTime), N'ong-kinh', NULL, 9)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (20, 2, 2, N'Ống Kính Sony FE 50mm f/1.8 (SEL50F18F)', 555000, N'Demo Text', N'/Assets/client/images/ongkinh/Ong-Kinh-Sony-FE-50mm-f1-8--SEL50F18F.jpg', NULL, CAST(N'2019-04-13T14:06:09.797' AS DateTime), N'ong-kinh', NULL, 10)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (21, 3, 1, N'Flash Canon 47EX-AI', 3200000, N'Text text', N'/Assets/client/images/phukien/Den_Flash_Canon_Speedlite_470EX_AI_jpg_800x800.jpg', NULL, CAST(N'2019-04-13T16:58:23.530' AS DateTime), N'phu-kien', NULL, 7)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (22, 3, 1, N'Đèn Flash Canon 270EX II', 8700000, N'Text', N'/Assets/client/images/phukien/270ii_720x720.jpg', NULL, CAST(N'2019-04-13T17:00:04.690' AS DateTime), N'phu-kien', NULL, 56)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (23, 3, 1, N'Grip Canon BG-E22', 650000, N'Pin dùng', N'/Assets/client/images/phukien/gripxt1_1000x1000.jpg', NULL, CAST(N'2019-04-13T17:02:14.210' AS DateTime), N'phu-kien', NULL, 66)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (24, 3, 3, N'Fujifilm VG-XT1', 140000, N'Demo', N'/Assets/client/images/phukien/1536135667000_1433716_1000x1000.jpg', NULL, CAST(N'2019-04-13T17:03:41.630' AS DateTime), N'phu-kien', NULL, 23)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (25, 3, 5, N'Thiết bị chống rung DJI Ronin S', 650000, N'Thiết bị', N'/Assets/client/images/phukien/chong_rung_may_anh_dji_ronin_s_1500x1500.jpg', NULL, CAST(N'2019-04-13T17:05:14.827' AS DateTime), N'phu-kien', NULL, 11)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (26, 3, 5, N'Túi máy ảnh Peak Design Everyday Sling 10L ', 500000, N'Túi', N'/Assets/client/images/phukien/peak_design_bsl_10_as_1_everyday_sling_10l_ash_1277401_1000x1000.jpg', NULL, CAST(N'2019-04-13T17:07:32.287' AS DateTime), N'phu-kien', NULL, 77)
INSERT [dbo].[SanPham] ([sanPhamID], [loaiHang], [thuongHieu], [tenSanPham], [donGia], [moTa], [hinhAnh], [nhieuHinhAnh], [NgayTao], [MetaTitle], [Hot], [soLuong]) VALUES (27, 3, 5, N'Olympus CSCH-123 LBL', 980000, N'Demo demo', N'/Assets/client/images/phukien/Products91070_1000x1000_823465174_1000x1000.jpg', NULL, CAST(N'2019-04-13T17:09:37.037' AS DateTime), N'phu-kien', NULL, 33)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (1, N'slide1', N'/Assets/client/images/b1.jpg', N'#', 1)
INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (2, N'slide2', N'/Assets/client/images/b2.jpg', N'#', 1)
INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (3, N'slide3', N'/Assets/client/images/b3.jpg', N'#', 1)
INSERT [dbo].[Slide] ([ID], [tenSlide], [hinhAnh], [URL], [trangThai]) VALUES (4, N'slide4', N'/Assets/client/images/b4.jpg', N'#', 1)
SET IDENTITY_INSERT [dbo].[Slide] OFF
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

INSERT [dbo].[ThuongHieu] ([thuongHieuID], [tenThuongHieu]) VALUES (1, N'Cannon')
INSERT [dbo].[ThuongHieu] ([thuongHieuID], [tenThuongHieu]) VALUES (2, N'Sony')
INSERT [dbo].[ThuongHieu] ([thuongHieuID], [tenThuongHieu]) VALUES (3, N'Fujifilm')
INSERT [dbo].[ThuongHieu] ([thuongHieuID], [tenThuongHieu]) VALUES (4, N'Nikkor')
INSERT [dbo].[ThuongHieu] ([thuongHieuID], [tenThuongHieu]) VALUES (5, N'Khác')
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [userName], [passWord], [hoTen], [eMail], [diaChi], [soDienThoai]) VALUES (3, N'456', N'b51e8dbebd4ba8a8f342190a4b9f08d7', N'n', N'123@gmail.com', N'123', N'123456789  ')
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
