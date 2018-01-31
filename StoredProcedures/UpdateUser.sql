USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 31.01.2018 23:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UpdateUser]
	@Address nvarchar(300),
    @BirthDay date,
	@Email nvarchar(64),
	@FullName nvarchar(300),
	@Image nvarchar(2000),
	@Password nvarchar(512),
	@PhoneNumber nvarchar(10),
	@Sex nvarchar(3),
	@RoleId int
AS
IF EXISTS (SELECT * FROM Users WHERE Email = @Email)
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Users SET
	[Address] = @Address, [BirthDay] = @BirthDay, [Email] = @Email, [FullName] = @FullName,
	[Image] = @Image, [Password] = @Password, [PhoneNumber] = @PhoneNumber, [Sex] = @Sex, [RoleId] = @RoleId
	WHERE Email = @Email
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
