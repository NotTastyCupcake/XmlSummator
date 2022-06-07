﻿using Metcom.XMLSummator.ApplicationCore.Entities;
using Metcom.XMLSummator.ApplicationCore.Entities.BalanceModel;
using Metcom.XMLSummator.ApplicationCore.Extensions;
using Metcom.XMLSummator.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Metcom.XMLSummator.ApplicationCore.Services
{
    public class FileWorkerService : IFileWorkerService
    {
        private readonly ICollection<ReportForm> ReportForms;
        private readonly IValidatorFile _validatorFile;
        private readonly IAmountBalances _amountBalances;
        private ReportForm res;

        public FileWorkerService()
        {
            ReportForms = new List<ReportForm>();
            _validatorFile = new ValidatorFile();
            _amountBalances = new AmountBalance();
        }


        public bool CreataAmountFile(string firstFileName, string secondFileName, string resultFileName)
        {

            // Now we can read the serialized book ...  
            XmlSerializer serialize = new XmlSerializer(typeof(ReportForm));
            StreamReader fileFirst = new StreamReader(firstFileName, Encoding.GetEncoding(1251));
            ReportForm formFirst = (ReportForm)serialize.Deserialize(fileFirst);
            fileFirst.Close();
            
            StreamReader fileSecond = new StreamReader(secondFileName, Encoding.GetEncoding(1251));
            ReportForm formSecond = (ReportForm)serialize.Deserialize(fileSecond);
            fileSecond.Close();


            ReportForm res = _amountBalances.Amount(formFirst, formSecond);

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Encoding = Encoding.GetEncoding(1251);
            writerSettings.Indent = true;
            
            FileStream writer = File.Create(resultFileName);

            XmlWriter xwriter = XmlWriter.Create(writer, writerSettings);
            xwriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"windows-1251\" standalone=\"yes\"");
            serialize.Serialize(xwriter, res);

            writer.Close();

            return false;
        }

        public void AddReportForm(StreamReader stream)
        {
            XmlSerializer serialize = new XmlSerializer(typeof(ReportForm));
            try
            {
                ReportForm desForm = (ReportForm)serialize.Deserialize(stream);
                ReportForms.Add(desForm);
            }
            finally
            {
                stream.Close();
            }
        }

        public void AmountForms()
        {
            res = _amountBalances.Amount(ReportForms);
        }

        public void CreateResultFile(FileStream resultFile)
        {
            try
            {
                XmlSerializer serialize = new XmlSerializer(typeof(ReportForm));

                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.Encoding = Encoding.GetEncoding(1251);
                writerSettings.Indent = true;
                
                XmlWriter xwriter = XmlWriter.Create(resultFile, writerSettings);
                xwriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"windows-1251\" standalone=\"yes\"");
                serialize.Serialize(xwriter, res);

            }
            finally
            {
                resultFile.Close();
            }
        }


    }
}
