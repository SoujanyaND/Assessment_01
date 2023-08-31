using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Patient_serialization
{
    [Serializable]
    public class Program
    {
        public int patient_id { get; set; }
        public string patient_name { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now.Date;
        public string doctorName { get; set; }
        public float Bill_amount { get; set; }
        public override string ToString()
        {
            return $"The Patient information is as follows : \n Patient id :{patient_id}\n patient name {patient_name}\n patient address {address} \n patient phone number : {phone} \n patient admission date {JoiningDate.ToLongDateString()}\n doctor name {doctorName} \ntotal bill amount {Bill_amount} ";
        }
        
            private static void xmlSerialization()
            {
                
                Program data = CreateData();
                
                FileStream fs = new FileStream("PatientRecord.xml", FileMode.OpenOrCreate, FileAccess.Write);
                XmlSerializer fm = new XmlSerializer(typeof(Program));
                fm.Serialize(fs, data);
                fs.Close();
                Console.WriteLine("Xml Serialization successfully completed");
            }
            private static void XmlDeserialization()
            {
                FileStream fs = new FileStream("PatientRecord.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer fm = new XmlSerializer(typeof(Program));
                Program extracted = fm.Deserialize(fs) as Program;
                Console.WriteLine(extracted.ToString());
            }

        //create
            public static Program CreateData()
            {
                int pid = Utilities.GetInteger("Enter the Patient id");
                string pname = Utilities.GetString("Enter the Patient name");
                string paddress = Utilities.GetString("Enter the Patient address");
                long pPhone = Utilities.GetLong("Enter the Patient phone number");
                DateTime jDate = Utilities.GetDateTime("Enter the Date ");
                float bill = Utilities.GetFloat("Enter the Bill Amount");

                return new Program
                {
                    patient_id = pid,
                    patient_name = pname,
                    address = paddress,
                    phone = pPhone,
                    JoiningDate = jDate,
                    Bill_amount = bill
                };

            }
        //delete
        public static void deletedata()
        {
            File.Delete("PatientRecord.xml");
            Console.WriteLine("The file was deleted successfully" 
                );
        }
        
        static void Main(string[] args)
            {
                bool repeat = true;
                while (repeat)
                {
                    int choice = Utilities.GetInteger("1.Insert Patient Record 2.Display Patient 3.remove Patient record  Record 4.Update Patient");
                    switch (choice)
                    {
                        case 1: { 
                                xmlSerialization(); } break;
                        case 2: XmlDeserialization();break;
                        case 3: deletedata();break;
                        default: Console.WriteLine("Wrong input"); break;

                    }
                }


                
            }
        }
    }


