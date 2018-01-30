USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetUserByEmail]
GO

CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
	@email nvarchar(120)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Users WHERE Email = @email
END
GO
