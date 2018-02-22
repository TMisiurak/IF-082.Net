USE [ClinicDB]
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