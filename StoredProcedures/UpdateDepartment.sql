USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDepartment]    Script Date: 01/31/2018 02:31:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateDepartment]
	@Id int,
	@Name nvarchar(300),
	@ClinicId int
	AS
BEGIN
SET NOCOUNT ON;
UPDATE [dbo] .Departments
SET Name=@Name, ClinicId=@ClinicId WHERE Id = @id
    
END
