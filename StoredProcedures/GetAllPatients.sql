USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllPatients]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Patients
END
GO
