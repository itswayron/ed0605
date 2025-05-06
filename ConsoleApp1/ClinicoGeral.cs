using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aps01
{
    public class ClinicoGeral
    {
        Stack<Paciente> historico = new();
        public void AtenderPaciente(PriorityQueue<Paciente, int> fila)
        {
            // Definindo cores
            string green = "\u001b[32m";   // Verde
            string reset = "\u001b[0m";    // Resetar para cor padrão

            if (fila.Count > 0)
            {
                Paciente paciente = fila.Dequeue();
                Console.WriteLine($"{green}Atendendo paciente: {paciente}{reset}");
                Console.WriteLine("Paciente atendido! Vá pra casa, meu fio.");
                historico.Push(paciente);
            }
            else
            {
                Console.WriteLine("Nenhum paciente na fila para atendimento.");
            }
        }

        public void MostrarHistorico()
        {
            // Definindo cores
            string green = "\u001b[32m";   // Verde
            string reset = "\u001b[0m";    // Resetar para cor padrão

            Console.WriteLine("Histórico de atendimentos:");

            foreach (var item in historico)
            {
                Console.Write($"{green}{item}{reset} => ");
            }
            Console.WriteLine(" Fim.");
        }


        public void MostrarHistoricoDados()
        {
            foreach (var item in historico)
            {
                Console.WriteLine(item.GetDados());
            }
        }

    }
}
