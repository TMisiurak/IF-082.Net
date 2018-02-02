SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateClinic]
	@Address nvarchar(MAX),
	@Name nvarchar(MAX),
	@ClinicId int
AS
IF EXISTS (SELECT * FROM Clinics WHERE Id=@ClinicId)
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].Clinics SET
	[Address] = @Address, [Name] = @Name
	WHERE Id = @ClinicId
END
GO