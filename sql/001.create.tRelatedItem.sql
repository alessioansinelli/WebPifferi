/****** Object:  Table [dbo].[tRelatedItem]    Script Date: 02/22/2014 06:43:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tRelatedItem](
	[tRelatedItemId] [int] IDENTITY(1,1) NOT NULL,
	[tObjectId] [int] NOT NULL,
	[tObjectRelatedId] [int] NOT NULL,
	[tObjectRelatedType] [int] NOT NULL,
	[tRelatedItemOrder] [int] NOT NULL
) ON [PRIMARY]

GO


