DECLARE @LoginId VARCHAR(50)
IF EXISTS(SELECT 1 FROM tblLogin WHERE Username = 'sudip.arora@gmail.com')
BEGIN
	SELECT @LoginId = LoginId FROM tblLogin WHERE Username = 'sudip.arora@gmail.com'

	SET NOCOUNT ON
	DECLARE @lstComponentTypeID INT
	DECLARE cur_user_ComponentType CURSOR
	STATIC FOR
	SELECT ComponentTypeID FROM lstComponentType

	OPEN cur_user_ComponentType
		IF @@CURSOR_ROWS > 0
			BEGIN
			FETCH NEXT FROM cur_user_ComponentType INTO @lstComponentTypeID
			WHILE @@FETCH_STATUS = 0
				BEGIN
					
					INSERT INTO tblComponentLoginMapping
							   ([ComponentTypeID]
							   ,[LoginID])
						 VALUES
							   (@lstComponentTypeID
							   ,@LoginID)

					FETCH NEXT FROM cur_user_ComponentType INTO @lstComponentTypeID

				END
			END

	CLOSE cur_user_ComponentType
	DEALLOCATE cur_user_ComponentType
	SET NOCOUNT OFF

END
