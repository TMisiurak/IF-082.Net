USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: Пн 29.01.2018 14:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Users WHERE Id = @id
END
