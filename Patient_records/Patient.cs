using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Patient_serialization
{
    [Serializable]
    public class Patient
    {
        public int patient_id { get; set; }
        public string patient_name { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now.Date;
        public string doctorName { get; set; }
        public float Bill_amount { get; set; }
    }
    
}
    
    

