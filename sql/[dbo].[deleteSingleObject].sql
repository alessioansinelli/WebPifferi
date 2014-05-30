/****** Object:  StoredProcedure [dbo].[deleteSingleObject]    Script Date: 02/19/2014 12:39:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Alessio
-- Create date: 19-02-2014
-- Description:	Delete object by ID
-- =============================================
CREATE PROCEDURE [dbo].[deleteSingleObject]	@tObjectID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if @tObjectID > 0     
		BEGIN
		-- Insert statements for procedure here
			DELETE FROM tObject where tObjectID=@tObjectID
		END
		
END

GO


