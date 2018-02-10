  --\source\repos\IF-082.Net\StoredProcedures\CreateDiagnosis.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateDiagnosis]
GO

CREATE PROCEDURE [dbo].[sp_CreateDiagnosis]
	@DiagnosisName nvarchar(100)
	, @Description nvarchar(4000)
    
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Diagnoses] (DiagnosisName, Description)
    VALUES (@DiagnosisName, @Description)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\CreateDrug.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateDrug]
GO

CREATE PROCEDURE [dbo].[sp_CreateDrug]
	@DrugName nvarchar(100)
    
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Drugs] (DrugName)
    VALUES (@DrugName)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\CreatePatient.sql
USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateClinic]    Script Date: 31.01.2018 22:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreatePatient]
	@UserId int
AS
BEGIN TRY
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	INSERT INTO [dbo].[patients] (UserId) VALUES (@UserId)
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\CreatePayment.sql
USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateClinic]    Script Date: 31.01.2018 22:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreatePayment]
	@PatientId int,
	@PaymentDate date,
	@PaymentType nvarchar(10),
	@PrescriptionId int,
	@sum int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Payments]  (PatientId, PaymentDate,PaymentType, PrescriptionId, sum)
	 VALUES (@PatientId, @PaymentDate, @PaymentType, @PrescriptionId, @sum)
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\CreatePrescription.sql
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
	@PatientId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].Prescriptions ([Date], [Description], DiagnosisId, DoctorId, PatientId)
    VALUES (@Date, @Description, @DiagnosisId, @DoctorId, @PatientId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\CreateProcedure.sql
USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateProcedure]    Script Date: 01.02.2018 13:15:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateProcedure]
	 @Name nvarchar(120),
	 @Price decimal,
	 @Room int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Procedures] (Name, Price, Room)
    VALUES (@Name, @Price, @Room)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
  --\source\repos\IF-082.Net\StoredProcedures\CreateRole.sql
/****** Object:  StoredProcedure [dbo].[sp_CreateRole]    Script Date: 31.01.2018 23:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateRole]
	@Name nvarchar(50)
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Roles] (Name) VALUES (@Name)
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\CreateRoom.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateRoom]
	@Name nvarchar(100),
	@Number int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Rooms] (Name, Number) VALUES (@Name, @Number)
END
  --\source\repos\IF-082.Net\StoredProcedures\CreateUser.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateUser]
GO

CREATE PROCEDURE [dbo].[sp_CreateUser]
	@Address nvarchar(300),
    @BirthDay date,
	@Email nvarchar(64),
	@FullName nvarchar(300),
	@Image nvarchar(2000),
	@Password nvarchar(512),
	@PhoneNumber nvarchar(10),
	@Sex nvarchar(3),
	@RoleId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].Users (Address, BirthDay, Email, FullName, Image, Password, PhoneNumber, Sex, RoleId)
    VALUES (@Address, @BirthDay, @Email, @FullName, @Image, @Password, @PhoneNumber, @Sex, @RoleId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\DeleteClinic.sql
USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteClinic]    Script Date: 31.01.2018 23:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteClinic]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Clinics WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\DeleteDepartment.sql
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
  --\source\repos\IF-082.Net\StoredProcedures\DeleteDiagnoses.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteDiagnosis]
GO

CREATE PROCEDURE [dbo].[sp_DeleteDiagnosis]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM Diagnoses WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\DeleteDrug.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteDrug]
GO

CREATE PROCEDURE [dbo].[sp_DeleteDrug]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM Drugs WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\DeletePatient.sql
USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteClinic]    Script Date: 31.01.2018 23:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePatient]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Patients WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\DeletePayment.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePayment]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Payments WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\DeletePrescription.sql
USE [ClinicDB]
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
  --\source\repos\IF-082.Net\StoredProcedures\DeleteProcedure.sql
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteProcedure]
GO

CREATE PROCEDURE [dbo].[sp_DeleteProcedure] 
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	DELETE FROM Procedures WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

  --\source\repos\IF-082.Net\StoredProcedures\DeleteRole.sql
USE [ClinicDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteRole]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	DELETE FROM Roles WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\DeleteRoom.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteRoom]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Rooms WHERE Id = @id
	RETURN 2
END
  --\source\repos\IF-082.Net\StoredProcedures\DeleteUser.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteUser]
GO

CREATE PROCEDURE [dbo].[sp_DeleteUser]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM Users WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllClinics.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllClinics]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Clinics
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllDepartments.sql
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

  --\source\repos\IF-082.Net\StoredProcedures\GetAllDiagnoses.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllDiagnoses]
GO

CREATE PROCEDURE [dbo].[sp_GetAllDiagnoses] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Diagnoses]

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllDrugs.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllDrugs]
GO

CREATE PROCEDURE [dbo].[sp_GetAllDrugs] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Drugs]

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllPatients.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllPatients]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Patients
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllPayments.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllPayments]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Payments
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllPrescriptions.sql
USE [ClinicDB]
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
  --\source\repos\IF-082.Net\StoredProcedures\GetAllProcedures.sql
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [[dbo].[sp_GetAllProcedures]
GO

CREATE PROCEDURE [dbo].[sp_GetAllProcedures]
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM Procedures
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllRoles.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllRoles] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM Roles
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetAllRooms.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllRooms]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Rooms
END
  --\source\repos\IF-082.Net\StoredProcedures\GetAllUsers.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllUsers]
GO

CREATE PROCEDURE [dbo].[sp_GetAllUsers] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM Users

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetClinicById.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetClinicById]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].Clinics WHERE Id = @id
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetDepartmentById.sql

USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 01/31/2018 02:39:44 ******/
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

  --\source\repos\IF-082.Net\StoredProcedures\GetDiagnosisById.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetDiagnosisById]
GO

CREATE PROCEDURE [dbo].[sp_GetDiagnosisById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Diagnoses] WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetDrugById.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetDrugById]
GO

CREATE PROCEDURE [dbo].[sp_GetDrugById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Drugs WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetPatientById.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPatientById]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].Patients WHERE Id = @id
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetPaymentById.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPaymentById]
	@id int
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT * FROM [dbo].Payments WHERE Id = @id
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetPrescriptionById.sql
USE [ClinicDB]
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
  --\source\repos\IF-082.Net\StoredProcedures\GetProcedureById.sql
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetProcedureById]
	@id int
AS

BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Procedures WHERE Id = @id
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetRoleById.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetRoleById]
GO

CREATE PROCEDURE [dbo].[sp_GetRoleById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Roles WHERE Id = @id
END
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetRoomById.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRoomById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Rooms WHERE Id = @id
END
  --\source\repos\IF-082.Net\StoredProcedures\GetUserByEmail.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetUserByEmail]
GO

CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
	@Email nvarchar(64)
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Users WHERE Email = @Email

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\GetUserById.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetUserById]
GO

CREATE PROCEDURE [dbo].[sp_GetUserById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Users WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\UpdateClinic.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateClinic]
GO
CREATE PROCEDURE [dbo].[sp_UpdateClinic]
	@Address nvarchar(MAX),
	@Name nvarchar(MAX),
	@Id int
AS
IF NOT EXISTS (SELECT 1 FROM Clinics WHERE Id=@Id)
BEGIN
	RETURN -1
END
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Clinics SET
	[Address] = @Address, [Name] = @Name
	WHERE Id = @Id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\UpdateDepartment.sql
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
  --\source\repos\IF-082.Net\StoredProcedures\UpdateDiagnosis.sql

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateDiagnosis]
GO

CREATE PROCEDURE [dbo].[sp_UpdateDiagnosis]
	@Id int
	, @DiagnosisName nvarchar(100)
	, @Description nvarchar(4000)
	
AS

IF NOT EXISTS (SELECT 1 FROM Diagnoses WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].[Diagnoses]
		SET	[DiagnosisName] = @DiagnosisName
		, [Description] = @Description
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\UpdateDrug.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateDrug]
GO

CREATE PROCEDURE [dbo].[sp_UpdateDrug]
	@Id int,
    @DrugName nvarchar(100)
	
AS

IF NOT EXISTS (SELECT 1 FROM Drugs WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].[Drugs]
		SET	[DrugName] = @DrugName
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\UpdatePatient.sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_UpdatePatient]
	@UserId int,
	@Id int
AS
IF NOT EXISTS (SELECT 1 FROM Patients WHERE Id=@Id)
BEGIN
	RETURN -1
END
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Patients SET
	[UserId]=@UserId
	WHERE Id = @Id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\UpdatePayment.sql
USE [ClinicDB]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdatePayment]
	@PatientId int,
	@PaymentDate date,
	@PaymentType nvarchar(10),
	@PrescriptionId int,
	@sum int,
	@Id int
AS
IF NOT EXISTS (SELECT 1 FROM Payments WHERE Id=@Id)
BEGIN
	RETURN -1
END
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Payments SET
	[PatientId]=@PatientId, [PaymentDate]=@PaymentDate, [PaymentType]=@PaymentType, [PrescriptionId] =@PrescriptionId, [sum] = @sum
	WHERE Id = @Id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\UpdatePrescription.sql
USE [ClinicDB]
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
	@PatientId int
AS

IF NOT EXISTS (SELECT 1 FROM Prescriptions WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Prescriptions
		SET	[Date] = @Date, [Description] = @Description, [DiagnosisId] = @DiagnosisId,
			DoctorId = @DoctorId, [PatientId] = @PatientId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\UpdateRole.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateRole]
GO

CREATE PROCEDURE [dbo].[sp_UpdateRole]
	@Name nvarchar(30),
	@Id int
AS

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY	
	SET NOCOUNT ON;

	UPDATE [dbo].Roles SET
		[Name] = @Name WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\UpdateUser.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateUser]
GO

CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@Address nvarchar(300),
    @BirthDay date,
	@Email nvarchar(64),
	@FullName nvarchar(300),
	@Image nvarchar(2000),
	@Password nvarchar(512),
	@PhoneNumber nvarchar(10),
	@Sex nvarchar(3),
	@RoleId int,
	@Id int
AS

IF NOT EXISTS (SELECT 1 FROM Users WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Users
		SET	[Address] = @Address, [BirthDay] = @BirthDay, [Email] = @Email, [FullName] = @FullName,
			[Image] = @Image, [Password] = @Password, [PhoneNumber] = @PhoneNumber, [Sex] = @Sex, [RoleId] = @RoleId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
  --\source\repos\IF-082.Net\StoredProcedures\CreateClinic.sql
USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateClinic]    Script Date: 31.01.2018 22:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateClinic]
	@Name nvarchar(200),
	@Address nvarchar(300)
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Clinics] (Name, Address) VALUES (@Name, @Address)
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO  --\source\repos\IF-082.Net\StoredProcedures\CreateDepartment.sql
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
	, @CabinetId int
	, @PrescriptionId int
    
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Appointments] (PatientId, DoctorId, Description, Date, Status, CabinetId, PrescriptionId)
    VALUES (@PatientId, @DoctorId, @Description, @Date, @Status, @CabinetId, @PrescriptionId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

USE [ClinicDB]
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

USE [ClinicDB]
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


USE [ClinicDB]
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
	, @CabinetId int
	, @PrescriptionId int
	
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
		, [CabinetId] = @CabinetId
		, [PrescriptionId] = @PrescriptionId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO


USE [ClinicDB]
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

--\source\repos\IF-082.Net\StoredProcedures\CreatePrescriptionList.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreatePrescriptionList]
GO

CREATE PROCEDURE [dbo].[sp_CreatePrescriptionList]
	@ProcedureId int,
	@DrugId int,
	@PrescriptionId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].PrescriptionLists (ProcedureId, DrugId, PrescriptionId)
    VALUES (@ProcedureId, @DrugId, @PrescriptionId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

--\source\repos\IF-082.Net\StoredProcedures\DeletePrescriptionList.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeletePrescriptionList]
GO

CREATE PROCEDURE [dbo].[sp_DeletePrescriptionList]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM PrescriptionLists WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

--\source\repos\IF-082.Net\StoredProcedures\GetAllPrescriptionLists.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllPrescriptionLists]
GO

CREATE PROCEDURE [dbo].[sp_GetAllPrescriptionLists] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM PrescriptionLists

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

--\source\repos\IF-082.Net\StoredProcedures\GetPrescriptionListById.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetPrescriptionListById]
GO

CREATE PROCEDURE [dbo].[sp_GetPrescriptionListById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].PrescriptionLists WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

--\source\repos\IF-082.Net\StoredProcedures\UpdatePrescriptionList.sql
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdatePrescriptionList]
GO

CREATE PROCEDURE [dbo].[sp_UpdatePrescriptionList]
	@Id int,
	@ProcedureId int,
	@DrugId int,
	@PrescriptionId int
AS

IF NOT EXISTS (SELECT 1 FROM PrescriptionLists WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].PrescriptionLists
		SET	[ProcedureId] = @ProcedureId, DrugId = @DrugId, [PrescriptionId] = @PrescriptionId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
