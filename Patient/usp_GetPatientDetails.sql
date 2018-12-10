CREATE PROCEDURE [dbo].[usp_GetPatientDetails]
	
AS
BEGIN
	SELECT Patient_dtls FROM  PAT_DETAILS;
	RETURN 0;
END;