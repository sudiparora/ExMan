using PerFin.Core.Constants;
using PerFin.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerFin.Entities.MonthlyPlanner
{
    public class Transaction: EntityBase
    {

        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal TransactionAmount { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public TransactionNature TransactionNature { get; set; }

    }
}
