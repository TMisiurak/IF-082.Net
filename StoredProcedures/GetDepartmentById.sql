
USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 01/31/2018 02:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetDepartmentById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Departments WHERE Id = @id
END

