USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserByEmail]    Script Date: Пн 29.01.2018 14:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
	@email nvarchar(120)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Users WHERE Email = @email
END
