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
GO