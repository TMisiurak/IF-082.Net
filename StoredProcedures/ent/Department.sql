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

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDepartment]    Script Date: 01/31/2018 02:19:57 ******/
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

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDepartment]    Script Date: 01/31/2018 02:43:07 ******/
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



GO
/****** Object:  StoredProcedure [dbo].[sp_GetDepartmentById]    Script Date: 01/31/2018 02:39:44 ******/
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

