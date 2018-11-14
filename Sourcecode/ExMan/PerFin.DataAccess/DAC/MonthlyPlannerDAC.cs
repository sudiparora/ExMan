using PerFin.Core;
using PerFin.Core.Contracts;
using PerFin.DataAccess.Base;
using PerFin.DataAccess.Core;
using PerFin.Entities.MonthlyPlanner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PerFin.DataAccess.DAC
{
    public class MonthlyPlannerDAC : EntityDACBase
    {

        public MonthlyPlannerDAC(IAppSettings appSettings, ILogger logger)
            : base(appSettings, logger)
        { }

        //public Task<OperationResult<List<Transaction>>> GetUserTransactionsForMonth(string sessionId, int month, int year)
        //{
        //    try
        //    {
        //        SqlCommand command = GetDbSprocCommand(SPConstants.SP_GET_USER_TRANSACTIONS_FOR_MONTH);
        //        command.Parameters.Add(CreateParameter("@SessionId", sessionId));
        //        command.Parameters.Add(CreateParameter("@SelectedMonth", month));
        //        command.Parameters.Add(CreateParameter("@SelectedYear", year));
        //        return Task.Run(() => OperationResult<List<Transaction>>.ReturnSuccessResult(GetEntities<Transaction>(ref command)));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Task.Run(() => OperationResult<List<Transaction>>.LogAndReturnFailureResult(ex));
        //    }
        //}

        public Task<DbOperationResult<int>> AddNewIncome(string sessionId, Transaction transaction)
        {
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_ADD_NEW_INCOME);
                command.Parameters.Add(CreateParameter("@SessionId", sessionId));
                command.Parameters.Add(CreateParameter("@TransactionDate", transaction.TransactionDate.Date));
                command.Parameters.Add(CreateParameter("@TransactionAmount", transaction.TransactionAmount));
                command.Parameters.Add(CreateParameter("@TransactionStatusId", (int)transaction.TransactionStatus));
                command.Parameters.Add(CreateOutputParameter("@StatusCode", SqlDbType.Int));
                return Task.Run(() => GetDbOperationResult<int>(ref command));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error adding new income at DAC Layer", ex);
                return Task.Run(() => DbOperationResult<int>.ReturnFailureResult());
            }
        }

        public Task<DbOperationResult<int>> AddNewExpense(string sessionId, Transaction transaction)
        {
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_ADD_NEW_EXPENSE);
                command.Parameters.Add(CreateParameter("@SessionId", sessionId));
                command.Parameters.Add(CreateParameter("@TransactionDate", transaction.TransactionDate.Date));
                command.Parameters.Add(CreateParameter("@TransactionAmount", transaction.TransactionAmount));
                command.Parameters.Add(CreateParameter("@TransactionNatureId", (int)transaction.TransactionNature));
                command.Parameters.Add(CreateParameter("@TransactionStatusId", (int)transaction.TransactionStatus));
                command.Parameters.Add(CreateOutputParameter("@StatusCode", SqlDbType.Int));
                return Task.Run(() => GetDbOperationResult<int>(ref command));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error adding new expense at DAC Layer", ex);
                return Task.Run(() => DbOperationResult<int>.ReturnFailureResult());
            }
        }

    }
}
