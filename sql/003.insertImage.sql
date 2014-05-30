-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alessio
-- Create date: 2014-02-22	
-- Description:	Insert Image
-- =============================================
CREATE PROCEDURE insertImage 
	-- Add the parameters for the stored procedure here	
	@tImageID int = null, 
	@tObjectID int = null,
	@tImageNumOrder int = null,
	@tImageTitolo nvarchar(100) = '',
	@tImageSottoTitolo nvarchar(255) = '',
	@tImagePercorso nvarchar(255),
	@tImageEstensione nvarchar(255),
	@tImageDataInserimento datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	/* INSERT IMAGE IN Table Image */
	INSERT INTO tImage (tImageID, tImageTitolo, tImageSottoTitolo, tImagePercorso, tImageEstensione, tImageDataInserimento, tObjectID, tImageNumOrder)
        VALUES
         ( @tImageID, @tImageTitolo, @tImageSottoTitolo, @tImagePercorso, @tImageEstensione, @tImageDataInserimento, @tObjectID, @tImageNumOrder ) 
         
    
    /* INSERT INTO RELATED ITEM */
    INSERT INTO tRelatedItem (tObjectId, tObjectRelatedId, tObjectRelatedType, tRelatedItemOrder)
    values (@tObjectID, @tImageID, 1, @tImageNumOrder)

END
GO
