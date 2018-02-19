USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateDoctor]    Script Date: 18.02.2018 23:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateDoctor]
	
	@DepartmentId int,
	@RoomID int,
	@Speciality nvarchar(100), 
	@UserId int,
	@YearsExp int
	
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Doctors] (RoomID, DepartmentId, YearsExp, Speciality, UserId)
    VALUES (@RoomID, @DepartmentId, @YearsExp, @Speciality, @UserId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
