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
