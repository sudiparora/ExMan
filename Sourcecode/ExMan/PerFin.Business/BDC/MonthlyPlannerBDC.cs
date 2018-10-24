using PerFin.Core.Contracts;
using PerFin.DataAccess.DAC;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerFin.Business.BDC
{
    public class MonthlyPlannerBDC : BDCBase
    {
        public MonthlyPlannerBDC(IAppSettings iAppSettings, MonthlyPlannerDAC monthlyPlannerDAC)
            :base(iAppSettings)
        {
            MonthlyPlannerDACInstance = monthlyPlannerDAC;
        }

        internal MonthlyPlannerDAC MonthlyPlannerDACInstance { get; }

        
    }
}
