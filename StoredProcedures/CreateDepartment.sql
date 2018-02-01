USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateDepartment]    Script Date: 01/31/2018 02:17:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_CreateDepartment]
	@Name nvarchar(300),
	@ClinicId int
	AS
BEGIN
SET NOCOUNT ON;
INSERT INTO [dbo].[Departments] ( [Name], [ClinicId])
    VALUES ( @Name,  @ClinicId)
    
END
