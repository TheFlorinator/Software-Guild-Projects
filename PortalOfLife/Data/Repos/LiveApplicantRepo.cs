using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;
using ProtalOfLife.Models.Data;
using System.Xml.Serialization;
using System.IO;
using Data.Models;

namespace Data.Repos
{
    public class LiveApplicantRepo : IApplicantRepository
    {
        public const string _filePath = @"C:\Users\apprentice\Documents\Applications.xml";

        public void AddApplicant(Applicant applicant)
        {
            var appliee = Open();
            applicant.Id = appliee.ApplicationList.Count;
            appliee.ApplicationList.Add(applicant);
            Close(appliee);
        }

        public ApplicantContainer Open()
        {
            if (!File.Exists(_filePath))
            {
                Close(new ApplicantContainer());
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicantContainer));
            using (Stream reader = new FileStream(_filePath, FileMode.Open))
            {
                return (ApplicantContainer)serializer.Deserialize(reader);
            }
        }

        public void Close(ApplicantContainer categoryList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicantContainer));
            Stream writer = new FileStream(_filePath, FileMode.Create);
            serializer.Serialize(writer, categoryList);
            writer.Close();
        }
    }
}
