USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateDepartment]    Script Date: 01/31/2018 02:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_DeleteDepartment]
	@Id int
	AS
BEGIN
SET NOCOUNT ON;
DELETE FROM Departments WHERE Id = @id
    
END
