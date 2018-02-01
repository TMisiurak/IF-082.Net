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
GO