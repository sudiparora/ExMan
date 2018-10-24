using System;
using System.Collections.Generic;
using System.Text;

namespace PerFin.Core.Constants
{
    public enum DeviceType
    {
        Desktop = 1,
        Android = 2
    }

    public enum TransactionType
    {
        Income = 1,
        Expense = 2
    }

    public enum TransactionNature
    {
        CreditCard = 1,
        DebitCard = 2,
        Cash = 3
    }

    public enum TransactionStatus
    {
        Planned = 1,
        Unplanned = 2,
        Executed = 3
    }
}
