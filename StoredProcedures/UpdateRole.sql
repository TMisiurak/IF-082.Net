SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateRole]
	@Name nvarchar(MAX),
	@RoleId int
AS
IF EXISTS (SELECT * FROM Roles WHERE Id = @RoleId)
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].Roles SET
		[Name] = @Name WHERE Id = @RoleId
END
GO
