USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateDepartment]    Script Date: 02/02/2018 07:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateDepartment]
	@Name nvarchar(300),
	@ClinicId int
	
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Departments] (Name, ClinicId)
    VALUES (@Name, @ClinicId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH