﻿/*
Deployment script for Patient

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Patient"
:setvar DefaultFilePrefix "Patient"
:setvar DefaultDataPath "C:\Users\Sri Lakshmi\AppData\Local\Microsoft\VisualStudio\SSDT\Patient"
:setvar DefaultLogPath "C:\Users\Sri Lakshmi\AppData\Local\Microsoft\VisualStudio\SSDT\Patient"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[usp_GetPatientDetails]...';


GO
ALTER PROCEDURE [dbo].[usp_GetPatientDetails]
	
AS
BEGIN
	SELECT Patient_dtls FROM  PAT_DETAILS;
	RETURN 0;
END;
GO
PRINT N'Altering [dbo].[usp_SavePatientDetails]...';


GO

/* Below procedure used to save patient information in DB*/
ALTER PROCEDURE [dbo].[usp_SavePatientDetails]
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
GO
PRINT N'Update complete.';


GO
