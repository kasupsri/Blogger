USE [BloggerDB]
GO

/****** Object:  Table [dbo].[BlogPosts]    Script Date: 15/9/2021 2:53:25 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BlogPosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](200) NULL,
	[Post] [nvarchar](500) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UpdatedTime] [datetime] NOT NULL,
	[IsPublished] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


