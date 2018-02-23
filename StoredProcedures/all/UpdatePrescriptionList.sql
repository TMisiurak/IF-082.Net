USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdatePrescriptionList]
GO

CREATE PROCEDURE [dbo].[sp_UpdatePrescriptionList]
	@Id int,
	@ProcedureId int,
	@DrugId int,
	@PrescriptionId int
AS

IF NOT EXISTS (SELECT 1 FROM PrescriptionLists WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].PrescriptionLists
		SET	[ProcedureId] = @ProcedureId, DrugId = @DrugId, [PrescriptionId] = @PrescriptionId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
