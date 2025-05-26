using aps01;

Screening screening = new();
Doctor doctor = new();
MedicalCare medicalCare = new();

void menuInterface()
{
    AnsiColors.WriteLine("Bem vindo ao hospital Santa Cruz.\n", AnsiColors.Blue);

    AnsiColors.Write("Atendimento: ", AnsiColors.Cyan);
    medicalCare.ShowServiceQueue();
    AnsiColors.Write("Triagem: ", AnsiColors.Yellow);
    screening.ShowQueue();

    AnsiColors.PrintMenu([
        "Cadastrar paciente no atendimento.",
        "Chamar paciente para a triagem.",
        "Chamar o paciente para o atendimento.",
        "Mostrar histórico de atendimentos clínicos.",
        "Mostrar histórico de atendimentos com os dados de saúde.",
        "Cadastrar vários usuários na triagem."
    ]);
}

var menuActions = new List<Action>()
{
    () => { medicalCare.CallPatient(new Patient()); }, () =>
    {
        Patient patient = medicalCare.DoScreening();
        AnsiColors.WriteLine($"Cadastrando paciente na triagem: {patient}.", AnsiColors.Green);
        patient.BloodPressure = MenuCreator.ReadIntInput("Digite a pressão arterial do paciente: ");
        patient.Temperature = MenuCreator.ReadDoubleInput("Digite a temperatura do paciente: ");
        patient.Oxygenation = MenuCreator.ReadIntInput("Digite a oxigenação do paciente: ");
        screening.CallPatient(patient);
    },
    () => { doctor.MeetPatient(screening.patients); },
    () => { doctor.ShowHistory(); },
    () => { doctor.ShowDataHistory(); },
    () =>
    {
        int quantity = MenuCreator.ReadIntInput("Quantos pacientes deseja cadastrar automaticamente?: ");
        List<string> names =
        [
            "João", "Maria", "Ana", "Carlos", "Beatriz", "Pedro", "Juliana",
            "Lucas", "Fernanda", "Mateus", "Larissa", "Tiago", "Camila",
            "Gabriel", "Isabela", "Rafael", "Mariana", "André", "Letícia",
            "Henrique", "Patrícia", "Eduardo", "Roberta", "Felipe", "Bruna"
        ];

        Random rand = new Random();
        for (int i = 0; i < quantity; i++)
        {
            string name = names[rand.Next(names.Count)];
            int pressure = rand.Next(15, 25);
            double temperature = Math.Round(rand.NextDouble() * 5 + 36, 1);
            int oxygenation = rand.Next(85, 100);

            Patient p = new Patient(name, pressure, temperature, oxygenation);
            screening.CallPatient(p);
            AnsiColors.WriteLine(p.GetData(), AnsiColors.Green);
        }
    }
};

MenuCreator.ExecuteMenu(menuActions, menuInterface);