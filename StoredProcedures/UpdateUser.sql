SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	@UserId int
AS
IF EXISTS (SELECT * FROM Users WHERE Id=@UserId)
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].Users SET
	[Address] = @Address, [BirthDay] = @BirthDay, [Email] = @Email, [FullName] = @FullName,
	[Image] = @Image, [Password] = @Password, [PhoneNumber] = @PhoneNumber, [Sex] = @Sex, [RoleId] = @RoleId
	WHERE Id = @UserId
END
GO
