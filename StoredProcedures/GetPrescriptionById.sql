﻿USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetPrescriptionById]
GO

CREATE PROCEDURE [dbo].[sp_GetPrescriptionById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Prescriptions WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
