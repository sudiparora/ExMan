DECLARE @UserID VARCHAR(128)
IF EXISTS(SELECT 1 FROM tblUser WHERE UUID = '35c89528-bc06-4824-925b-e02134856353')
BEGIN
	SELECT @UserID = Id FROM tblUser WHERE UUID = '35c89528-bc06-4824-925b-e02134856353'

	SET NOCOUNT ON
	DECLARE @lstComponentTypeID UNIQUEIDENTIFIER
	DECLARE cur_user_ComponentType CURSOR
	STATIC FOR
	SELECT ComponentTypeID FROM lstComponentType

	OPEN cur_user_ComponentType
		IF @@CURSOR_ROWS > 0
			BEGIN
			FETCH NEXT FROM cur_user_ComponentType INTO @lstComponentTypeID
			WHILE @@FETCH_STATUS = 0
				BEGIN
					
					INSERT INTO tblComponentUserMapping
							   ([ComponentTypeID]
							   ,[UserID])
						 VALUES
							   (@lstComponentTypeID
							   ,@UserID)

					FETCH NEXT FROM cur_user_ComponentType INTO @lstComponentTypeID

				END
			END

	CLOSE cur_user_ComponentType
	DEALLOCATE cur_user_ComponentType
	SET NOCOUNT OFF

END
