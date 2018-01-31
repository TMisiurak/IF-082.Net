SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteClinic]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Clinics WHERE Id = @id
	RETURN 2
END
GO
