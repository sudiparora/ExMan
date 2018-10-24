using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PerFin.Core.Constants;
using PerFin.Entities.Base;
using PerFin.Entities.MonthlyPlanner;

namespace PerFin.DataAccess.Core
{
    public class TransactionParser : IEntityParser
    {

        private int ord_TransactionId;
        private int ord_TransactionDate;
        private int ord_TransactionAmount;
        private int ord_TransactionTypeId;
        private int ord_TransactionStatusId;
        private int ord_TransactionNatureId;

        public EntityBase PopulateEntity(SqlDataReader reader)
        {
            Transaction transaction = new Transaction();
            if (!reader.IsDBNull(ord_TransactionId)) transaction.TransactionId = reader.GetString(ord_TransactionId);
            if (!reader.IsDBNull(ord_TransactionDate)) transaction.TransactionDate = reader.GetDateTime(ord_TransactionDate).Date;
            if (!reader.IsDBNull(ord_TransactionAmount)) transaction.TransactionAmount = reader.GetDecimal(ord_TransactionAmount);
            if (!reader.IsDBNull(ord_TransactionTypeId)) transaction.TransactionType = (TransactionType)reader.GetInt32(ord_TransactionTypeId);
            if (!reader.IsDBNull(ord_TransactionStatusId)) transaction.TransactionStatus = (TransactionStatus)reader.GetInt32(ord_TransactionStatusId);
            if (!reader.IsDBNull(ord_TransactionNatureId)) transaction.TransactionNature = (TransactionNature)reader.GetInt32(ord_TransactionNatureId);
            return transaction;
        }

        public void PopulateOrdinals(SqlDataReader reader)
        {
            ord_TransactionId = reader.GetOrdinal(DBColumnConstants.TRANSACTIONID);
            ord_TransactionDate = reader.GetOrdinal(DBColumnConstants.TRANSACTIONDATE);
            ord_TransactionAmount = reader.GetOrdinal(DBColumnConstants.TRANSACTIONAMOUNT);
            ord_TransactionTypeId = reader.GetOrdinal(DBColumnConstants.TRANSACTIONTYPEID);
            ord_TransactionStatusId = reader.GetOrdinal(DBColumnConstants.TRANSACTIONSTATUSID);
            ord_TransactionNatureId = reader.GetOrdinal(DBColumnConstants.TRANSACTIONNATUREID);
        }

        public SqlParameter[] PopulateParameters(EntityBase entity)
        {
            throw new NotImplementedException();
        }
    }
}
