
IF OBJECT_ID('usp_Add_New_Income', 'P') IS NOT NULL
    DROP PROCEDURE usp_Add_New_Income
GO

IF OBJECT_ID('usp_Add_New_Expense', 'P') IS NOT NULL
    DROP PROCEDURE usp_Add_New_Expense
GO

IF OBJECT_ID('usp_GetUserTransactionsForMonth', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetUserTransactionsForMonth
GO

CREATE PROCEDURE usp_Add_New_Income
(
	@SessionId VARCHAR(50),
	@TransactionDate DATETIME,
	@TransactionAmount DECIMAL,
	@TransactionStatusId INT,
	@StatusCode INT
)
AS
BEGIN
