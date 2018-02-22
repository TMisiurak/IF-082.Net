USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateClinic]    Script Date: 31.01.2018 22:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreatePayment]
	@PatientId int,
	@PaymentDate date,
	@PaymentType nvarchar(10),
	@PrescriptionId int,
	@sum int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Payments]  (PatientId, PaymentDate,PaymentType, PrescriptionId, sum)
	 VALUES (@PatientId, @PaymentDate, @PaymentType, @PrescriptionId, @sum)
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO


GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePayment]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Payments WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllPayments]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Payments
END
GO
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPaymentById]
	@id int
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT * FROM [dbo].Payments WHERE Id = @id
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdatePayment]
	@PatientId int,
	@PaymentDate date,
	@PaymentType nvarchar(10),
	@PrescriptionId int,
	@sum int,
	@Id int
AS
IF NOT EXISTS (SELECT 1 FROM Payments WHERE Id=@Id)
BEGIN
	RETURN -1
END
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Payments SET
	[PatientId]=@PatientId, [PaymentDate]=@PaymentDate, [PaymentType]=@PaymentType, [PrescriptionId] =@PrescriptionId, [sum] = @sum
	WHERE Id = @Id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
