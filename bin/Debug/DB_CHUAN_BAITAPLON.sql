CREATE DATABASE [NAMSAORESTAURANT]
GO
USE [NAMSAORESTAURANT]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/25/2024 6:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [int] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](150) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[NumberPhone] [varchar](15) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](150) NULL,
	[DateBirthday] [date] NULL,
	[NumberPhone] [varchar](15) NULL,
	[Address] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Floor]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Floor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FloorName] [nvarchar](150) NULL,
	[QuantityTable] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Floor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItems]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuItemName] [nvarchar](150) NULL,
	[Price] [decimal](18, 2) NULL,
	[CategoryId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[EmployeeIdCreate] [int] NULL,
	[IsCurrentOrder] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 11/25/2024 6:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[FloorId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 
GO
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [EmployeeId]) VALUES (1, N'admin123', N'admin123', 0, 1)
GO
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [EmployeeId]) VALUES (2, N'hoang123', N'hoang123', 1, 2)
GO
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role], [EmployeeId]) VALUES (3002, N'nxhoa123', N'nxhoa123', 1, 5)
GO
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([ID], [CategoryName], [IsDeleted]) VALUES (1, N'Khai vị', 0)
GO
INSERT [dbo].[Category] ([ID], [CategoryName], [IsDeleted]) VALUES (2, N'Món chính', 0)
GO
INSERT [dbo].[Category] ([ID], [CategoryName], [IsDeleted]) VALUES (3, N'Tráng miệng', 0)
GO
INSERT [dbo].[Category] ([ID], [CategoryName], [IsDeleted]) VALUES (4, N'Đồ uống', 0)
GO
INSERT [dbo].[Category] ([ID], [CategoryName], [IsDeleted]) VALUES (7, N'Nhân viên', 0)
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([ID], [CustomerName], [NumberPhone]) VALUES (3, N'ngo xuan hoa', N'0123456789')
GO
INSERT [dbo].[Customer] ([ID], [CustomerName], [NumberPhone]) VALUES (5, N'ngo xuan hoa', N'0123456789')
GO
INSERT [dbo].[Customer] ([ID], [CustomerName], [NumberPhone]) VALUES (6, N'ngo xuan hoa', N'0123456789')
GO
INSERT [dbo].[Customer] ([ID], [CustomerName], [NumberPhone]) VALUES (1002, N'ngo xuan hoa', N'0123456789')
GO
INSERT [dbo].[Customer] ([ID], [CustomerName], [NumberPhone]) VALUES (1003, N'ngo xuan hoa', N'0123456789')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (1, N'Nguyễn Văn An', CAST(N'1990-01-15' AS Date), N'01234567891', N'Hà Nội', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (2, N'Trần Thị Bích', CAST(N'1985-05-22' AS Date), N'01234567892', N'TP Hồ Chí Minh', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (3, N'Lê Văn Cường', CAST(N'1992-03-10' AS Date), N'01234567893', N'Đà Nẵng', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (4, N'Phạm Thị Dung', CAST(N'1988-08-30' AS Date), N'01234567894', N'Hải Phòng', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (5, N'Nguyễn Thị Hoa', CAST(N'1995-12-12' AS Date), N'01234567895', N'Cần Thơ', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (6, N'Trương Văn Hưng', CAST(N'1991-06-18' AS Date), N'01234567896', N'Nha Trang', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (7, N'Lê Thị Kiều', CAST(N'1987-11-05' AS Date), N'01234567897', N'Biên Hòa', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (8, N'Nguyễn Văn Long', CAST(N'1993-02-14' AS Date), N'01234567898', N'Vũng Tàu', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (9, N'Đặng Thị Mai', CAST(N'1994-09-09' AS Date), N'01234567899', N'Đà Lạt', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (10, N'Nguyễn Văn Nam', CAST(N'1996-04-20' AS Date), N'01234567900', N'Quy Nhơn', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (11, N'Bùi Thị Ngọc', CAST(N'1992-07-15' AS Date), N'01234567901', N'Huế', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (12, N'Ngô Văn Phát', CAST(N'1990-10-10' AS Date), N'01234567902', N'Hà Tĩnh', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (13, N'Trần Văn Quang', CAST(N'1989-01-25' AS Date), N'01234567903', N'Ninh Bình', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (14, N'Lê Văn Sơn', CAST(N'1991-05-18' AS Date), N'01234567904', N'Nam Định', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (15, N'Phạm Văn Thịnh', CAST(N'1993-08-22' AS Date), N'01234567905', N'Hưng Yên', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (16, N'Nguyễn Thị Thảo', CAST(N'1994-12-30' AS Date), N'01234567906', N'Thanh Hóa', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (17, N'Trương Văn Vinh', CAST(N'1986-03-15' AS Date), N'01234567907', N'Bắc Ninh', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (18, N'Đỗ Thị Yến', CAST(N'1995-06-20' AS Date), N'01234567908', N'Thái Nguyên', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (19, N'Lê Văn Z', CAST(N'1991-09-11' AS Date), N'01234567909', N'Vĩnh Phúc', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (20, N'Nguyễn Thị Ánh', CAST(N'1993-02-28' AS Date), N'01234567910', N'Long An', 0)
GO
INSERT [dbo].[Employee] ([ID], [EmployeeName], [DateBirthday], [NumberPhone], [Address], [IsDeleted]) VALUES (21, N'Vũ Thị Ánh', CAST(N'1990-01-25' AS Date), N'01234567891', N'Bắc Ninh', 0)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Floor] ON 
GO
INSERT [dbo].[Floor] ([ID], [FloorName], [QuantityTable], [IsDeleted]) VALUES (1, N'Tầng 1', 10, 0)
GO
INSERT [dbo].[Floor] ([ID], [FloorName], [QuantityTable], [IsDeleted]) VALUES (2, N'Tầng 2', 12, 0)
GO
INSERT [dbo].[Floor] ([ID], [FloorName], [QuantityTable], [IsDeleted]) VALUES (3, N'Tầng 3', 9, 0)
GO
INSERT [dbo].[Floor] ([ID], [FloorName], [QuantityTable], [IsDeleted]) VALUES (4, N'Tầng 4', 13, 0)
GO
INSERT [dbo].[Floor] ([ID], [FloorName], [QuantityTable], [IsDeleted]) VALUES (5, N'Tầng 5', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Floor] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItems] ON 
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (1, N'Gỏi cuốn', CAST(35.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (2, N'Nem rán', CAST(50.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (3, N'Chả giò', CAST(40.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (4, N'Nộm bò khô', CAST(45.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (5, N'Bánh cuốn', CAST(30.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (6, N'Phở bò', CAST(65.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (7, N'Bún chả', CAST(70.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (8, N'Bánh xèo', CAST(60.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (9, N'Cơm tấm', CAST(55.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (10, N'Bún bò Huế', CAST(65.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (11, N'Chè ba màu', CAST(25.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (12, N'Bánh chuối nướng', CAST(30.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (13, N'Bánh flan', CAST(20.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (14, N'Chè đậu xanh', CAST(25.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (15, N'Sương sáo', CAST(20.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (16, N'Cà phê sữa đá', CAST(30.00 AS Decimal(18, 2)), 4, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (17, N'Nước mía', CAST(15.00 AS Decimal(18, 2)), 4, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (18, N'Trà đá', CAST(10.00 AS Decimal(18, 2)), 4, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (19, N'Sinh tố bơ', CAST(35.00 AS Decimal(18, 2)), 4, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (20, N'Nước dừa', CAST(20.00 AS Decimal(18, 2)), 4, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (1002, N'Bia 333', CAST(36.00 AS Decimal(18, 2)), 4, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (1003, N'Bia Heniken', CAST(40.00 AS Decimal(18, 2)), 4, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (2008, N'Vũ Thư', CAST(35.00 AS Decimal(18, 2)), 7, 0)
GO
INSERT [dbo].[MenuItems] ([ID], [MenuItemName], [Price], [CategoryId], [IsDeleted]) VALUES (2009, N'Kiều anh', CAST(35.00 AS Decimal(18, 2)), 7, 0)
GO
SET IDENTITY_INSERT [dbo].[MenuItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT [dbo].[Order] ([ID], [TableId], [CustomerId], [OrderDate], [TotalPrice], [EmployeeIdCreate], [IsCurrentOrder]) VALUES (1, 1, 1002, CAST(N'2024-10-18T11:38:34.010' AS DateTime), CAST(670.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Order] ([ID], [TableId], [CustomerId], [OrderDate], [TotalPrice], [EmployeeIdCreate], [IsCurrentOrder]) VALUES (2, 4, 1003, CAST(N'2024-10-18T11:44:55.897' AS DateTime), CAST(35.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Order] ([ID], [TableId], [CustomerId], [OrderDate], [TotalPrice], [EmployeeIdCreate], [IsCurrentOrder]) VALUES (1002, 4, NULL, CAST(N'2024-10-18T17:35:40.227' AS DateTime), CAST(220.00 AS Decimal(18, 2)), 1, 1)
GO
INSERT [dbo].[Order] ([ID], [TableId], [CustomerId], [OrderDate], [TotalPrice], [EmployeeIdCreate], [IsCurrentOrder]) VALUES (1003, 1, NULL, CAST(N'2024-10-18T23:16:05.583' AS DateTime), CAST(325.00 AS Decimal(18, 2)), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1006, 2, 1, 1, CAST(35.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1013, 1, 3, 2, CAST(40.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1014, 1, 4, 2, CAST(45.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1017, 1, 2, 6, CAST(50.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1019, 1002, 1, 4, CAST(35.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1020, 1002, 3, 2, CAST(40.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1021, 1003, 1, 1, CAST(35.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1022, 1003, 2, 1, CAST(50.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([ID], [OrderId], [ItemId], [Quantity], [Price]) VALUES (1023, 1003, 3, 1, CAST(40.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (1, N'Bàn 1', 1, CAST(200.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (2, N'Bàn 2', 0, CAST(100.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (3, N'Bàn 3', 0, CAST(0.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (4, N'Bàn 4', 1, CAST(0.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (5, N'Bàn 5', 0, CAST(0.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (6, N'Bàn 6', 0, CAST(0.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (7, N'Bàn 7', 0, CAST(0.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (8, N'Bàn 8', 0, CAST(0.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (9, N'Bàn 9 VIP', 0, CAST(500.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (10, N'Bàn 10 VIP', 0, CAST(502.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (11, N'Bàn 11', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (12, N'Bàn 12', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (13, N'Bàn 13', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (14, N'Bàn 14', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (15, N'Bàn 15', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (16, N'Bàn 16', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (17, N'Bàn 17', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (18, N'Bàn 18', 0, CAST(0.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (19, N'Bàn 19 VIP', 0, CAST(600.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (20, N'Bàn 20 VIP', 0, CAST(800.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (21, N'Bàn 21 VIP', 0, CAST(600.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (22, N'Bàn 22 VIP', 0, CAST(800.00 AS Decimal(18, 2)), 2, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (23, N'Bàn 23', 0, CAST(0.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (24, N'Bàn 24', 0, CAST(0.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (25, N'Bàn 25', 0, CAST(0.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (26, N'Bàn 26', 0, CAST(0.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (27, N'Bàn 27', 0, CAST(0.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (28, N'Bàn 28', 0, CAST(0.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (29, N'Bàn 29', 0, CAST(0.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (30, N'Bàn 30 VIP', 0, CAST(700.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (31, N'Bàn 31 VIP', 0, CAST(900.00 AS Decimal(18, 2)), 3, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (32, N'Bàn 11', 0, CAST(300.00 AS Decimal(18, 2)), 1, 0)
GO
INSERT [dbo].[Table] ([ID], [TableName], [Status], [Price], [FloorId], [IsDeleted]) VALUES (1032, N'Bàn 12', 0, CAST(0.00 AS Decimal(18, 2)), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UniqueUsername]    Script Date: 11/25/2024 6:29:32 PM ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [IX_UniqueUsername] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Floor] ADD  CONSTRAINT [DF_Floor_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MenuItems] ADD  CONSTRAINT [DF_MenuItems_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_IsCurrentOrder]  DEFAULT ((0)) FOR [IsCurrentOrder]
GO
ALTER TABLE [dbo].[Table] ADD  CONSTRAINT [DF_Table_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Table] ADD  CONSTRAINT [DF_Table_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_EmployeeId]
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[MenuItems] CHECK CONSTRAINT [FK_MenuItem_CategoryId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_CustomerId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_EmployeeIdCreate] FOREIGN KEY([EmployeeIdCreate])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_EmployeeIdCreate]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_TableId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Ordetails_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[MenuItems] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_Ordetails_ItemId]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_FloorId] FOREIGN KEY([FloorId])
REFERENCES [dbo].[Floor] ([ID])
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_FloorId]
GO
