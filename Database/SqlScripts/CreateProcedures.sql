
IF OBJECT_ID('usp_FetchComponentsForUser', 'P') IS NOT NULL
    DROP PROCEDURE usp_FetchComponentsForUser
GO

IF OBJECT_ID('usp_RegisterNewLogin', 'P') IS NOT NULL
    DROP PROCEDURE usp_RegisterNewLogin
GO

IF OBJECT_ID('usp_LoginExistingUser', 'P') IS NOT NULL
    DROP PROCEDURE usp_LoginExistingUser
GO

CREATE PROCEDURE usp_LoginExistingUser
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
	IF EXISTS(SELECT 1 FROM tblLogin WHERE Username = @Username AND PasswordHash = @PasswordHash)
		BEGIN
			DECLARE @UserLoginId VARCHAR(50)
			SELECT @UserLoginId = LoginId FROM tblLogin WHERE Username = @Username AND PasswordHash = @PasswordHash
			
			IF(@UserLoginId IS NULL OR @UserLoginId = '')
			
				SET @ErrorCode = 999 --Something has gone wrong. DB Corruption might have occurred.

			ELSE
				BEGIN
					DECLARE @UserDeviceType VARCHAR(50), @UserDeviceHash VARCHAR(50), @DeviceId VARCHAR(50)

					SELECT @UserDeviceHash = DeviceHash, @UserDeviceType = DeviceTypeId, @DeviceId = DeviceId FROM tblDevice WHERE LoginId = @UserLoginId
					IF(@UserDeviceType = @DeviceTypeId)
						BEGIN

							IF(@UserDeviceHash = @DeviceHash)
								BEGIN
									SET @SessionId = NEWID()
									UPDATE tblDevice SET DeviceSessionId = @SessionId, IsSessionActive = 1 WHERE DeviceId = @DeviceId		
								END
							ELSE
								SET @ErrorCode = 4 -- Another device has already been registered with this account
						END
					--ELSE -- Register New Device

				END
		END
	ELSE
		SET @ErrorCode = 1 -- User not registered
END
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
	IF EXISTS(SELECT 1 FROM tblDevice WHERE DeviceHash = @DeviceHash AND DeviceTypeId = @DeviceTypeId)
		BEGIN
			SET @ErrorCode = 2 -- Device Already registered
		END
	ELSE IF NOT EXISTS(SELECT 1 FROM tblLogin WHERE Username = @Username)
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
	
		
--			ELSE
				--BEGIN
				---- Add support for registering a new device to an existing login
				--END
		
END
GO

CREATE PROCEDURE usp_FetchComponentsForUser
(
	@Username VARCHAR(50),
	@SessionId UNIQUEIDENTIFIER,
	@ErrorCode INT OUTPUT
)
AS
BEGIN
	SET @ErrorCode = 0
	DECLARE @LoginId UNIQUEIDENTIFIER, @UserInputLoginId UNIQUEIDENTIFIER
	SELECT @UserInputLoginId = LoginId FROM tblLogin WHERE Username = @Username
	IF(@UserInputLoginId <> @LoginID)
		SET @ErrorCode = 5
	ELSE
		BEGIN
			SELECT @LoginId = LoginId FROM tblDevice WHERE DeviceSessionId = @SessionId
			SELECT lstCT.ComponentTypeID,lstCT.ComponentTypeCode,lstCT.ComponentTypeName FROM lstComponentType lstCT 
				INNER JOIN tblComponentLoginMapping tClm ON lstCT.ComponentTypeID = tClm.ComponentTypeID
				INNER JOIN tblLogin ON tClm.LoginId = @LoginId
		END		
END
GO

