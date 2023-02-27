USE [master]
GO
/****** Object:  Database [ShopeeDB]    Script Date: 2/27/2023 2:33:36 PM ******/
CREATE DATABASE [ShopeeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopeeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\ShopeeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopeeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\ShopeeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopeeDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopeeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopeeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopeeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopeeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopeeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopeeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopeeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopeeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopeeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopeeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopeeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopeeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopeeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopeeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopeeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopeeDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopeeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopeeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopeeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopeeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopeeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopeeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopeeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopeeDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopeeDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShopeeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopeeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopeeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopeeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopeeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopeeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopeeDB', N'ON'
GO
ALTER DATABASE [ShopeeDB] SET QUERY_STORE = OFF
GO
USE [ShopeeDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatHistory]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatHistory](
	[ChatID] [int] IDENTITY(1,1) NOT NULL,
	[ChatContent] [nvarchar](max) NOT NULL,
	[Date] [date] NULL,
	[UserID1] [int] NOT NULL,
	[UserID2] [int] NOT NULL,
 CONSTRAINT [PK_ChatHistory] PRIMARY KEY CLUSTERED 
(
	[ChatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlashSale]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlashSale](
	[FID] [int] IDENTITY(1,1) NOT NULL,
	[DateStart] [date] NULL,
	[DateEnd] [date] NULL,
	[UnitPrice] [money] NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_FlashSale] PRIMARY KEY CLUSTERED 
(
	[FID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OID] [int] NOT NULL,
	[PID] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[Total] [money] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[UnitPrice] [money] NULL,
	[UnitInStock] [int] NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[CategoryID] [int] NOT NULL,
	[SaleID] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[ProductID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/27/2023 2:33:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [int] NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [Password], [Name], [Email], [Phone], [Role]) VALUES (1, N'admin', N'admin', N'Vũ Trí Hải ANh', N'haianh0812001@gmail.com', 12377123, 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Name], [Email], [Phone], [Role]) VALUES (2, N'saler', N'saler', N'HHH', N'áhhdh', 76257272, 2)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Name], [Email], [Phone], [Role]) VALUES (3, N'haianh', N'123', N'Hải ANh', N'sahd', 82139912, 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ChatHistory]  WITH CHECK ADD  CONSTRAINT [FK_ChatHistory_Users] FOREIGN KEY([UserID1])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[ChatHistory] CHECK CONSTRAINT [FK_ChatHistory_Users]
GO
ALTER TABLE [dbo].[FlashSale]  WITH CHECK ADD  CONSTRAINT [FK_FlashSale_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[FlashSale] CHECK CONSTRAINT [FK_FlashSale_Product]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Orders] FOREIGN KEY([OID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Orders]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([PID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Categories]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Users] FOREIGN KEY([SaleID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Users]
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCart_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ShoppingCart] CHECK CONSTRAINT [FK_ShoppingCart_Product]
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCart_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[ShoppingCart] CHECK CONSTRAINT [FK_ShoppingCart_Users]
GO
USE [master]
GO
ALTER DATABASE [ShopeeDB] SET  READ_WRITE 
GO
