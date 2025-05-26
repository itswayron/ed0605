namespace aps01
{
    public class Doctor
    {
        Stack<Patient> history = new();

        public void MeetPatient(PriorityQueue<Patient, int> queue)
        {
            if (queue.Count <= 0)
            {
                throw new Exception("Nenhum paciente na fila para atendimento.");
            }

            Patient patient = queue.Dequeue();
            AnsiColors.WriteLine($"Atendendo paciente: {patient}", AnsiColors.Yellow);
            AnsiColors.WriteLine("Paciente atendido! Vá pra casa, meu fio.", AnsiColors.Green);
            history.Push(patient);
        }


        public void ShowHistory()
        {
            AnsiColors.WriteLine("Histórico de atendimentos:", AnsiColors.Blue);
            AnsiColors.WriteLine($"{string.Join(" -> ", history)}\n", AnsiColors.Green);
        }

        public void ShowDataHistory()
        {
            foreach (var patient in history)
            {
                Console.WriteLine(patient.GetData());
            }
        }
    }
}