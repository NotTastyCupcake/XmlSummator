﻿using Metcom.XMLSummator.ApplicationCore.Entities;
using Metcom.XMLSummator.ApplicationCore.Entities.ReportingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Metcom.XMLSummator.ApplicationCore.Interfaces
{
    public interface IAmountBalances
    {
        BalanceCollection Amount(BalanceCollection FirstBalance, BalanceCollection SecondBalance); 
    }
}
