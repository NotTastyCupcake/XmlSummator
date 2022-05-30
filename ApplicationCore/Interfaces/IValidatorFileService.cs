﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Metcom.XMLSummator.ApplicationCore.Interfaces
{
    public interface IValidatorFileService
    {
        bool IsValidNameFile(string fileName);

        bool IsValidSizeFile(int fileSize);

        //bool IsValidFormat();
    }
}
