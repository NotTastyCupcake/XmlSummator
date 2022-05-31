﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Metcom.XMLSummator.ApplicationCore.Entities.ReportingAggregate
{
    public class ReportingBalance : ReportingBaseEntity
    {
        [XmlAttribute]
        /// <summary>
        /// Идентификатор клиента - Счет2Пор
        /// </summary>
        public int ClientId { get; set; }

    }
}