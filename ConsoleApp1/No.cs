using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Essa classe representa a árvore
    public class No
    {
        public int Numero { get; set; } = -1;

        public No? Esquerda { get; set; } = default!;

        public No? Direita { get; set; } = default!;

        public No(int numero = -1, No? esquerda = default!, No? direita = default!)
        {
            Numero = numero;
            Esquerda = esquerda;
            Direita = direita;
        }
    }
}
