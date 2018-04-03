IF OBJECT_ID('tblComponentUserMapping', 'U') IS NOT NULL
	DROP TABLE tblComponentUserMapping;

IF OBJECT_ID('lstComponentType', 'U') IS NOT NULL
    DROP TABLE lstComponentType;

CREATE TABLE lstComponentType
(
	ComponentTypeID INT IDENTITY(1,1) NOT NULL,
	ComponentTypeName VARCHAR(50),
	ComponentTypeCode VARCHAR(50),
	CONSTRAINT PK_lstComponentType_ComponentTypeID PRIMARY KEY CLUSTERED (ComponentTypeID)
);
GO

CREATE TABLE tblComponentUserMapping
(
	ComponentTypeID INT NOT NULL,
    UserID NVARCHAR(128) NOT NULL,
	CONSTRAINT FK_tblComponentUserMapping_ComponentTypeID FOREIGN KEY(ComponentTypeID) REFERENCES lstComponentType(ComponentTypeID),
	CONSTRAINT FK_tblComponentUserMapping_UserID FOREIGN KEY(UserID) REFERENCES tblUser(Id)
);
GO

