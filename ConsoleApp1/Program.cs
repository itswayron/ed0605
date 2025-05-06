using aps01;

Console.WriteLine("Bem vindo ao hospital chegou-morreu.");

int opcao;
Triagem Triagem = new();
ClinicoGeral Medico = new();
Atendimento Atendimento = new();
do
{
    // Definindo as cores
    string green = "\u001b[32m";   // Verde
    string red = "\u001b[31m";     // Vermelho
    string yellow = "\u001b[33m";  // Amarelo
    string reset = "\u001b[0m";    // Resetar para cor padrão

    Console.WriteLine();
    Console.WriteLine($"{green}Selecione as ações:{reset}");
    Console.WriteLine($"{yellow}[1]{reset} - Cadastrar paciente no atendimento.");
    Console.WriteLine($"{yellow}[2]{reset} - Chamar paciente para a triagem.");
    Console.WriteLine($"{yellow}[3]{reset} - Chamar o paciente para o atendimento.");
    Console.WriteLine($"{yellow}[4]{reset} - Mostrar fila da triagem.");
    Console.WriteLine($"{yellow}[5]{reset} - Mostrar fila de atendimento.");
    Console.WriteLine($"{yellow}[6]{reset} - Mostrar histórico de atendimentos clínicos.");
    Console.WriteLine($"{yellow}[7]{reset} - Mostrar histórico de atendimentos com os dados de saúde.");
    Console.WriteLine($"{yellow}[8]{reset} - Cadastrar vários usuários na triagem.");
    Console.WriteLine($"{yellow}[9]{reset} - Limpar console.");
    Console.WriteLine($"{red}[0]{reset} - Sair do sistema.");
    Console.WriteLine();
    Console.Write($"{green}Selecione: {reset}");
    opcao = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (opcao)
    {
        case 0:
            Console.Clear();
            Console.WriteLine($"{red}Saindo do sistema.{reset}");
            break;
        case 1:
            Console.Clear();
            Atendimento.FazerAtendimento(new Paciente());
            break;
        case 2:
            Console.Clear();
            Paciente paciente = Atendimento.ChamarParaTriagem();
            Console.WriteLine($"{green}Cadastrando paciente na triagem: {paciente}.{reset}\n");
            Console.Write("Digite a pressão arterial do paciente: ");
            paciente.PressaoArterial = int.Parse(Console.ReadLine());
            Console.Write("Digite a temperatura do paciente: ");
            paciente.Temperatura = double.Parse(Console.ReadLine());
            Console.Write("Digite a oxigenação do paciente: ");
            paciente.Oxigenação = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Triagem.ChamarPaciente(paciente);
            break;
        case 3:
            Console.Clear();
            Medico.AtenderPaciente(Triagem.pacientes);
            break;
        case 4:
            Console.Clear();
            Triagem.MostrarFila();
            break;
        case 5:
            Console.Clear();
            Atendimento.MostrarFilaAtendimento();
            break;
        case 6:
            Console.Clear();
            Medico.MostrarHistorico();
            break;
        case 7:
            Console.Clear();
            Medico.MostrarHistoricoDados();
            break;
        case 8:
            Console.Clear();
            Console.Write($"{green}Quantos pacientes deseja cadastrar automaticamente?: {reset}");
            int quantidade = int.Parse(Console.ReadLine());

            List<string> nomes = new List<string>
            {
                "João", "Maria", "Ana", "Carlos", "Beatriz", "Pedro", "Juliana",
                "Lucas", "Fernanda", "Mateus", "Larissa", "Tiago", "Camila",
                "Gabriel", "Isabela", "Rafael", "Mariana", "André", "Letícia",
                "Henrique", "Patrícia", "Eduardo", "Roberta", "Felipe", "Bruna"
            };

            Random rand = new Random();
            for (int i = 0; i < quantidade; i++)
            {
                string nome = nomes[rand.Next(nomes.Count)];
                int pressao = rand.Next(15, 25);
                double temperatura = Math.Round(rand.NextDouble() * 5 + 36, 1);
                int oxigenacao = rand.Next(85, 100);

                Paciente p = new Paciente(nome, pressao, temperatura, oxigenacao);
                Triagem.ChamarPaciente(p);

                // Mostrando dados do paciente com cores
                string pacienteColorido = $"{green}{p.GetDados()}{reset}";
                Console.WriteLine(pacienteColorido);
            }
            break;
        case 9:
            Console.Clear();
            break;
        default:
            Console.WriteLine($"{red}Opção inválida.{reset}");
            break;
    }

} while (opcao != 0);
