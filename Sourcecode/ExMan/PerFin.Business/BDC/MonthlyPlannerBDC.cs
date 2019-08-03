using PerFin.Core;
using PerFin.Core.Contracts;
using PerFin.DataAccess.DAC;
using PerFin.Entities.MonthlyPlanner;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerFin.Business.BDC
{
    public class MonthlyPlannerBDC : BDCBase
    {
        public MonthlyPlannerBDC(IAppSettings iAppSettings, ILogger logger, MonthlyPlannerDAC monthlyPlannerDAC)
            :base(iAppSettings, logger)
        {
            MonthlyPlannerDACInstance = monthlyPlannerDAC;
        }

        internal MonthlyPlannerDAC MonthlyPlannerDACInstance { get; }

        public async Task<OperationResult<List<Transaction>>> GetUserTransactionsForMonth(string sessionId, int month, int year)
        {
            try
            {
                return OperationResult<List<Transaction>>.ReturnOperationResult(await MonthlyPlannerDACInstance.GetUserTransactionsForMonth(sessionId, month, year));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in getting user transactions for month", ex);
                return OperationResult<List<Transaction>>.ReturnFailureResult();
            }
        }

        public async Task<OperationResult<int>> AddNewIncome(string sessionId, Transaction transaction)
        {
            try
            {
                return OperationResult<int>.ReturnOperationResult(await MonthlyPlannerDACInstance.AddNewIncome(sessionId, transaction));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in adding new income", ex);
                return OperationResult<int>.ReturnFailureResult();
            }
        }

        public async Task<OperationResult<int>> AddNewExpense(string sessionId, Transaction transaction)
        {
            try
            {
                return OperationResult<int>.ReturnOperationResult(await MonthlyPlannerDACInstance.AddNewExpense(sessionId, transaction));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in adding new expense", ex);
                return OperationResult<int>.ReturnFailureResult();
            }
        }

    }
}
