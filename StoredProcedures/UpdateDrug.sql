USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateDrug]
GO

CREATE PROCEDURE [dbo].[sp_UpdateDrug]
	@Id int,
    @DrugName nvarchar(100)
	
AS

IF NOT EXISTS (SELECT 1 FROM Drugs WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].[Drugs]
		SET	[DrugName] = @DrugName
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
