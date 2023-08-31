using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_serialization
{
    class ProgramMain
    {
        public static List<Patient> patients = new List<Patient>();
        static readonly string filePath = "PatientRecord.xml";
        static void Main(string[] args)
        {
            LoadPatients();
            while (true)
            {
                Console.WriteLine("Choose an opeations");
                Console.WriteLine("1. Add");
                Console.WriteLine("2.Read");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Delete");
                Console.WriteLine("5.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            CreatePatients();
                        }
                        break;
                    case 2: ReadPatients(); break;
                   case 3: UpdatePatients(); break;
                   case 4:DeletePatients();break;
                    case 5:SavePatients();
                        return;
                    default: Console.WriteLine("Wrong input"); break;

                }
            }
        }
        static void LoadPatients()
        {
            if (File.Exists(filePath))
            {
                patients = PatientSerializer.Deserialize(filePath);
            }
        }
        static void SavePatients()
        {
            PatientSerializer.Serialize(patients,filePath);
        }
        static void CreatePatients()
        {
            int pid = Utilities.GetInteger("Enter the Patient id");
            string pname = Utilities.GetString("Enter the Patient name");
            string paddress = Utilities.GetString("Enter the Patient address");
            long pPhone = Utilities.GetLong("Enter the Patient phone number");
            DateTime jDate = Utilities.GetDateTime("Enter the Date ");
            float bill = Utilities.GetFloat("Enter the Bill Amount");
            patients.Add(new Patient { patient_id = pid, patient_name = pname, address = paddress, phone = pPhone, JoiningDate = jDate, Bill_amount = bill });
            SavePatients();
            Console.WriteLine("Patient created successfully");
        }
        static void ReadPatients()
        { 
        foreach(var item in patients)
                Console.WriteLine($"ID : {item.patient_id} ,Name :{item.patient_name} ,address: {item.address},Phone: {item.phone}, Joining Date{item.JoiningDate}, Bill Amount {item.Bill_amount}");
        }
        static void UpdatePatients()
        {

            Console.WriteLine("Enter the ID of the patient to be updated");
            int id = int.Parse(Console.ReadLine());
            var patientToUpdate = patients.FirstOrDefault(p => p.patient_id == id);
            if (patientToUpdate != null)
            {
                patientToUpdate.patient_name = Utilities.GetString("Enter the updated Patient name"); patientToUpdate.address = Utilities.GetString("Enter updated the Patient address");
                patientToUpdate.phone = Utilities.GetLong("Enter the updated Patient phone number");
                patientToUpdate.JoiningDate =
                    Utilities.GetDateTime("Enter updated Joining Date ");
                patientToUpdate.Bill_amount = Utilities.GetFloat("Enter the Bill Amount");
            }
            else {
                Console.WriteLine("Patient not found.");
            }

        }
        static void DeletePatients()
        {
            int id = Utilities.GetInteger("Enter the id of the patient to delete:");

            var patientToDelete = patients.FirstOrDefault(p => p.patient_id == id);
            if (patientToDelete != null)
            {
                patients.Remove(patientToDelete);
                SavePatients();
                Console.WriteLine("Patient deleted successfully.");
            }
            else {
                Console.WriteLine("Patient not found.");
            }
        }
    }
}
