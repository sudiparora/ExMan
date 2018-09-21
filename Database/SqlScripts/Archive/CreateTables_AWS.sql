
IF OBJECT_ID('tblComponentUserMapping', 'U') IS NOT NULL
	DROP TABLE tblComponentUserMapping;

IF OBJECT_ID('lstComponentType', 'U') IS NOT NULL
    DROP TABLE lstComponentType;

IF OBJECT_ID('tblUser', 'U') IS NOT NULL
	DROP TABLE tblUser;

CREATE TABLE lstComponentType
(
	ComponentTypeID UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
	ComponentTypeName VARCHAR(50),
	ComponentTypeCode VARCHAR(50),
	CONSTRAINT PK_lstComponentType_ComponentTypeID PRIMARY KEY CLUSTERED (ComponentTypeID)
);
GO

CREATE TABLE tblUser
(
	Id UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
	UUID UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_tblUser_Id PRIMARY KEY CLUSTERED (Id) 
);
GO

CREATE TABLE tblComponentUserMapping
(
	ComponentTypeID UNIQUEIDENTIFIER NOT NULL,
    UserID UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_tblComponentUserMapping_ComponentTypeID FOREIGN KEY(ComponentTypeID) REFERENCES lstComponentType(ComponentTypeID),
	CONSTRAINT FK_tblComponentUserMapping_UserID FOREIGN KEY(UserID) REFERENCES tblUser(Id)
);
GO

