using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aps01
{
    public class Triagem
    {
        public PriorityQueue<Paciente, int> pacientes;

        public Triagem() { pacientes = new PriorityQueue<Paciente, int>(); }

        public void ChamarPaciente(Paciente paciente)
        {
            pacientes.Enqueue(paciente, paciente.GetPrioridade());

            string green = "\u001b[32m";   // Cor verde
            string red = "\u001b[31m";     // Cor vermelha
            string yellow = "\u001b[33m";  // Cor amarela
            string reset = "\u001b[0m";    // Resetar para a cor padrão do terminal

            // Define a cor da prioridade (Vermelha, Amarela ou Verde)
            string prioridadeColorida = paciente.GetPrioridade() switch
            {
                0 => $"{red}Prioridade Máxima (vermelha){reset}", // Vermelho
                1 => $"{yellow}Prioridade Média (amarela){reset}", // Amarelo
                _ => $"{green}Prioridade Normal (verde){reset}", // Verde
            };

            // Exibe a mensagem, com o restante em verde e a prioridade colorida
            Console.WriteLine($"{green}Paciente {paciente} adicionado à fila com {prioridadeColorida}.{reset}");
        }

        public void MostrarFila()
        {
            var copia = new PriorityQueue<Paciente, int>(pacientes.UnorderedItems);

            // Definindo as cores
            string green = "\u001b[32m";   // Verde
            string red = "\u001b[31m";     // Vermelho
            string yellow = "\u001b[33m";  // Amarelo
            string reset = "\u001b[0m";    // Resetar para cor padrão

            while (copia.Count > 0)
            {
                var p = copia.Dequeue();
                // Definindo a cor da prioridade
                string prioridadeCor = p.GetPrioridade() switch
                {
                    0 => red,    // Prioridade máxima em vermelho
                    1 => yellow, // Prioridade média em amarelo
                    _ => green,  // Prioridade normal em verde
                };

                // Exibindo o nome do paciente em verde e a prioridade com a cor correspondente
                Console.Write($"{green}{p}{reset}({prioridadeCor}{3 - p.GetPrioridade()}{reset}) -> ");
            }
            Console.WriteLine(" Fim.");
        }


    }
}