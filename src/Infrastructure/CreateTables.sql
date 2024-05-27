/****** Object:  Table [dbo].[Investiments]    Script Date: 26/05/2024 17:53:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Users]    Script Date: 26/05/2024 17:58:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
---// CREATE USERS TABLE
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[IsActive] [BIT] NOT NULL DEFAULT 1, 
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

---// CREATE INVESTIMENTS TABLE
CREATE TABLE [dbo].[Investiments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[Quantity] [float] NOT NULL,
	[PurchasePrice] [float] NOT NULL,
	[PurchaseDate] [datetime] NULL,
 CONSTRAINT [PK_Investiments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Investiments]  WITH CHECK ADD  CONSTRAINT [Investiments_Users_FK] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
GO

