USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoleById]    Script Date: Пн 29.01.2018 14:05:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRoleById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Roles WHERE Id = @id
END
