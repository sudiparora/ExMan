
IF OBJECT_ID('usp_FetchComponentsForUser', 'P') IS NOT NULL
    DROP PROCEDURE usp_FetchComponentsForUser
GO

IF OBJECT_ID('usp_RegisterNewLogin', 'P') IS NOT NULL
    DROP PROCEDURE usp_RegisterNewLogin
GO

CREATE PROCEDURE usp_RegisterNewLogin
(
	@Username VARCHAR(50),
	@PasswordHash VARCHAR(50),
	@DeviceHash VARCHAR(50),
	@DeviceTypeId INT,
	@SessionId VARCHAR(50) OUTPUT,
	@ErrorCode INT OUTPUT
)
AS
BEGIN
	SET @ErrorCode = 0
	IF NOT EXISTS(SELECT 1 FROM tblLogin WHERE Username = @Username)
		BEGIN
			DECLARE @LoginId UNIQUEIDENTIFIER, @DeviceId UNIQUEIDENTIFIER
			SET @LoginId = NEWID()
			INSERT INTO [dbo].[tblLogin]
				   ([LoginId]
				   ,[Username]
				   ,[PasswordHash])
			 VALUES
				   (@LoginId
				   ,@Username
				   ,@PasswordHash)

			SET @SessionId = NEWID()
			SET @DeviceId = NEWID()
			
			INSERT INTO [dbo].[tblDevice]
					   ([DeviceId]
					   ,[DeviceTypeId]
					   ,[DeviceHash]
					   ,[LoginId]
					   ,[IsSessionActive]
					   ,[DeviceSessionId])
				 VALUES
					   (@DeviceId
					   ,@DeviceTypeId
					   ,@DeviceHash
					   ,@LoginId
					   ,1
					   ,@SessionId)
		
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT 1 FROM tblDevice WHERE DeviceHash = @DeviceHash AND DeviceTypeId = @DeviceTypeId)
				BEGIN
					SET @ErrorCode = 2 -- Device Already registered
				END
--			ELSE
				--BEGIN
				---- Add support for registering a new device to an existing login
				--END
		END
		
END
GO

--CREATE PROCEDURE usp_FetchComponentsForUser
--(
--	@Usersub UNIQUEIDENTIFIER
--)
--AS
--BEGIN
--	DECLARE @UserID UNIQUEIDENTIFIER
--	SELECT @UserID = Id FROM tblUser WHERE UUID = @Usersub
--	SELECT lstCT.ComponentTypeID,lstCT.ComponentTypeCode,lstCT.ComponentTypeName FROM lstComponentType lstCT 
--		INNER JOIN tblComponentUserMapping tCum ON lstCT.ComponentTypeID = tCum.ComponentTypeID
--		INNER JOIN tblUser tUser ON tCum.UserID = @UserID
		
--END
--GO

