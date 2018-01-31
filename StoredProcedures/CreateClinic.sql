SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP PROCEDURE [dbo].[sp_CreateClinic]
GO
CREATE PROCEDURE [dbo].[sp_CreateClinic]
	@Name nvarchar(200),
	@Address nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Clinics] (Name, Address) VALUES (@Name, @Address)
END
GO
