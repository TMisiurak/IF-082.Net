USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllUsers]    Script Date: Пн 29.01.2018 14:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllUsers] AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Users
END
