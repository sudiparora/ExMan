
IF OBJECT_ID('usp_FetchComponentsForUser', 'P') IS NOT NULL
    DROP PROCEDURE usp_FetchComponentsForUser
GO

CREATE PROCEDURE usp_FetchComponentsForUser
(
	@Username NVARCHAR(256)
)
AS
BEGIN
	DECLARE @UserID NVARCHAR(128)
	SELECT @UserID = Id FROM tblUser WHERE Email = @Username
	SELECT lstCT.ComponentTypeID,lstCT.ComponentTypeCode,lstCT.ComponentTypeName FROM lstComponentType lstCT 
		INNER JOIN tblComponentUserMapping tCum ON lstCT.ComponentTypeID = tCum.ComponentTypeID
		INNER JOIN tblUser tUser ON tCum.UserID = @UserID
		
END
GO

