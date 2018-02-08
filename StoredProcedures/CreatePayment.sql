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