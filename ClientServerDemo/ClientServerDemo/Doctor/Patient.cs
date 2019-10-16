using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class Patient
    {
        public Patient(string name, int age, string gender, string fietsId)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Bpm = 0;
            FietsId = fietsId;
            workload = new List<double>();
            heartbeat = new List<double>();
            maxheartbeat = 0;
            this.history = new List<History>(); 
        }
        public List<double> workload;

        public List<double> heartbeat;

        public double maxheartbeat;

        public List<History> history; 
        public String Name { get; private set; }

        public int Age { get; set; }

        public String Gender { get; set; }

        public int Bpm { get; set; }

        public String FietsId { get; set; }


        public String toString()
        {
            return $"{Name} - {FietsId} " ;
        }
    }
}
