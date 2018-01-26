SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateUser]
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
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].Users (Address, BirthDay, Email, FullName, Image, Password, PhoneNumber, Sex, RoleId)
    VALUES (@Address, @BirthDay, @Email, @FullName, @Image, @Password, @PhoneNumber, @Sex, @RoleId)
END
GO
