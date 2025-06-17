namespace aps01
{
    public class Patient
    {
        public String Cpf;
        public String Name;
        public int BloodPressure;
        public double Temperature;
        public int Oxygenation;

        public Patient()
        {
            Name = MenuCreator.ReadStringInput("Digite o nome do paciente: ");
            Cpf = FormatCPF(MenuCreator.ReadStringInput("Digite o CPF do paciente: "));
        }

        public static string FormatCPF(string cpf)
        {
            if (cpf == null || cpf.Length != 11)
                throw new ArgumentException("O CPF deve ter exatamente 11 caracteres.");

            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }


        public Patient(String name = "", int pressure = 0, double temperature = 0, int oxygenation = 0)
        {
            Name = name;
            BloodPressure = pressure;
            Oxygenation = oxygenation;
            Temperature = temperature;
        }

        public int GetPriority()
        {
            int points = 0;
            if (BloodPressure > 18) points++;
            if (Temperature > 39.0) points++;
            if (Oxygenation < 90) points++;

            return points switch
            {
                3 => 0,
                2 => 1,
                _ => 2,
            };
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetData()
        {
            string bloodPressureStr = BloodPressure <= 18
                ? $"{AnsiColors.Green}Pressão: {BloodPressure}{AnsiColors.Reset}"
                : $"{AnsiColors.Red}Pressão: {BloodPressure}{AnsiColors.Reset}";

            string temperatureStr = Temperature <= 39.0
                ? $"{AnsiColors.Green}Temperatura: {Temperature:F1}ºC{AnsiColors.Reset}"
                : $"{AnsiColors.Red}Temperatura: {Temperature:F1}ºC{AnsiColors.Reset}";

            string oxygenationStr = Oxygenation >= 90
                ? $"{AnsiColors.Green}Oxigenação: {Oxygenation}%{AnsiColors.Reset}"
                : $"{AnsiColors.Red}Oxigenação: {Oxygenation}%{AnsiColors.Reset}";

            string colorfulName = (BloodPressure <= 18 && Temperature <= 39.0 && Oxygenation >= 90)
                ? $"{AnsiColors.Green}{Name}{AnsiColors.Reset}"
                : $"{AnsiColors.Red}{Name}{AnsiColors.Reset}";

            return $"{colorfulName} ({bloodPressureStr}; {temperatureStr}; {oxygenationStr})";
        }
    }
}