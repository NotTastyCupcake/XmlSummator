﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Metcom.XMLSummator.ApplicationCore.Entities.BalanceModel.BalanceAbstractModel
{
    public abstract class BalanceBaseEntity : ReportingBalanceBaseEntity
    {
        [XmlAttribute("Счет2Пор")]
        /// <summary>
        /// Идентификатор клиента - Счет2Пор
        /// </summary>
        public int SecondOrderAccount { get; set; }

    }
}