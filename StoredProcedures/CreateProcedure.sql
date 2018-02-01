SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_CreateProcedure]
GO

CREATE PROCEDURE [dbo].[sp_CreateProcedure]
	 @Name nvarchar(120),
	 @Price float,
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
GO
