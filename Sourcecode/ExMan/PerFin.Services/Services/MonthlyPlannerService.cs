using PerFin.Business.BDC;
using PerFin.Core;
using PerFin.Core.Contracts;
using PerFin.Core.Services;
using PerFin.Entities.MonthlyPlanner;
using PerFin.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerFin.Services
{
    public class MonthlyPlannerService: ServiceBase
    {

        public MonthlyPlannerService(ILogger logger, MonthlyPlannerBDC monthlyPlannerBDC)
            :base(logger)
        {
            MonthlyPlannerBDCInstance = monthlyPlannerBDC;
        }

        internal MonthlyPlannerBDC MonthlyPlannerBDCInstance { get; }

        public async Task<ResponseModel<List<Transaction>>> GetUserTransactionsForMonth(string sessionId, int month, int year)
        {
            ResponseModel<List<Transaction>> transactions = null;
            try
            {
                OperationResult<List<Transaction>> userTransactionsResult = await MonthlyPlannerBDCInstance.GetUserTransactionsForMonth(sessionId, month, year);
                if (userTransactionsResult.IsSuccessful)
                {
                    transactions = new ResponseModel<List<Transaction>>
                    {
                        ServiceOperationResult = ServiceOperationResult.Success,
                        Data = userTransactionsResult.Result
                    };
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Getting User Transactions for month failed",ex);
                transactions = new ResponseModel<List<Transaction>>
                {
                    ServiceOperationResult = ServiceOperationResult.Error
                };
            }
            return transactions;
        }

        public async Task<ResponseModel<int>> AddNewIncome(string sessionId, Transaction transaction)
        {
            ResponseModel<int> addNewIncomeResult = null;
            try
            {
                OperationResult<int> addNewIncomeResponse = await MonthlyPlannerBDCInstance.AddNewIncome(sessionId, transaction);
                if (addNewIncomeResponse.IsSuccessful)
                {
                    addNewIncomeResult = new ResponseModel<int>
                    {
                        ServiceOperationResult = ServiceOperationResult.Success,
                        Data = addNewIncomeResponse.Result
                    };
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Adding new income failed", ex);
                addNewIncomeResult = new ResponseModel<int>
                {
                    ServiceOperationResult = ServiceOperationResult.Error
                };
            }
            return addNewIncomeResult;
        }

        public async Task<ResponseModel<int>> AddNewExpense(string sessionId, Transaction transaction)
        {
            ResponseModel<int> addNewExpenseResult = null;
            try
            {
                OperationResult<int> addNewExpenseResponse = await MonthlyPlannerBDCInstance.AddNewExpense(sessionId, transaction);
                if (addNewExpenseResponse.IsSuccessful)
                {
                    addNewExpenseResult = new ResponseModel<int>
                    {
                        ServiceOperationResult = ServiceOperationResult.Success,
                        Data = addNewExpenseResponse.Result
                    };
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Adding new expense failed", ex);
                addNewExpenseResult = new ResponseModel<int>
                {
                    ServiceOperationResult = ServiceOperationResult.Error
                };
            }
            return addNewExpenseResult;
        }

    }
}
