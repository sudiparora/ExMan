
/****** Object:  Table [dbo].[NLog_Error]    Script Date: 4/3/2018 3:04:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NLog_Error](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[Host] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Logger] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[stacktrace] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_NLogError] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

