USE [master]
GO
/****** Object:  Database [Restaurant]    Script Date: 8/1/2019 6:56:41 AM ******/
CREATE DATABASE [Restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Restaurant.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Restaurant_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Restaurant_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Restaurant] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Restaurant] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [Restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Restaurant] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Restaurant] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Restaurant] SET QUERY_STORE = OFF
GO
USE [Restaurant]
GO
/****** Object:  Table [dbo].[BreakfastItems]    Script Date: 8/1/2019 6:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BreakfastItems](
	[ItemIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[Item] [nvarchar](max) NULL,
 CONSTRAINT [PK_BreakfastItems] PRIMARY KEY CLUSTERED 
(
	[ItemIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BreakfastOrderItems]    Script Date: 8/1/2019 6:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BreakfastOrderItems](
	[OrderItemIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[BreakfastIdentifier] [int] NULL,
	[GuestIdentifier] [int] NULL,
	[Quantity] [int] NULL,
	[ItemIdentifier] [int] NULL,
 CONSTRAINT [PK_BreakfastOrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BreakfastOrders]    Script Date: 8/1/2019 6:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BreakfastOrders](
	[BreakfastIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[GuestIdentifier] [int] NULL,
	[OrderDate] [datetime2](7) NULL,
 CONSTRAINT [PK_BreakfastOrders] PRIMARY KEY CLUSTERED 
(
	[BreakfastIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guests]    Script Date: 8/1/2019 6:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guests](
	[GuestIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[RoomIdentifier] [int] NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Guests] PRIMARY KEY CLUSTERED 
(
	[GuestIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/1/2019 6:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[RoomFloor] [int] NULL,
	[RoomDesginator] [nvarchar](1) NULL,
	[RoomNumber] [int] NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BreakfastItems] ON 

INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (1, N'2 Fried Eggs')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (2, N'2 Scrambled Eggs')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (3, N'2 Poached Eggs')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (4, N'2 Cheese grillers')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (5, N'Toast')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (6, N'3 Rashers of bacon')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (7, N'Avocado')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (8, N'Avocado Toast With Egg')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (9, N'Basil pesto cherry tomatoes')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (10, N'Berry and Yogurt Smoothie')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (11, N'Cherry tomatoes')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (12, N'Grilled tomato')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (13, N'Mushrooms')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (14, N'Nut Butter, Banana, and Chia Seed Toast')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (15, N'Quinoa and Chia Porridge')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (16, N'Quinoa Fruit Salad')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (17, N'Savory Oatmeal With an Egg')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (18, N'Smoked Salmon')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (19, N'Tomato Toast With Macadamia Ricotta')
INSERT [dbo].[BreakfastItems] ([ItemIdentifier], [Item]) VALUES (20, N'French toast')
SET IDENTITY_INSERT [dbo].[BreakfastItems] OFF
SET IDENTITY_INSERT [dbo].[BreakfastOrderItems] ON 

INSERT [dbo].[BreakfastOrderItems] ([OrderItemIdentifier], [BreakfastIdentifier], [GuestIdentifier], [Quantity], [ItemIdentifier]) VALUES (1, 1, 1, 1, 2)
INSERT [dbo].[BreakfastOrderItems] ([OrderItemIdentifier], [BreakfastIdentifier], [GuestIdentifier], [Quantity], [ItemIdentifier]) VALUES (2, 2, 1, 2, 7)
INSERT [dbo].[BreakfastOrderItems] ([OrderItemIdentifier], [BreakfastIdentifier], [GuestIdentifier], [Quantity], [ItemIdentifier]) VALUES (3, 2, 1, 1, 18)
INSERT [dbo].[BreakfastOrderItems] ([OrderItemIdentifier], [BreakfastIdentifier], [GuestIdentifier], [Quantity], [ItemIdentifier]) VALUES (4, 2, 1, 1, 4)
INSERT [dbo].[BreakfastOrderItems] ([OrderItemIdentifier], [BreakfastIdentifier], [GuestIdentifier], [Quantity], [ItemIdentifier]) VALUES (5, 3, 2, 3, 5)
INSERT [dbo].[BreakfastOrderItems] ([OrderItemIdentifier], [BreakfastIdentifier], [GuestIdentifier], [Quantity], [ItemIdentifier]) VALUES (6, 3, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[BreakfastOrderItems] OFF
SET IDENTITY_INSERT [dbo].[BreakfastOrders] ON 

INSERT [dbo].[BreakfastOrders] ([BreakfastIdentifier], [GuestIdentifier], [OrderDate]) VALUES (1, 1, CAST(N'2019-07-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[BreakfastOrders] ([BreakfastIdentifier], [GuestIdentifier], [OrderDate]) VALUES (2, 1, CAST(N'2019-07-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[BreakfastOrders] ([BreakfastIdentifier], [GuestIdentifier], [OrderDate]) VALUES (3, 2, CAST(N'2019-07-26T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[BreakfastOrders] OFF
SET IDENTITY_INSERT [dbo].[Guests] ON 

INSERT [dbo].[Guests] ([GuestIdentifier], [RoomIdentifier], [FirstName], [LastName]) VALUES (1, 2, N'Karen', N'Payne')
INSERT [dbo].[Guests] ([GuestIdentifier], [RoomIdentifier], [FirstName], [LastName]) VALUES (2, 1, N'Joe', N'Smith')
SET IDENTITY_INSERT [dbo].[Guests] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomIdentifier], [RoomFloor], [RoomDesginator], [RoomNumber]) VALUES (1, 1, N'A', 101)
INSERT [dbo].[Rooms] ([RoomIdentifier], [RoomFloor], [RoomDesginator], [RoomNumber]) VALUES (2, 1, N'A', 102)
INSERT [dbo].[Rooms] ([RoomIdentifier], [RoomFloor], [RoomDesginator], [RoomNumber]) VALUES (3, 1, N'A', 103)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
ALTER TABLE [dbo].[BreakfastOrders] ADD  CONSTRAINT [DF_BreakfastOrders_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[BreakfastOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_BreakfastOrderItems_BreakfastItems] FOREIGN KEY([ItemIdentifier])
REFERENCES [dbo].[BreakfastItems] ([ItemIdentifier])
GO
ALTER TABLE [dbo].[BreakfastOrderItems] CHECK CONSTRAINT [FK_BreakfastOrderItems_BreakfastItems]
GO
ALTER TABLE [dbo].[BreakfastOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_BreakfastOrderItems_BreakfastOrders1] FOREIGN KEY([BreakfastIdentifier])
REFERENCES [dbo].[BreakfastOrders] ([BreakfastIdentifier])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BreakfastOrderItems] CHECK CONSTRAINT [FK_BreakfastOrderItems_BreakfastOrders1]
GO
ALTER TABLE [dbo].[BreakfastOrders]  WITH CHECK ADD  CONSTRAINT [FK_BreakfastOrders_Guests1] FOREIGN KEY([GuestIdentifier])
REFERENCES [dbo].[Guests] ([GuestIdentifier])
GO
ALTER TABLE [dbo].[BreakfastOrders] CHECK CONSTRAINT [FK_BreakfastOrders_Guests1]
GO
ALTER TABLE [dbo].[Guests]  WITH CHECK ADD  CONSTRAINT [FK_Guests_Rooms1] FOREIGN KEY([RoomIdentifier])
REFERENCES [dbo].[Rooms] ([RoomIdentifier])
GO
ALTER TABLE [dbo].[Guests] CHECK CONSTRAINT [FK_Guests_Rooms1]
GO
USE [master]
GO
ALTER DATABASE [Restaurant] SET  READ_WRITE 
GO
