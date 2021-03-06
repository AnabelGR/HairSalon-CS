USE [master]
GO
/****** Object:  Database [hair_salon]    Script Date: 6/18/2017 10:28:44 PM ******/
CREATE DATABASE [hair_salon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hair_salon', FILENAME = N'C:\Users\Anabel\hair_salon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hair_salon_log', FILENAME = N'C:\Users\Anabel\hair_salon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [hair_salon] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hair_salon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hair_salon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hair_salon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hair_salon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hair_salon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hair_salon] SET ARITHABORT OFF 
GO
ALTER DATABASE [hair_salon] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [hair_salon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hair_salon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hair_salon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hair_salon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hair_salon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hair_salon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hair_salon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hair_salon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hair_salon] SET  ENABLE_BROKER 
GO
ALTER DATABASE [hair_salon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hair_salon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hair_salon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hair_salon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hair_salon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hair_salon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hair_salon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hair_salon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hair_salon] SET  MULTI_USER 
GO
ALTER DATABASE [hair_salon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hair_salon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hair_salon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hair_salon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hair_salon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hair_salon] SET QUERY_STORE = OFF
GO
USE [hair_salon]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 6/18/2017 10:28:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 6/18/2017 10:28:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[location] [varchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (1, N'Noel', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (2, N'Leah', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3, N'Robyn', 3)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (4, N'Austin', 5)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (5, N'Dede', 6)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (6, N'Holly', 4)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (7, N'Greg', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (8, N'Mike', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (9, NULL, 3)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name], [location]) VALUES (1, N'AmyRose', N'Pearl')
INSERT [dbo].[stylists] ([id], [name], [location]) VALUES (2, N'Levi', N'Hawthorne')
INSERT [dbo].[stylists] ([id], [name], [location]) VALUES (3, N'Morgan', N'Alberta')
INSERT [dbo].[stylists] ([id], [name], [location]) VALUES (4, N'James', N'Alberta')
INSERT [dbo].[stylists] ([id], [name], [location]) VALUES (5, N'Joe V', N'Pearl')
INSERT [dbo].[stylists] ([id], [name], [location]) VALUES (6, N'Marissa', N'Hawthorne')
SET IDENTITY_INSERT [dbo].[stylists] OFF
USE [master]
GO
ALTER DATABASE [hair_salon] SET  READ_WRITE 
GO
