USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreatePrescription]
GO

CREATE PROCEDURE [dbo].[sp_CreatePrescription]
    @Date datetime,
	@Description nvarchar(4000),
	@DiagnosisId int,
	@DoctorId int,
	@PatientId int,
	@AppointmentId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].Prescriptions ([Date], [Description], DiagnosisId, DoctorId, PatientId, AppointmentId)
    VALUES (@Date, @Description, @DiagnosisId, @DoctorId, @PatientId, @AppointmentId)

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

DROP PROCEDURE IF EXISTS [dbo].[sp_DeletePrescription]
GO

CREATE PROCEDURE [dbo].[sp_DeletePrescription]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM Prescriptions WHERE Id = @Id

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

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllPrescriptions]
GO

CREATE PROCEDURE [dbo].[sp_GetAllPrescriptions] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM Prescriptions

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

DROP PROCEDURE IF EXISTS [dbo].[sp_GetPrescriptionById]
GO

CREATE PROCEDURE [dbo].[sp_GetPrescriptionById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Prescriptions WHERE Id = @Id

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

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdatePrescription]
GO

CREATE PROCEDURE [dbo].[sp_UpdatePrescription]
	@Id int,
	@Date datetime,
	@Description nvarchar(4000),
	@DiagnosisId int,
	@DoctorId int,
	@PatientId int,
	@AppointmentId int
AS

IF NOT EXISTS (SELECT 1 FROM Prescriptions WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Prescriptions
		SET	[Date] = @Date, [Description] = @Description, [DiagnosisId] = @DiagnosisId,
			DoctorId = @DoctorId, [PatientId] = @PatientId, [AppointmentId] = @AppointmentId 
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
