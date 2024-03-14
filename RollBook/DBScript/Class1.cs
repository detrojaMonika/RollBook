USE [RollBook]
GO
/****** Object:  StoredProcedure [dbo].[StockDetails]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[StockDetails]
GO
/****** Object:  StoredProcedure [dbo].[SizeMaster_GetAll]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[SizeMaster_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[SearchData]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[SearchData]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_SelectByPK]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_SelectByPK]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_SearchData]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_SearchData]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Insert_Update]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_Insert_Update]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_GetRollNo]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_GetRollNo]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_GetDNR]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_GetDNR]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_GetByQuality]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_GetByQuality]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Filter]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_Filter]
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Delete]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[RollMaster_Delete]
GO
/****** Object:  StoredProcedure [dbo].[QualityMaster_SelectAll]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[QualityMaster_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[QualityMaster_Insert_Update]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[QualityMaster_Insert_Update]
GO
/****** Object:  StoredProcedure [dbo].[LoomMaster_SelectAll]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[LoomMaster_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[DeactiveRecords_Insert]    Script Date: 14-03-2024 19:01:59 ******/
DROP PROCEDURE [dbo].[DeactiveRecords_Insert]
GO
ALTER TABLE [dbo].[SizeMaster] DROP CONSTRAINT [DF_SizeMaster_CreatedDate]
GO
ALTER TABLE [dbo].[RollMaster] DROP CONSTRAINT [DF_RollMaster_CreatedDate]
GO
ALTER TABLE [dbo].[QualityMaster] DROP CONSTRAINT [DF_QualityMaster_CreatedDate]
GO
ALTER TABLE [dbo].[DeactiveRecords] DROP CONSTRAINT [DF_DeactiveRecords_CreatedDate]
GO
/****** Object:  Table [dbo].[SizeMaster]    Script Date: 14-03-2024 19:01:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SizeMaster]') AND type in (N'U'))
DROP TABLE [dbo].[SizeMaster]
GO
/****** Object:  Table [dbo].[RollMaster]    Script Date: 14-03-2024 19:01:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RollMaster]') AND type in (N'U'))
DROP TABLE [dbo].[RollMaster]
GO
/****** Object:  Table [dbo].[QualityMaster]    Script Date: 14-03-2024 19:01:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QualityMaster]') AND type in (N'U'))
DROP TABLE [dbo].[QualityMaster]
GO
/****** Object:  Table [dbo].[LoomMaster]    Script Date: 14-03-2024 19:01:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoomMaster]') AND type in (N'U'))
DROP TABLE [dbo].[LoomMaster]
GO
/****** Object:  Table [dbo].[DeactiveRecords]    Script Date: 14-03-2024 19:01:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeactiveRecords]') AND type in (N'U'))
DROP TABLE [dbo].[DeactiveRecords]
GO
/****** Object:  Table [dbo].[DeactiveRecords]    Script Date: 14-03-2024 19:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeactiveRecords](
	[RollID] [int] IDENTITY(1,1) NOT NULL,
	[RollNo] [nvarchar](50) NULL,
	[OpMtr] [varchar](50) NULL,
	[CbMtr] [varchar](50) NULL,
	[SizeID] [int] NULL,
	[DNR] [varchar](50) NULL,
	[QW] [varchar](50) NULL,
	[NW] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[QualityID] [int] NULL,
	[LoomID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoomMaster]    Script Date: 14-03-2024 19:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoomMaster](
	[LoomID] [int] IDENTITY(1,1) NOT NULL,
	[LoomNo] [int] NULL,
 CONSTRAINT [PK_LoomMaster] PRIMARY KEY CLUSTERED 
(
	[LoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QualityMaster]    Script Date: 14-03-2024 19:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityMaster](
	[QualityID] [int] IDENTITY(1,1) NOT NULL,
	[QualityName] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_QualityMaster] PRIMARY KEY CLUSTERED 
(
	[QualityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RollMaster]    Script Date: 14-03-2024 19:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RollMaster](
	[RollID] [int] IDENTITY(1,1) NOT NULL,
	[RollNo] [nvarchar](50) NULL,
	[OpMtr] [varchar](50) NULL,
	[CbMtr] [varchar](50) NULL,
	[SizeID] [int] NULL,
	[DNR] [varchar](50) NULL,
	[QW] [varchar](50) NULL,
	[NW] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[QualityID] [int] NULL,
	[LoomID] [int] NULL,
 CONSTRAINT [PK_RollMaster] PRIMARY KEY CLUSTERED 
(
	[RollID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SizeMaster]    Script Date: 14-03-2024 19:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SizeMaster](
	[SizeID] [int] IDENTITY(1,1) NOT NULL,
	[Size] [varchar](50) NULL,
	[TW] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_SizeMaster] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DeactiveRecords] ON 
GO
INSERT [dbo].[DeactiveRecords] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1, N'324', N'334', N'3442', 1, N'2234', N'233', N'232.1', CAST(N'2023-08-08T19:10:51.290' AS DateTime), 2, 2)
GO
INSERT [dbo].[DeactiveRecords] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1002, N'a-5001', N'63735', N'65436', 1, N'3.25', N'138.3', N'137.4', CAST(N'2024-02-14T20:09:24.340' AS DateTime), 1, 2)
GO
INSERT [dbo].[DeactiveRecords] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1013, N'H-2947', N'17510', N'14831', 3, N'3', N'189.4', N'188.2', CAST(N'2024-02-21T17:17:58.370' AS DateTime), 2, 27)
GO
INSERT [dbo].[DeactiveRecords] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1014, N'H-2949', N'86749', N'82900', 1, N'2.4', N'180.3', N'179.4', CAST(N'2024-02-21T17:17:58.370' AS DateTime), 2, 22)
GO
INSERT [dbo].[DeactiveRecords] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1066, N'N-4', N'72345', N'23456', 3, N'2.5', N'123', N'121.8', CAST(N'2024-02-27T19:42:58.603' AS DateTime), 2, 1)
GO
INSERT [dbo].[DeactiveRecords] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1067, N'N-5', N'23456', N'33333', 3, N'2.5', N'123', N'121.8', CAST(N'2024-02-27T19:42:58.603' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[DeactiveRecords] OFF
GO
SET IDENTITY_INSERT [dbo].[LoomMaster] ON 
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1, 1)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (2, 2)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (3, 3)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (4, 4)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (5, 5)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (6, 6)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (7, 7)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (8, 8)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (9, 9)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (10, 10)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (11, 11)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (12, 12)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (13, 13)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (14, 14)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (15, 15)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (16, 16)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (17, 17)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (18, 18)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (19, 19)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (20, 20)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (21, 21)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (22, 22)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (23, 23)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (24, 24)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (25, 25)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (26, 26)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (27, 27)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (28, 28)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (29, 29)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (30, 30)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (31, 31)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (32, 32)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (33, 33)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (34, 34)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (35, 35)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (36, 36)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (37, 37)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (38, 38)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (39, 39)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (40, 40)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (41, 41)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (42, 42)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (43, 43)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (44, 44)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (45, 45)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (46, 46)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (47, 47)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (48, 48)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (49, 49)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (50, 50)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (51, 51)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (52, 52)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (53, 53)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (54, 54)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (55, 55)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (56, 56)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (57, 57)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (58, 58)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (59, 59)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (60, 60)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1002, 61)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1003, 62)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1004, 63)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1005, 64)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1006, 65)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1007, 66)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1008, 67)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1009, 68)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1010, 69)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1011, 70)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1012, 71)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1013, 72)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1014, 73)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1015, 74)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1016, 75)
GO
INSERT [dbo].[LoomMaster] ([LoomID], [LoomNo]) VALUES (1017, 76)
GO
SET IDENTITY_INSERT [dbo].[LoomMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[QualityMaster] ON 
GO
INSERT [dbo].[QualityMaster] ([QualityID], [QualityName], [CreatedDate]) VALUES (1, N'Gold', CAST(N'2023-08-06T15:54:29.430' AS DateTime))
GO
INSERT [dbo].[QualityMaster] ([QualityID], [QualityName], [CreatedDate]) VALUES (2, N'Silver', CAST(N'2023-08-06T15:54:35.150' AS DateTime))
GO
INSERT [dbo].[QualityMaster] ([QualityID], [QualityName], [CreatedDate]) VALUES (3, N'Natural', CAST(N'2023-08-06T15:54:42.840' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[QualityMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[RollMaster] ON 
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (2, N'G-3523', N'22334', N'34345', 1, N'4', N'166.7', N'165.8', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 4)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (3, N'G-3524', N'48654', N'4267', 3, N'4', N'200.2', N'199', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 7)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (4, N'G-3525', N'66928', N'4267', 3, N'4', N'188.6', N'187.4', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 35)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (5, N'G-3526', N'2111', N'4267', 5, N'3', N'230.1', N'228.7', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 9)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (6, N'G-3527', N'10973', N'4267', 6, N'3', N'262', N'260.5', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 33)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (7, N'G-3528', N'29777', N'4267', 1, N'4', N'158.1', N'157.2', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 31)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (8, N'G-3529', N'10323', N'4267', 2, N'4', N'187.2', N'186.2', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 30)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (9, N'G-3530', N'4734', N'4267', 1, N'3', N'180.1', N'179.2', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 2, 13)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1003, N'H-2932', N'51433', N'4267', 3, N'5', N'194.6', N'193.4', CAST(N'2024-02-17T23:17:14.567' AS DateTime), 2, 19)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1004, N'H-2933', N'2795', N'4267', 3, N'5', N'186.2', N'185', CAST(N'2024-02-17T23:22:56.693' AS DateTime), 2, 48)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1005, N'H-2934', N'44452', N'4267', 1, N'3', N'197.4', N'196.5', CAST(N'2024-02-17T23:25:04.770' AS DateTime), 1, 13)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1006, N'H-2940', N'93311', N'4267', 4, N'3', N'254.6', N'253.3', CAST(N'2024-02-17T23:30:46.143' AS DateTime), 2, 42)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1007, N'H-2941', N'4267', N'4267', 1, N'5', N'200.2', N'199.3', CAST(N'2024-02-17T23:36:26.870' AS DateTime), 2, 4)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1008, N'H-2942', N'68625', N'4267', 1, N'3', N'197', N'196.1', CAST(N'2024-02-17T23:37:28.313' AS DateTime), 2, 5)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1009, N'H-2943', N'71250', N'4267', 1, N'2.4', N'205.6', N'204.7', CAST(N'2024-02-17T23:39:50.087' AS DateTime), 2, 6)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1010, N'H-2944', N'5398', N'4267', 3, N'2.4', N'223.8', N'222.6', CAST(N'2024-02-17T23:41:53.717' AS DateTime), 2, 8)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1011, N'H-2945', N'9344', N'4267', 1, N'3', N'203.5', N'202.6', CAST(N'2024-02-17T23:43:59.080' AS DateTime), 2, 10)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1012, N'H-2946', N'58203', N'4267', 6, N'3', N'281.8', N'280.3', CAST(N'2024-02-18T00:01:05.007' AS DateTime), 2, 33)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1015, N'H-2951', N'27684', N'4267', 3, N'2.4', N'187.8', N'186.6', CAST(N'2024-02-18T00:12:25.207' AS DateTime), 2, 59)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1016, N'H-2952', N'45115', N'4267', 5, N'2.4', N'260.5', N'259.1', CAST(N'2024-02-18T00:14:09.540' AS DateTime), 2, 57)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1017, N'H-2953', N'48869', N'4267', 2, N'3', N'219.2', N'218.2', CAST(N'2024-02-18T00:15:37.613' AS DateTime), 2, 56)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1018, N'H-2954', N'92997', N'4267', 1, N'3', N'182.1', N'181.2', CAST(N'2024-02-18T00:17:05.983' AS DateTime), 2, 49)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1019, N'H-2955', N'47707', N'4267', 3, N'2.4', N'244.7', N'243.5', CAST(N'2024-02-18T00:19:02.893' AS DateTime), 2, 47)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1020, N'H-2957', N'22063', N'4267', 3, N'3', N'225.2', N'224', CAST(N'2024-02-18T00:21:52.100' AS DateTime), 2, 43)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1021, N'H-2961', N'73567', N'4267', 3, N'3', N'193.8', N'192.6', CAST(N'2024-02-18T00:28:34.780' AS DateTime), 1, 58)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1022, N'H-2935', N'44069', N'4267', 1002, N'2.4', N'95.2', N'93.8', CAST(N'2024-02-21T17:07:31.087' AS DateTime), 2, 1007)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1023, N'H-2941', N'34345', N'22322', 1, N'5', N'200.2', N'199.3', CAST(N'2024-02-21T23:36:26.870' AS DateTime), 2, 4)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1024, N'A-1001', N'65436', N'63735', 2, N'3.25', N'138.2', N'1.5', CAST(N'2024-02-21T23:32:26.420' AS DateTime), 3, 1)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1025, N'A-1002', N'65436', N'63735', 2, N'3.25', N'138.2', N'1.5', CAST(N'2024-02-21T23:34:12.103' AS DateTime), 2, 4)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1026, N'M-2941', N'12345', N'22322', 1, N'5', N'200.2', N'199.3', CAST(N'2024-02-19T00:00:00.000' AS DateTime), 2, 3)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1027, N'M-1003', N'99899', N'63735', 2, N'3.25', N'138.2', N'1.5', CAST(N'2024-02-20T00:00:00.000' AS DateTime), 2, 3)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1029, N'M-1004', N'63735', N'63735', 2, N'3.25', N'138.2', N'1.5', CAST(N'2024-02-21T23:47:59.040' AS DateTime), 2, 3)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1062, N'M-9999', N'63735', N'12346', 2, N'2.5', N'212', N'211', CAST(N'2024-02-26T22:23:31.983' AS DateTime), 1, 1)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1063, N'N-1', N'63735', N'45678', 3, N'3.2', N'124', N'122.8', CAST(N'2024-02-26T22:42:21.263' AS DateTime), 1, 1)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1064, N'N-2', N'95699', N'89899', 4, N'3.5', N'134', N'132.7', CAST(N'2024-02-26T22:47:09.623' AS DateTime), 1, 1)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1065, N'N-3', N'89899', N'72345', 1, N'2.5', N'213', N'212.1', CAST(N'2024-02-27T19:39:37.243' AS DateTime), 1, 1)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1068, N'N-4', N'72345', N'23441', 2, N'2.5', N'122', N'121', CAST(N'2024-03-02T18:48:43.210' AS DateTime), 1, 1)
GO
INSERT [dbo].[RollMaster] ([RollID], [RollNo], [OpMtr], [CbMtr], [SizeID], [DNR], [QW], [NW], [CreatedDate], [QualityID], [LoomID]) VALUES (1069, N'N-5', N'111111', N'23452', 3, N'3.5', N'234', N'232.8', CAST(N'2024-03-02T18:50:01.930' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[RollMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[SizeMaster] ON 
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (1, N'19', N'0.9', CAST(N'2023-06-22T18:02:52.093' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (2, N'22', N'1', CAST(N'2023-06-22T18:02:56.850' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (3, N'24', N'1.2', CAST(N'2023-06-22T18:03:06.530' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (4, N'26', N'1.3', CAST(N'2023-06-22T18:03:15.210' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (5, N'27', N'1.4', CAST(N'2023-06-22T18:03:25.703' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (6, N'30', N'1.5', CAST(N'2023-06-22T18:03:35.840' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (7, N'32', N'1.6', CAST(N'2023-06-22T18:03:43.830' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (8, N'34', N'1.7', CAST(N'2023-06-22T18:03:53.630' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (9, N'36', N'1.9', CAST(N'2023-06-22T18:04:13.487' AS DateTime))
GO
INSERT [dbo].[SizeMaster] ([SizeID], [Size], [TW], [CreatedDate]) VALUES (1002, N'28', N'1.4', CAST(N'2024-02-21T17:05:07.033' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SizeMaster] OFF
GO
ALTER TABLE [dbo].[DeactiveRecords] ADD  CONSTRAINT [DF_DeactiveRecords_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[QualityMaster] ADD  CONSTRAINT [DF_QualityMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[RollMaster] ADD  CONSTRAINT [DF_RollMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[SizeMaster] ADD  CONSTRAINT [DF_SizeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[DeactiveRecords_Insert]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeactiveRecords_Insert] 
	@RollID Varchar(200)
AS

SET IDENTITY_INSERT DeactiveRecords ON;

INSERT INTO DeactiveRecords (RollID, RollNo, OpMtr, CbMtr, SizeID, DNR, QW, NW, QualityID, LoomID)
  SELECT RollID, RollNo, OpMtr, CbMtr, SizeID, DNR, QW, NW, QualityID, LoomID
  FROM RollMaster
  WHERE RollID IN(SELECT value FROM STRING_SPLIT(@RollID, ','))

  DELETE FROM RollMaster
  WHERE RollID IN (SELECT value FROM STRING_SPLIT(@RollID, ','));

SET IDENTITY_INSERT DeactiveRecords OFF;
GO
/****** Object:  StoredProcedure [dbo].[LoomMaster_SelectAll]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoomMaster_SelectAll]
AS
BEGIN
	SELECT LoomID ,LoomNo FROM LoomMaster
END
GO
/****** Object:  StoredProcedure [dbo].[QualityMaster_Insert_Update]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[QualityMaster_Insert_Update]
	@QualityName varchar(50)
AS

INSERT INTO [dbo].[QualityMaster]
           (
				[QualityName]
		   )
     VALUES
           (
				@QualityName
		   )
GO
/****** Object:  StoredProcedure [dbo].[QualityMaster_SelectAll]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[QualityMaster_SelectAll]
AS
BEGIN
	SELECT QualityID ,QualityName FROM QualityMaster
END
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Delete]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RollMaster_Delete]
	@RollID Varchar(200)
AS
DELETE FROM RollMaster
WHERE RollID IN (SELECT value FROM STRING_SPLIT(@RollID, ','));
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Filter]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RollMaster_Filter] --0,'3','2024-03-10'
	@QualityID Int,
	@DNR varchar(50) NULL,
	@FromDate DateTime NULL,
	@ToDate DateTime NULL
AS
IF (@FromDate != convert(varchar(10),GETDATE(), 120) AND @QualityID=0 AND @DNR='0')
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,CbMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE (convert(varchar(10),RollMaster.CreatedDate, 120) >= DATEADD(d,DATEDIFF(d, 0, @FromDate), 0)
	AND  convert(varchar(10),RollMaster.CreatedDate, 120) < DATEADD(d, DATEDIFF(d, 0, @ToDate) + 1, 0))
	ORDER BY RollMaster.CreatedDate DESC
END
ELSE IF(@FromDate != convert(varchar(10),GETDATE(), 120) AND @QualityID=0 AND @DNR!='0')
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,CbMtr
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE (RollMaster.DNR=@DNR AND 
	(convert(varchar(10),RollMaster.CreatedDate, 120) >= DATEADD(d,DATEDIFF(d, 0, @FromDate), 0)
	AND  convert(varchar(10),RollMaster.CreatedDate, 120) < DATEADD(d, DATEDIFF(d, 0, @ToDate) + 1, 0)))
	ORDER BY RollMaster.CreatedDate DESC
END
ELSE IF(@FromDate != convert(varchar(10),GETDATE(), 120) AND @QualityID!=0 AND @DNR='0')
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,CbMtr
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE ((RollMaster.QualityID=@QualityID) AND 
	(convert(varchar(10),RollMaster.CreatedDate, 120) >= DATEADD(d,DATEDIFF(d, 0, @FromDate), 0)
	AND  convert(varchar(10),RollMaster.CreatedDate, 120) < DATEADD(d, DATEDIFF(d, 0, @ToDate) + 1, 0)))
	ORDER BY RollMaster.CreatedDate DESC
END
ELSE IF(@FromDate = convert(varchar(10),GETDATE(), 120) AND @QualityID != 0 AND @DNR != '0')
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,CbMtr
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE ((RollMaster.QualityID=@QualityID) AND (RollMaster.DNR=@DNR))
	ORDER BY RollMaster.CreatedDate DESC
END
ELSE IF(@FromDate = convert(varchar(10),GETDATE(), 120) AND @QualityID != 0 AND @DNR = '0')
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,CbMtr
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE (RollMaster.QualityID=@QualityID)
	ORDER BY RollMaster.CreatedDate DESC
END
ELSE IF(@FromDate = convert(varchar(10),GETDATE(), 120) AND @QualityID = 0 AND @DNR != '0')
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,CbMtr
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE (RollMaster.DNR=@DNR)
	ORDER BY RollMaster.CreatedDate DESC
END
ELSE IF(@FromDate != convert(varchar(10),GETDATE(), 120) AND @QualityID != 0 AND @DNR != '0')
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,CbMtr
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE (RollMaster.DNR=@DNR AND RollMaster.QualityID=@QualityID AND 
	(convert(varchar(10),RollMaster.CreatedDate, 120) >= DATEADD(d,DATEDIFF(d, 0, @FromDate), 0)
	AND  convert(varchar(10),RollMaster.CreatedDate, 120) < DATEADD(d, DATEDIFF(d, 0, @ToDate) + 1, 0)))
	ORDER BY RollMaster.CreatedDate DESC
END
ELSE 
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,CbMtr
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	WHERE ((RollMaster.QualityID=@QualityID)
	AND (RollMaster.DNR=@DNR)
	AND (convert(varchar(10),RollMaster.CreatedDate, 120) >= DATEADD(d,DATEDIFF(d, 0, @FromDate), 0)
	AND  convert(varchar(10),RollMaster.CreatedDate, 120) < DATEADD(d, DATEDIFF(d, 0, @ToDate) + 1, 0)))
	ORDER BY RollMaster.CreatedDate DESC
END

GO
/****** Object:  StoredProcedure [dbo].[RollMaster_GetByQuality]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RollMaster_GetByQuality]
	@QualityID Int
AS
IF (@QualityID=0)
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,CbMtr
		,Size
		,DNR
		,QW
		,TW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
END
ELSE
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,CbMtr
		,Size
		,DNR
		,QW
		,TW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	WHERE RollMaster.QualityID=@QualityID
END

GO
/****** Object:  StoredProcedure [dbo].[RollMaster_GetDNR]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RollMaster_GetDNR]
AS
SELECT DISTINCT DNR FROM RollMaster ORDER BY DNR ASC

GO
/****** Object:  StoredProcedure [dbo].[RollMaster_GetRollNo]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 26-02-2024
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RollMaster_GetRollNo]
	
AS
BEGIN
	SELECT TOP 1 RollNo FROM RollMaster ORDER BY RollID DESC
END
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_Insert_Update]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[RollMaster_Insert_Update] 0,'M-1003','65436','63735',2,'3.25','138.2','1.5','2','3'
CREATE PROCEDURE [dbo].[RollMaster_Insert_Update]
	@RollID INT,
	@RollNo NVARCHAR(50),
	@OpMtr VARCHAR(50) NULL,
	@CbMtr VARCHAR(50),
	@SizeID INT,
	@DNR VARCHAR(50),
	@QW VARCHAR(50),
	@NW VARCHAR(50),
	@QualityID INT,
	@LoomID INT

	--@OUTVAL Int OUTPUT,
	--@OUTMESSAGE VARCHAR(50) OUTPUT
AS
BEGIN
	IF(@RollID = 0)
	BEGIN
		INSERT INTO RollMaster
           (RollNo
           ,OpMtr
           ,CbMtr
           ,SizeID
           ,DNR
           ,QW
           ,NW
		   ,QualityID
		   ,LoomID)
		VALUES
           (
				@RollNo ,
				(SELECT TOP 1 CbMtr FROM RollMaster WHERE LoomID=@LoomID ORDER BY CreatedDate DESC ),
				@CbMtr ,
				@SizeID ,
				@DNR ,
				@QW ,
				@NW ,
				@QualityID ,
				@LoomID 
		   )
		--SET @OUTVAL = 1
		--SET @OUTMESSAGE = 'Record Saved Succefully.'
		--Update RollMaster set OpMtr=(select CbMtr from RollMaster
		--where DAY(CreatedDate)= DAY(GETDATE())-1 AND LoomID=@LoomID )
		--Where LoomID=@LoomID  AND DAY(CreatedDate)=DAY(GETDATE())
		--Update RollMaster set OpMtr=(select CbMtr from RollMaster)
	END
	ELSE
	BEGIN
		UPDATE RollMaster
		SET		RollNo = @RollNo ,
				OpMtr = @OpMtr ,
				CbMtr = @CbMtr ,
				SizeID = @SizeID ,
				DNR = @DNR ,
				QW = @QW ,
				NW = @NW ,
				QualityID = @QualityID ,
				LoomID = @LoomID 
		WHERE RollID=@RollID
		--SET @OUTVAL = 1
		--SET @OUTMESSAGE = 'Record Updated Succefully.'
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_SearchData]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RollMaster_SearchData] --0,'3',null
	@QualityID INT = 0,
	@DNR VARCHAR(50) = NULL,
	@FromDate DateTime = NULL,
	@ToDate DateTime = NULL
AS

BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,CbMtr
		,SizeMaster.Size
		,SizeMaster.TW
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,QualityMaster.QualityName
		,LoomMaster.LoomNo
	FROM RollMaster
	INNER JOIN QualityMaster
	ON QualityMaster.QualityID=RollMaster.QualityID
	LEFT JOIN LoomMaster
	ON LoomMaster.LoomID=RollMaster.LoomID
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	--WHERE convert(varchar(10),RollMaster.CreatedDate, 120) = @EntryDate
	WHERE
        (@FromDate IS NULL OR convert(varchar(10),RollMaster.CreatedDate, 120) >= @FromDate)
        AND (@ToDate IS NULL OR convert(varchar(10),RollMaster.CreatedDate, 120) <= @ToDate)
        AND (@QualityID IS NULL OR RollMaster.QualityID = @QualityID)
        AND (@DNR IS NULL OR RollMaster.DNR = @DNR)
	ORDER BY RollMaster.CreatedDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[RollMaster_SelectByPK]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<monika detroja>
-- Create date: <19-07-2022>
-- Description:	<Select all the records by id>
-- =============================================
CREATE PROCEDURE [dbo].[RollMaster_SelectByPK] 
	-- Add the parameters for the stored procedure here
	@RollID	Int
AS
BEGIN
	SELECT
		RollNo 
		,RollID
		,OpMtr
		,CbMtr
		,SizeMaster.TW
		,RollMaster.SizeID
		,DNR
		,QW
		,NW
		,RollMaster.QualityID
		,LoomID
	FROM RollMaster
	LEFT JOIN SizeMaster
	ON SizeMaster.SizeID=RollMaster.SizeID
	Where RollID=@RollID
END

GO
/****** Object:  StoredProcedure [dbo].[SearchData]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchData]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @ID NVARCHAR(255) = NULL,
    @Name NVARCHAR(255) = NULL
AS

BEGIN
	IF (@StartDate = convert(varchar(10),GETDATE(), 120))
	begin
		SET @StartDate = NULL
		SET @EndDate=NULL;
	end
        
    SELECT *
    FROM rollmaster -- Replace YourTableName with the actual name of your table
    WHERE
        (@StartDate IS NULL OR convert(varchar(10),RollMaster.CreatedDate, 120) >= @StartDate)
        AND (@EndDate IS NULL OR convert(varchar(10),RollMaster.CreatedDate, 120) <= @EndDate)
        AND (@ID IS NULL OR DNR = @ID)
        AND (@Name IS NULL OR RollNo LIKE '%' + @Name + '%');
END;

--EXEC SearchData @StartDate = '2024-02-17', @EndDate = '2024-02-18';
--EXEC SearchData @StartDate = '2024-02-17', @EndDate = '2024-02-18', @ID = 5;
--EXEC SearchData @StartDate = '2024-03-07', @EndDate = '2024-03-07', @ID = 5, @Name = 'H-2932';
--EXEC SearchData @StartDate = '2024-02-17', @EndDate = '2024-02-18',  @Name = 'H-2932';
GO
/****** Object:  StoredProcedure [dbo].[SizeMaster_GetAll]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SizeMaster_GetAll]
AS
SELECT SizeID,Size,TW FROM SizeMaster ORDER BY Size ASC

GO
/****** Object:  StoredProcedure [dbo].[StockDetails]    Script Date: 14-03-2024 19:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from Sizemaster
--select Distinct DNR,SizeID from RollMaster
CREATE PROCEDURE [dbo].[StockDetails]

AS

SELECT
    Size,
    DNR,
    QualityName,
    LoomNo,
    SUM(CONVERT(FLOAT, NW)) AS Quantity
FROM
    RollMaster
INNER JOIN
    SizeMaster ON sizemaster.SizeID = rollmaster.SizeID
INNER JOIN
    QualityMaster ON QualityMaster.QualityID = rollmaster.QualityID
INNER JOIN
    LoomMaster ON LoomMaster.LoomID = rollmaster.LoomID
GROUP BY
    Size,
    DNR,
    QualityName,
    LoomNo;
GO
