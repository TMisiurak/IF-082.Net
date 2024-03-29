USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateProcedure]    Script Date: 01.02.2018 13:15:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateProcedure]
	 @Name nvarchar(120),
	 @Price decimal,
	 @Room int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Procedures] (Name, Price, Room)
    VALUES (@Name, @Price, @Room)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
