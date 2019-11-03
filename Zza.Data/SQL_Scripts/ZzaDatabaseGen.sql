﻿USE [Zza]
GO
/****** Object:  Table [dbo].[Conjugation]    Script Date: 03/11/2019 16:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conjugation](
	[Id] [decimal](2, 1) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Conjugation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrincipalPart]    Script Date: 03/11/2019 16:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrincipalPart](
	[Id] [uniqueidentifier] NOT NULL,
	[Present] [nvarchar](20) NULL,
	[PresentInfinitive] [nvarchar](20) NULL,
	[PerfectActive] [nvarchar](20) NULL,
	[Supine] [nvarchar](20) NULL,
	[Deponent] [bit] NULL,
	[Defective] [bit] NULL,
	[Conjugation] [decimal](2, 1) NULL,
 CONSTRAINT [PK_PrincipalParts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suffix]    Script Date: 03/11/2019 16:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suffix](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Conjugation] [decimal](2, 1) NULL,
	[Mood] [nvarchar](20) NULL,
	[Tense] [nvarchar](20) NULL,
	[Passive] [bit] NULL,
	[singular_first] [nvarchar](20) NULL,
	[singular_second] [nvarchar](20) NULL,
	[singular_third] [nvarchar](20) NULL,
	[plural_first] [nvarchar](20) NULL,
	[plural_second] [nvarchar](20) NULL,
	[plural_third] [nvarchar](20) NULL,
 CONSTRAINT [PK_Suffix] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Conjugation] ([Id], [Description]) VALUES (CAST(1.0 AS Decimal(2, 1)), N'First                         ')
GO
INSERT [dbo].[Conjugation] ([Id], [Description]) VALUES (CAST(2.0 AS Decimal(2, 1)), N'Second                        ')
GO
INSERT [dbo].[Conjugation] ([Id], [Description]) VALUES (CAST(3.0 AS Decimal(2, 1)), N'Third                         ')
GO
INSERT [dbo].[Conjugation] ([Id], [Description]) VALUES (CAST(3.5 AS Decimal(2, 1)), N'Third -iō              ')
GO
INSERT [dbo].[Conjugation] ([Id], [Description]) VALUES (CAST(4.0 AS Decimal(2, 1)), N'Fourth                        ')
GO
INSERT [dbo].[Conjugation] ([Id], [Description]) VALUES (CAST(9.0 AS Decimal(2, 1)), N'Irregular                     ')
GO
INSERT [dbo].[PrincipalPart] ([Id], [Present], [PresentInfinitive], [PerfectActive], [Supine], [Deponent], [Defective], [Conjugation]) VALUES (N'7b115ca5-2b7c-45eb-9883-3a205151c13e', N'ignōrō', N'ignōrāre', N'ignōrāvī', N'ignōrātum', 0, 0, CAST(1.0 AS Decimal(2, 1)))
GO
INSERT [dbo].[PrincipalPart] ([Id], [Present], [PresentInfinitive], [PerfectActive], [Supine], [Deponent], [Defective], [Conjugation]) VALUES (N'091a3194-665a-479f-b515-a8e8d27075d8', N'cōnor', N'cōnārī', N'cōnātus sum', N'', 1, 0, CAST(1.0 AS Decimal(2, 1)))
GO
INSERT [dbo].[PrincipalPart] ([Id], [Present], [PresentInfinitive], [PerfectActive], [Supine], [Deponent], [Defective], [Conjugation]) VALUES (N'4f619eb9-f22e-4ec3-be1b-fde697ae862a', N'inquam', N'', N'inquiī', N'', 0, 1, CAST(1.0 AS Decimal(2, 1)))
GO
SET IDENTITY_INSERT [dbo].[Suffix] ON 
GO
INSERT [dbo].[Suffix] ([Id], [Conjugation], [Mood], [Tense], [Passive], [singular_first], [singular_second], [singular_third], [plural_first], [plural_second], [plural_third]) VALUES (1, CAST(1.0 AS Decimal(2, 1)), N'Indicative', N'Present', NULL, N'ō', N'ās', N'at', N'āmus', N'ātis', N'ant')
GO
SET IDENTITY_INSERT [dbo].[Suffix] OFF
GO
ALTER TABLE [dbo].[PrincipalPart]  WITH CHECK ADD FOREIGN KEY([Conjugation])
REFERENCES [dbo].[Conjugation] ([Id])
GO
ALTER TABLE [dbo].[Suffix]  WITH CHECK ADD FOREIGN KEY([Conjugation])
REFERENCES [dbo].[Conjugation] ([Id])
GO
