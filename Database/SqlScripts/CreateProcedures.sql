
IF OBJECT_ID('usp_FetchComponentsForUser', 'P') IS NOT NULL
    DROP PROCEDURE usp_FetchComponentsForUser
GO

CREATE PROCEDURE usp_FetchComponentsForUser
(
	@Usersub UNIQUEIDENTIFIER
)
AS
BEGIN
	DECLARE @UserID UNIQUEIDENTIFIER
	SELECT @UserID = Id FROM tblUser WHERE UUID = @Usersub
	SELECT lstCT.ComponentTypeID,lstCT.ComponentTypeCode,lstCT.ComponentTypeName FROM lstComponentType lstCT 
		INNER JOIN tblComponentUserMapping tCum ON lstCT.ComponentTypeID = tCum.ComponentTypeID
		INNER JOIN tblUser tUser ON tCum.UserID = @UserID
		
END
GO

