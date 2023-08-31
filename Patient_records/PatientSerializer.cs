using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Patient_serialization
{
    
        public class PatientSerializer
        {

            public static void Serialize(List<Patient> patient, string filePath)
            {
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Write);
                XmlSerializer fm = new XmlSerializer(typeof(List<Patient>));
            fm.Serialize(fs, patient);
            fs.Close();
            
                
            }
            public static List<Patient> Deserialize(string filePath)
            {
            FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer fm = new XmlSerializer(typeof(List<Patient>));
            foreach (var item in ProgramMain.patients)
                Console.WriteLine(item);
            fs.Close();
            return ProgramMain.patients;
            

        }
    }
    }

