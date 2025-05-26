using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aps01
{
    public class MedicalCare
    {
        Queue<Patient> ServiceQueue = new();
        
        public void CallPatient(Patient patient)
        {
            ServiceQueue.Enqueue(patient);
            Console.WriteLine("Por favor, aguarde a triagem.");
        }

        public Patient DoScreening()
        {
            return ServiceQueue.Dequeue();
        }

        public void ShowServiceQueue()
        {
            AnsiColors.WriteLine($"{string.Join(" -> ", ServiceQueue)}", AnsiColors.Green);
        }
    }
}
