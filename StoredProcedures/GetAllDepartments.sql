USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDepartmentById]    Script Date: 01/31/2018 02:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllDepartments]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Departments 
END

