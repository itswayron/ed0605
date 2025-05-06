using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aps01
{
    public class Paciente
    {
        public String Nome;
        public int PressaoArterial;
        public double Temperatura;
        public int Oxigenação;

        public Paciente()
        {
            Console.Write("Digite o nome do paciente: ");
            Nome = Console.ReadLine();
        }

        public Paciente(String nome = "", int pressao = 0, double temperatura = 0, int oxigenacao = 0)
        {
            this.Nome = nome;
            this.PressaoArterial = pressao;
            this.Oxigenação = oxigenacao;
            this.Temperatura = temperatura;
        }

        public int GetPrioridade()
        {
            int Pontuacao = 0;
            if (PressaoArterial > 18) Pontuacao++;
            if (Temperatura > 39.0) Pontuacao++;
            if (Oxigenação < 90) Pontuacao++;

            return Pontuacao switch
            {
                3 => 0,
                2 => 1,
                _ => 2,
            };
        }

        public override string ToString()
        {
            return Nome;
        }

        public string GetDados()
        {
            string green = "\u001b[32m";
            string red = "\u001b[31m";
            string reset = "\u001b[0m";

            string pressaoStr = PressaoArterial <= 18
                ? $"{green}Pressão: {PressaoArterial}{reset}"
                : $"{red}Pressão: {PressaoArterial}{reset}";

            string temperaturaStr = Temperatura <= 39.0
                ? $"{green}Temperatura: {Temperatura:F1}ºC{reset}"
                : $"{red}Temperatura: {Temperatura:F1}ºC{reset}";

            string oxigenacaoStr = Oxigenação >= 90
                ? $"{green}Oxigenação: {Oxigenação}%{reset}"
                : $"{red}Oxigenação: {Oxigenação}%{reset}";

            string nomeColorido = (PressaoArterial <= 18 && Temperatura <= 39.0 && Oxigenação >= 90)
                ? $"{green}{Nome}{reset}"
                : $"{red}{Nome}{reset}";

            return $"{nomeColorido} ({pressaoStr}; {temperaturaStr}; {oxigenacaoStr})";
        }


    }
}

