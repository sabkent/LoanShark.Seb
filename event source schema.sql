USE [LoanShark.Origination]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 17/01/2014 21:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [uniqueidentifier] NOT NULL,
	[StreamId] [uniqueidentifier] NOT NULL,
	[Sequence] [int] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[EventType] [nvarchar](255) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stream]    Script Date: 17/01/2014 21:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stream](
	[StreamId] [uniqueidentifier] NOT NULL,
	[CurrentSequence] [int] NOT NULL,
 CONSTRAINT [PK_Stream] PRIMARY KEY CLUSTERED 
(
	[StreamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
