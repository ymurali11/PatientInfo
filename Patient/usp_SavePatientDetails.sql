
/* Below procedure used to save patient information in DB*/
CREATE PROCEDURE [dbo].[usp_SavePatientDetails]
	@patient_details XML
	
	
AS
BEGIN
BEGIN TRAN
	INSERT INTO PAT_DETAILS (Patient_Id,Patient_dtls) VALUES
	    ((SELECT COALESCE(MAX(Patient_Id),0) +1 FROM PAT_DETAILS),
		  @patient_details);
  

COMMIT TRAN;

RETURN 1;
END;

