USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: Пн 29.01.2018 14:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteUser]
	@id int
	
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM Users WHERE Id = @id
	RETURN 2
END