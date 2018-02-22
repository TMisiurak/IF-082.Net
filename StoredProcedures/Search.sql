USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchUsers]    Script Date: 22.02.2018 13:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SearchUsers]
	@FullName NVARCHAR(200)
AS
BEGIN
	SELECT * FROM Users WHERE FullName LIKE '%' + @FullName + '%';
END

USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDoctorByUserId]    Script Date: 22.02.2018 13:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetDoctorByUserId]
	@UserId int
AS
BEGIN
	SELECT * FROM Doctors WHERE UserId = @UserId;
END


USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPatientByUserId]    Script Date: 22.02.2018 13:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetPatientByUserId]
	@UserId int
AS
BEGIN
	SELECT * FROM Patients WHERE UserId = @UserId;
END
