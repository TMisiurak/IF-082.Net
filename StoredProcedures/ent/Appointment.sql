USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateAppointment]
GO

CREATE PROCEDURE [dbo].[sp_CreateAppointment]
	@PatientId int
	, @DoctorId int
	, @Description nvarchar(4000)
	, @Date datetime
	, @Status int
    
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Appointments] (PatientId, DoctorId, Description, Date, Status)
    VALUES (@PatientId, @DoctorId, @Description, @Date, @Status)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteAppointment]
GO

CREATE PROCEDURE [dbo].[sp_DeleteAppointment]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM Appointments WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllAppointments]
GO

CREATE PROCEDURE [dbo].[sp_GetAllAppointments] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Appointments]

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAppointmentByDoctorId]
GO

CREATE PROCEDURE [dbo].[sp_GetAppointmentByDoctorId]
	@DoctorId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Appointments] WHERE DoctorId = @DoctorId

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAppointmentById]
GO

CREATE PROCEDURE [dbo].[sp_GetAppointmentById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Appointments] WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateAppointment]
GO

CREATE PROCEDURE [dbo].[sp_UpdateAppointment]
	@Id int
	, @PatientId int
	, @DoctorId int
	, @Description nvarchar(4000)
	, @Date datetime
	, @Status int

	
AS

IF NOT EXISTS (SELECT 1 FROM Appointments WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].[Appointments]
		SET	[PatientId] = @PatientId
		, [DoctorId] = @DoctorId
		, [Description] = @Description
		, [Date] = @Date
		, [Status] = @Status
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO



