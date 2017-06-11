USE [test]
GO

/****** Object:  Table [dbo].[users]    Script Date: 2017/06/11 22:55:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[id] [int] NOT NULL,
	[name] [nchar](20) NOT NULL,
	[kana] [nchar](20) NULL,
	[tel] [nchar](20) NULL,
	[password] [nchar](20) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

