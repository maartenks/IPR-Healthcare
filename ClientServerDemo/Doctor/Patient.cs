using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class Patient
    {
        public Patient(string name, int age, string gender, int weight, string fietsId)
        {
            Name = name;
            Age = age;
            Gender = gender;
            this.weight = weight;
            FietsId = fietsId;
            workload = new List<double>();
            heartbeat = new List<double>();
            this.histories = new List<History>();
            rotationPerMinute = new List<double>();
            maxheartbeat = 0;
            steadyState = false;
        }
        public List<double> workload;

        public List<double> heartbeat;

        public double maxheartbeat;
        public int weight { get; set; }

        public List<History> histories;
        public bool steadyState { get; set; }
        public String Name { get; private set; }

        public int Age { get; set; }

        public String Gender { get; set; }


        public String FietsId { get; set; }

        public List<double> rotationPerMinute { get; set; }

        public String getSteadyState()
        {
            if (steadyState == true)
            {
                return "bereikt";
            }
            else
            {
                return "niet bereikt";
            }
        }
        public String toString()
        {
            return $"{Name} - {FietsId} ";
        }
    }
}
