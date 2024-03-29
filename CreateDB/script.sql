USE [master]
GO
/****** Object:  Database [QLGiangDay]    Script Date: 4/26/2023 5:51:29 PM ******/
CREATE DATABASE [QLGiangDay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLGiangDay', FILENAME = N'D:\Programs\SQL-Server2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLGiangDay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLGiangDay_log', FILENAME = N'D:\Programs\SQL-Server2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLGiangDay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLGiangDay] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLGiangDay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLGiangDay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLGiangDay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLGiangDay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLGiangDay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLGiangDay] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLGiangDay] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLGiangDay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLGiangDay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLGiangDay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLGiangDay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLGiangDay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLGiangDay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLGiangDay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLGiangDay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLGiangDay] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLGiangDay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLGiangDay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLGiangDay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLGiangDay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLGiangDay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLGiangDay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLGiangDay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLGiangDay] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLGiangDay] SET  MULTI_USER 
GO
ALTER DATABASE [QLGiangDay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLGiangDay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLGiangDay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLGiangDay] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLGiangDay] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLGiangDay] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLGiangDay] SET QUERY_STORE = OFF
GO
USE [QLGiangDay]
GO
/****** Object:  Table [dbo].[ChiTietGiaiDoan]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGiaiDoan](
	[MaCTGD] [nvarchar](20) NOT NULL,
	[MaGiaiDoan] [nvarchar](20) NOT NULL,
	[MaPhong] [nvarchar](20) NOT NULL,
	[Thu] [int] NULL,
	[Tiet] [int] NULL,
 CONSTRAINT [pk_chitietgiaidoan] PRIMARY KEY CLUSTERED 
(
	[MaCTGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaiDoan]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaiDoan](
	[MaGiaiDoan] [nvarchar](20) NOT NULL,
	[MaLopHP] [nvarchar](20) NOT NULL,
	[TenGiaiDoan] [nvarchar](20) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
 CONSTRAINT [pk_giaidoan] PRIMARY KEY CLUSTERED 
(
	[MaGiaiDoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocPhan]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocPhan](
	[MaHocPhan] [nvarchar](20) NOT NULL,
	[MaToMon] [nvarchar](20) NOT NULL,
	[MaKhoaDT] [nvarchar](20) NOT NULL,
	[TenHocPhan] [nvarchar](50) NULL,
	[SoTinChi] [int] NULL,
	[LyThuyet] [int] NULL,
	[ThaoLuan] [int] NULL,
	[ThietKeMonHoc] [int] NULL,
	[BaiTapLon] [int] NULL,
	[ThiNghiem] [int] NULL,
	[ThucHanh] [int] NULL,
	[TuHoc] [int] NULL,
 CONSTRAINT [pk_hocphan] PRIMARY KEY CLUSTERED 
(
	[MaHocPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [nvarchar](20) NOT NULL,
	[TenKhoa] [nvarchar](50) NULL,
 CONSTRAINT [pk_khoa] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoaDT]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaDT](
	[MaKhoaDT] [nvarchar](20) NOT NULL,
	[MaNganh] [nvarchar](20) NOT NULL,
	[TenKhoaDT] [nvarchar](30) NULL,
	[NamNhap] [int] NULL,
	[SoNamDT] [int] NULL,
 CONSTRAINT [pk_khoadt] PRIMARY KEY CLUSTERED 
(
	[MaKhoaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [nvarchar](20) NOT NULL,
	[MaKhoaDT] [nvarchar](20) NOT NULL,
	[TenLop] [nvarchar](30) NULL,
	[SoSV] [int] NULL,
 CONSTRAINT [pk_lop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHocPhan]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocPhan](
	[MaLopHP] [nvarchar](20) NOT NULL,
	[MaHocPhan] [nvarchar](20) NOT NULL,
	[MaGV] [nvarchar](20) NULL,
	[TenLopHP] [nvarchar](50) NULL,
	[SiSo] [int] NULL,
	[SoDK] [int] NULL,
	[MaLop] [nvarchar](20) NOT NULL,
 CONSTRAINT [pk_lophocphan] PRIMARY KEY CLUSTERED 
(
	[MaLopHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[MaNganh] [nvarchar](20) NOT NULL,
	[MaKhoa] [nvarchar](20) NOT NULL,
	[TenNganh] [nvarchar](50) NULL,
 CONSTRAINT [pk_nganh] PRIMARY KEY CLUSTERED 
(
	[MaNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongHoc]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongHoc](
	[MaPhong] [nvarchar](20) NOT NULL,
	[TenPhong] [nvarchar](20) NULL,
	[DiaDiem] [nvarchar](20) NULL,
 CONSTRAINT [pk_phonghoc] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinGV]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinGV](
	[MaGV] [nvarchar](20) NOT NULL,
	[MaToMon] [nvarchar](20) NOT NULL,
	[HoGV] [nvarchar](20) NULL,
	[TenGV] [nvarchar](20) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh] [bit] NULL,
	[DienThoai] [nvarchar](20) NULL,
	[ChucVu] [nvarchar](30) NULL,
	[TenDayDu] [nvarchar](50) NULL,
	[Anh] [nvarchar](30) NULL,
 CONSTRAINT [pk_thongtingv] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToMon]    Script Date: 4/26/2023 5:51:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToMon](
	[MaToMon] [nvarchar](20) NOT NULL,
	[MaKhoa] [nvarchar](20) NOT NULL,
	[TenToMon] [nvarchar](50) NULL,
	[SoGV] [int] NULL,
 CONSTRAINT [pk_tomon] PRIMARY KEY CLUSTERED 
(
	[MaToMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'CNT301.3', N'CNT', N'CNTTK61', N'Thực tập chuyên môn', 3, NULL, NULL, NULL, NULL, NULL, 90, 60)
INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'CPM212.3', N'CPM', N'CNTTK61', N'Lập trình sử dụng API', 3, 30, 15, NULL, 10, NULL, 15, 90)
INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'KHM07.3', N'KHM', N'CNTTK61', N'An toàn và bảo mật thông tin', 3, 30, 15, NULL, NULL, NULL, 15, 90)
INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'KHM20.3', N'KHM', N'CNTTK61', N'Lý thuyết trò chơi và ứng dụng', 3, 30, 15, NULL, NULL, NULL, 15, 90)
INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'MHT07.3', N'MHT', N'CNTTK61', N'Trí tuệ nhân tạo', 3, 30, 30, NULL, NULL, NULL, NULL, 90)
INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'MHT208.3', N'MHT', N'CNTTK61', N'Lập trình Web', 3, 30, 15, NULL, 10, NULL, 15, 90)
INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'MHT22.3', N'MHT', N'CNTTK61', N'Lập trình mạng', 3, 30, 15, NULL, NULL, NULL, 15, 90)
INSERT [dbo].[HocPhan] ([MaHocPhan], [MaToMon], [MaKhoaDT], [TenHocPhan], [SoTinChi], [LyThuyet], [ThaoLuan], [ThietKeMonHoc], [BaiTapLon], [ThiNghiem], [ThucHanh], [TuHoc]) VALUES (N'MHT234.3', N'MHT', N'CNTTK61', N'Lập trình thiết bị di động', 3, 30, 15, NULL, 10, NULL, 15, 90)
GO
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'CNTT', N'Công nghệ thông tin')
GO
INSERT [dbo].[KhoaDT] ([MaKhoaDT], [MaNganh], [TenKhoaDT], [NamNhap], [SoNamDT]) VALUES (N'CNTTK61', N'7480201', N'Công nghệ thông tin k61', 2020, 5)
GO
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTT1K61', N'CNTTK61', N'Công nghệ thông tin 1 k61', 74)
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTT2K61', N'CNTTK61', N'Công nghệ thông tin 2 k61', 74)
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTT3K61', N'CNTTK61', N'Công nghệ thông tin 3 k61', 74)
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTT4K61', N'CNTTK61', N'Công nghệ thông tin 4 k61', 74)
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTT5K61', N'CNTTK61', N'Công nghệ thông tin 5 k61', 74)
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTT6K61', N'CNTTK61', N'Công nghệ thông tin 6 k61', 74)
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTTVA1K61', N'CNTTK61', N'Công nghệ TTVA 1 k61', 74)
INSERT [dbo].[Lop] ([MaLop], [MaKhoaDT], [TenLop], [SoSV]) VALUES (N'CNTTVA2K61', N'CNTTK61', N'Công nghệ TTVA 2 k61', 74)
GO

INSERT [dbo].[Nganh] ([MaNganh], [MaKhoa], [TenNganh]) VALUES (N'7480201', N'CNTT', N'Công nghệ thông tin')
GO
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'105A5', N'105', N'A5')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'201AA2', N'201A', N'A2')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'202A5', N'202', N'A5')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'205A5', N'205', N'A5')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'208A3', N'208', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'301A3', N'301', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'301A5', N'301', N'A5')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'302A3', N'302', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'303A3', N'303', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'303A8', N'303', N'A8')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'305A3', N'305', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'401A8', N'401', N'A8')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'402A7', N'402', N'A7')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'402A8', N'402', N'A8')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'404A8', N'404', N'A8')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'405A3', N'405', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'406A3', N'406', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'407A3', N'407', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'501A3', N'501', N'A3')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'509A8', N'509', N'A8')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [DiaDiem]) VALUES (N'511A8', N'511', N'A8')
GO
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV1', N'KHM', N'Pham', N'Quan', NULL, 0, NULL, NULL, N'Pham Quan', N'gv1.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV10', N'MHT', N'Pham', N'Hoai', NULL, 1, NULL, NULL, N'Pham Hoai', N'gv10.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV11', N'MHT', N'Nguyen', N'Hong', NULL, 1, NULL, NULL, N'Nguyen Hong', N'gv11.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV2', N'MHT', N'Nguyen', N'Anh', NULL, 1, NULL, NULL, N'Nguyen Anh', N'gv2.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV3', N'CPM', N'Bui', N'Quang', NULL, 0, NULL, NULL, N'Bui Quang', N'gv3.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV4', N'CNT', N'Vu', N'Loi', NULL, 0, NULL, NULL, N'Vu Loi', N'gv4.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV5', N'MHT', N'Vu', N'Thuy', NULL, 1, NULL, NULL, N'Vu Thuy', N'gv5.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV6', N'MHT', N'Nguyen', N'Ngoc', NULL, 0, NULL, NULL, N'Nguyen Ngoc', N'gv6.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV7', N'MHT', N'Tran', N'Chuong', NULL, 0, NULL, NULL, N'Tran Chuong', N'gv7.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV8', N'MHT', N'Luu', N'Loi', NULL, 0, NULL, NULL, N'Luu Loi', N'gv8.jpg')
INSERT [dbo].[ThongTinGV] ([MaGV], [MaToMon], [HoGV], [TenGV], [NgaySinh], [GioiTinh], [DienThoai], [ChucVu], [TenDayDu], [Anh]) VALUES (N'GV9', N'MHT', N'Nguyen', N'Hue', NULL, 1, NULL, NULL, N'Nguyen Hue', N'gv9.jpg')
GO
INSERT [dbo].[ToMon] ([MaToMon], [MaKhoa], [TenToMon], [SoGV]) VALUES (N'CNT', N'CNTT', NULL, NULL)
INSERT [dbo].[ToMon] ([MaToMon], [MaKhoa], [TenToMon], [SoGV]) VALUES (N'CPM', N'CNTT', NULL, NULL)
INSERT [dbo].[ToMon] ([MaToMon], [MaKhoa], [TenToMon], [SoGV]) VALUES (N'KHM', N'CNTT', NULL, NULL)
INSERT [dbo].[ToMon] ([MaToMon], [MaKhoa], [TenToMon], [SoGV]) VALUES (N'MHT', N'CNTT', NULL, NULL)
GO
ALTER TABLE [dbo].[ChiTietGiaiDoan]  WITH CHECK ADD  CONSTRAINT [fk_chitietgiaidoan_giaidoan] FOREIGN KEY([MaGiaiDoan])
REFERENCES [dbo].[GiaiDoan] ([MaGiaiDoan])
GO
ALTER TABLE [dbo].[ChiTietGiaiDoan] CHECK CONSTRAINT [fk_chitietgiaidoan_giaidoan]
GO
ALTER TABLE [dbo].[ChiTietGiaiDoan]  WITH CHECK ADD  CONSTRAINT [fk_chitietgiaidoan_phonghoc] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongHoc] ([MaPhong])
GO
ALTER TABLE [dbo].[ChiTietGiaiDoan] CHECK CONSTRAINT [fk_chitietgiaidoan_phonghoc]
GO
ALTER TABLE [dbo].[GiaiDoan]  WITH CHECK ADD  CONSTRAINT [fk_giaidoan_lophocphan] FOREIGN KEY([MaLopHP])
REFERENCES [dbo].[LopHocPhan] ([MaLopHP])
GO
ALTER TABLE [dbo].[GiaiDoan] CHECK CONSTRAINT [fk_giaidoan_lophocphan]
GO
ALTER TABLE [dbo].[HocPhan]  WITH CHECK ADD  CONSTRAINT [fk_hocphan_khoadt] FOREIGN KEY([MaKhoaDT])
REFERENCES [dbo].[KhoaDT] ([MaKhoaDT])
GO
ALTER TABLE [dbo].[HocPhan] CHECK CONSTRAINT [fk_hocphan_khoadt]
GO
ALTER TABLE [dbo].[HocPhan]  WITH CHECK ADD  CONSTRAINT [fk_hocphan_tomon] FOREIGN KEY([MaToMon])
REFERENCES [dbo].[ToMon] ([MaToMon])
GO
ALTER TABLE [dbo].[HocPhan] CHECK CONSTRAINT [fk_hocphan_tomon]
GO
ALTER TABLE [dbo].[KhoaDT]  WITH CHECK ADD  CONSTRAINT [fk_khoadt_nganh] FOREIGN KEY([MaNganh])
REFERENCES [dbo].[Nganh] ([MaNganh])
GO
ALTER TABLE [dbo].[KhoaDT] CHECK CONSTRAINT [fk_khoadt_nganh]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [fk_lop_khoadt] FOREIGN KEY([MaKhoaDT])
REFERENCES [dbo].[KhoaDT] ([MaKhoaDT])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [fk_lop_khoadt]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [fk_lophocphan_hocphan] FOREIGN KEY([MaHocPhan])
REFERENCES [dbo].[HocPhan] ([MaHocPhan])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [fk_lophocphan_hocphan]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [fk_lophocphan_lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [fk_lophocphan_lop]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [fk_lophocphan_thongtingv] FOREIGN KEY([MaGV])
REFERENCES [dbo].[ThongTinGV] ([MaGV])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [fk_lophocphan_thongtingv]
GO
ALTER TABLE [dbo].[ThongTinGV]  WITH CHECK ADD  CONSTRAINT [fk_thongtingv_tomon] FOREIGN KEY([MaToMon])
REFERENCES [dbo].[ToMon] ([MaToMon])
GO
ALTER TABLE [dbo].[ThongTinGV] CHECK CONSTRAINT [fk_thongtingv_tomon]
GO
ALTER TABLE [dbo].[ToMon]  WITH CHECK ADD  CONSTRAINT [fk_tomon_khoa] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[ToMon] CHECK CONSTRAINT [fk_tomon_khoa]
GO
USE [master]
GO
ALTER DATABASE [QLGiangDay] SET  READ_WRITE 
GO

CREATE TRIGGER trg_ThongTinGV
ON ThongTinGV
AFTER INSERT
AS
BEGIN
    UPDATE ThongTinGV SET TenDayDu = CONCAT(ThongTinGV.HoGV, ' ', ThongTinGV.TenGV)
    FROM ThongTinGV JOIN inserted ON ThongTinGV.MaGV = inserted.MaGV
END