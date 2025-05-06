using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aps01
{
    public class Atendimento
    {
        Queue<Paciente> atendimento = new();
        
        public void FazerAtendimento(Paciente paciente)
        {
            atendimento.Enqueue(paciente);
            Console.WriteLine("Por favor, aguarde a triagem.");
        }

        public Paciente ChamarParaTriagem()
        {
            return atendimento.Dequeue();
        }

        public void MostrarFilaAtendimento()
        {
            foreach (var paciente in atendimento)
            {
                Console.Write(paciente + " -> ");
            }
            Console.WriteLine(" Fim.");
        }
    }
}
