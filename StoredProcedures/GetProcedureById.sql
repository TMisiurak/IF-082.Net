SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetProcedureById]
	@id int
AS

BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Procedures WHERE Id = @id
END
GO
