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


USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDoctor]    Script Date: 18.02.2018 23:37:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteDoctor]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	DELETE FROM Doctors WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH


USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDoctors]    Script Date: 18.02.2018 23:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllDoctors] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Doctors]

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH


USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDoctorById]    Script Date: 18.02.2018 23:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetDoctorById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Doctors WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH


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
