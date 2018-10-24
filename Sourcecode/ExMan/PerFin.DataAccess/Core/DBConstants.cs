namespace PerFin.DataAccess.Core
{
    internal struct EntityConstants
    {
        internal const string COMPONENTTYPE = "ComponentType";
        internal const string TRANSACTION = "Transaction";
    }

    internal struct DBColumnConstants
    {
        internal const string COMPONENTTYPEID = "ComponentTypeId";
        internal const string COMPONENTTYPECODE = "ComponentTypeCode";
        internal const string COMPONENTTYPENAME = "ComponentTypeName";
        internal const string TRANSACTIONID = "TransactionId";
        internal const string TRANSACTIONDATE = "TransactionDate";
        internal const string TRANSACTIONAMOUNT = "TransactionAmount";
        internal const string TRANSACTIONTYPEID = "TransactionTypeId";
        internal const string TRANSACTIONNATUREID = "TransactionNatureId";
        internal const string TRANSACTIONSTATUSID = "TransactionStatusId";
        internal const string TRANSACTIONPLANNERMONTHID = "TransactionPlannerMonthId";
    }

    internal struct SPConstants
    {
        internal const string SP_FETCH_COMPONENTS_FOR_USER = "usp_FetchComponentsForUser";
        internal const string SP_REGISTER_NEW_LOGIN = "usp_RegisterNewLogin";
        internal const string SP_LOGIN = "usp_LoginExistingUser";
        internal const string SP_GET_USER_TRANSACTIONS_FOR_MONTH = "usp_GetUserTransactionsForMonth";
        internal const string SP_ADD_NEW_INCOME = "usp_Add_New_Income";
        internal const string SP_ADD_NEW_EXPENSE = "usp_Add_New_Expense";
    }

    internal struct DBConstants
    {
        internal const string SESSIONID = "@SessionId";
        internal const string STATUSCODE = "@ErrorCode";
    }
}
