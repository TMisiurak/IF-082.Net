USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDoctor]    Script Date: 18.02.2018 23:40:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateDoctor]
	@RoomID int,
	@DepartmentId int,
	@YearsExp int,
	@Speciality nvarchar(100), 
	@UserId int,
	@Id int
AS
IF NOT EXISTS (SELECT 1 FROM Doctors WHERE Id=@Id)
BEGIN
	RETURN -1
END
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Doctors 
	SET [RoomID] = @RoomID, [DepartmentId] = @DepartmentId, [YearsExp] = @YearsExp, [Speciality] = @Speciality, [UserId] = @UserId
	WHERE Id = @Id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
