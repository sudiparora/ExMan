IF OBJECT_ID('tblTransaction', 'U') IS NOT NULL
    DROP TABLE tblTransaction;

IF OBJECT_ID('tblPlannerMonth', 'U') IS NOT NULL
    DROP TABLE tblPlannerMonth;

IF OBJECT_ID('lstTransactionType', 'U') IS NOT NULL
    DROP TABLE lstTransactionType;

IF OBJECT_ID('lstTransactionNature', 'U') IS NOT NULL
    DROP TABLE lstTransactionNature;

IF OBJECT_ID('lstTransactionStatus', 'U') IS NOT NULL
    DROP TABLE lstTransactionStatus;

CREATE TABLE lstTransactionType
(
	TransactionTypeId INT IDENTITY(1,1) NOT NULL, 
	TransactionTypeName VARCHAR(10) NOT NULL,
	CONSTRAINT PK_lstTransactionType_TransactionTypeId PRIMARY KEY CLUSTERED (TransactionTypeId)
);

CREATE TABLE lstTransactionNature
(
	TransactionNatureId INT IDENTITY(1,1) NOT NULL, 
	TransactionNatureName VARCHAR(10) NOT NULL,
	CONSTRAINT PK_lstTransactionNature_TransactionNatureId PRIMARY KEY CLUSTERED (TransactionNatureId)
);

CREATE TABLE lstTransactionStatus
(
	TransactionStatusId INT IDENTITY(1,1) NOT NULL, 
	TransactionStatusName VARCHAR(10) NOT NULL,
	CONSTRAINT PK_lstTransactionStatus_TransactionStatusId PRIMARY KEY CLUSTERED (TransactionStatusId)
);

CREATE TABLE tblPlannerMonth
(
	PlannerMonthId VARCHAR(50) NOT NULL,
	PlannerMonthNumber INT NOT NULL,
	PlannerMonthYear INT NOT NULL,
	LoginId VARCHAR(50) NOT NULL,
	CONSTRAINT PK_tblPlannerMonth_PlannerMonthId PRIMARY KEY CLUSTERED (PlannerMonthId),
	CONSTRAINT FK_tblPlannerMonth_UserId FOREIGN KEY(LoginId) REFERENCES tblLogin(LoginId)
);

CREATE TABLE tblTransaction
(
	TransactionId VARCHAR(50) NOT NULL,
	TransactionDate DATETIME NULL,
	TransactionAmount DECIMAL NOT NULL,
	TransactionTypeId INT NOT NULL,
	TransactionNatureId INT NOT NULL,
	TransactionStatusId INT NOT NULL,
	TransactionPlannerMonthId VARCHAR(50) NOT NULL,
	CONSTRAINT PK_tblTransaction_TransactionId PRIMARY KEY CLUSTERED (TransactionId),
	CONSTRAINT FK_tblTransaction_TransactionTypeId FOREIGN KEY(TransactionTypeId) REFERENCES lstTransactionType(TransactionTypeId),
	CONSTRAINT FK_tblTransaction_TransactionNatureId FOREIGN KEY(TransactionNatureId) REFERENCES lstTransactionNature(TransactionNatureId),
	CONSTRAINT FK_tblTransaction_TransactionStatusId FOREIGN KEY(TransactionStatusId) REFERENCES lstTransactionStatus(TransactionStatusId),
	CONSTRAINT FK_tblTransaction_TransactionPlannerMonthId FOREIGN KEY(TransactionPlannerMonthId) REFERENCES tblPlannerMonth(PlannerMonthId)
);
