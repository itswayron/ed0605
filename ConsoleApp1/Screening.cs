namespace aps01
{
    public class Screening
    {
        public PriorityQueue<Patient, int> patients;

        public Screening()
        {
            patients = new PriorityQueue<Patient, int>();
        }

        public void CallPatient(Patient patient)
        {
            patients.Enqueue(patient, patient.GetPriority());

            string priorityColor = patient.GetPriority() switch
            {
                0 => $"{AnsiColors.Red}Prioridade Máxima (vermelha){AnsiColors.Reset}",
                1 => $"{AnsiColors.Yellow}Prioridade Média (amarela){AnsiColors.Reset}",
                _ => $"{AnsiColors.Green}Prioridade Normal (verde){AnsiColors.Reset}",
            };

            Console.WriteLine(
                $"{AnsiColors.Green}Paciente {patient} adicionado à fila com {priorityColor}.{AnsiColors.Reset}");
        }


        public void ShowQueue()
        {
            var copy = new PriorityQueue<Patient, int>(patients.UnorderedItems);

            var output = new List<string>();

            while (copy.Count > 0)
            {
                var p = copy.Dequeue();

                string priorityColor = p.GetPriority() switch
                {
                    0 => AnsiColors.Red,
                    1 => AnsiColors.Yellow,
                    _ => AnsiColors.Green,
                };

                string formatted =
                    $"{AnsiColors.Green}{p}{AnsiColors.Reset}({priorityColor}{3 - p.GetPriority()}{AnsiColors.Reset})";
                output.Add(formatted);
            }

            Console.WriteLine($"{string.Join(" -> ", output)}\n");
        }
    }
}