USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateRole]    Script Date: 31.01.2018 23:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_CreateRole]
	@Name nvarchar(50)
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Roles] (Name) VALUES (@Name)
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO