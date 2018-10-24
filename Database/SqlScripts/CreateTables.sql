
--IF OBJECT_ID('tblComponentUserMapping', 'U') IS NOT NULL
--	DROP TABLE tblComponentUserMapping;

--IF OBJECT_ID('lstComponentType', 'U') IS NOT NULL
--    DROP TABLE lstComponentType;

IF OBJECT_ID('tblDevice', 'U') IS NOT NULL
    DROP TABLE tblDevice;

IF OBJECT_ID('tblLogin', 'U') IS NOT NULL
    DROP TABLE tblLogin;

IF OBJECT_ID('lstDeviceType', 'U') IS NOT NULL
    DROP TABLE lstDeviceType;

IF OBJECT_ID('tblUser', 'U') IS NOT NULL
    DROP TABLE tblUser;

CREATE TABLE lstDeviceType
(
	DeviceTypeId INT IDENTITY(1,1) NOT NULL, 
	DeviceName VARCHAR(10) NOT NULL,
	CONSTRAINT PK_lstDeviceType_DeviceTypeId PRIMARY KEY CLUSTERED (DeviceTypeId)
);

CREATE TABLE tblLogin
(
	LoginId VARCHAR(50) NOT NULL,
	Username VARCHAR(50) NOT NULL UNIQUE,
	PasswordHash VARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_tblLogin_LoginId PRIMARY KEY CLUSTERED (LoginId)
);

CREATE TABLE tblDevice
(
	DeviceId VARCHAR(50) NOT NULL,
	DeviceTypeId INT NOT NULL,
	DeviceHash VARCHAR(50) NOT NULL,
	LoginId VARCHAR(50) NOT NULL,
	IsSessionActive BIT,
	DeviceSessionId VARCHAR(50) NOT NULL,
	CONSTRAINT PK_tblDevice_DeviceId PRIMARY KEY CLUSTERED (DeviceId),
	CONSTRAINT FK_tblDevice_DeviceTypeId FOREIGN KEY(DeviceTypeId) REFERENCES lstDeviceType(DeviceTypeId),
	CONSTRAINT FK_tblLogin_LoginId FOREIGN KEY(LoginId) REFERENCES tblLogin(LoginId)
);




--CREATE TABLE tblUser
--(
	
--);


--CREATE TABLE lstComponentType
--(
--	ComponentTypeID INT IDENTITY(1,1) NOT NULL,
--	ComponentTypeName VARCHAR(50),
--	ComponentTypeCode VARCHAR(50),
--	CONSTRAINT PK_lstComponentType_ComponentTypeID PRIMARY KEY CLUSTERED (ComponentTypeID)
--);
--GO

--CREATE TABLE tblComponentUserMapping
--(
--	ComponentTypeID INT NOT NULL,
--    UserID NVARCHAR(128) NOT NULL,
--	CONSTRAINT FK_tblComponentUserMapping_ComponentTypeID FOREIGN KEY(ComponentTypeID) REFERENCES lstComponentType(ComponentTypeID),
--	CONSTRAINT FK_tblComponentUserMapping_UserID FOREIGN KEY(UserID) REFERENCES tblUser(Id)
--);
--GO

