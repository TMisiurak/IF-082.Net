SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllClinics] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Clinics
END
GO
