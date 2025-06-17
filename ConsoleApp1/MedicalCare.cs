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
        HashTable hashTable = new();
        
        public void CallPatient(Patient patient)
        {
            if (hashTable.Search(patient.Cpf) != null)
                throw new Exception("Paciente já cadastrado");

            hashTable.Insert(patient);
            ServiceQueue.Enqueue(patient);
            Console.WriteLine("Por favor, aguarde a triagem.");
        }

        public Patient DoScreening()
        {
            var patient = ServiceQueue.Dequeue();
            hashTable.Remove(patient.Cpf);
            return patient;
        }

        public void ShowServiceQueue()
        {
            AnsiColors.WriteLine($"{string.Join(" -> ", ServiceQueue)}", AnsiColors.Green);
        }
    }
}
