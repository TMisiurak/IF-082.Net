USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateUser]
GO

CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@Address nvarchar(300),
    @BirthDay date,
	@Email nvarchar(64),
	@FullName nvarchar(300),
	@Image nvarchar(2000),
	@Password nvarchar(512),
	@PhoneNumber nvarchar(10),
	@Sex nvarchar(3),
	@RoleId int,
	@Id int
AS

IF NOT EXISTS (SELECT 1 FROM Users WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Users
		SET	[Address] = @Address, [BirthDay] = @BirthDay, [Email] = @Email, [FullName] = @FullName,
			[Image] = @Image, [Password] = @Password, [PhoneNumber] = @PhoneNumber, [Sex] = @Sex, [RoleId] = @RoleId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
