USE [pifferietamburi]
GO
/****** Object:  StoredProcedure [dbo].[selectSingleObject]    Script Date: 02/06/2014 23.54.55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[selectSingleObject] @objectID int = null,
	@slug nvarchar(70) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT @objectID IS NULL		
		SELECT * FROM tObject where tObjectID = @objectID
	ELSE
		IF NOT @slug IS NULL
			SELECT * FROM tObject where slug = @slug
	
END

