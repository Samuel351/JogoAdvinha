using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class ArvorePar
    {
        public static void ParArvore()
        {
            var arvore = CriarArvore();
            var tentativas = 3;
            var random = new Random();
            var numeroGerado = random.Next(0, 11);

            // Lista números pares
            List<int> numerosPares = new() { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20};

            // Sorteando número par
            var numeroSorteado = numerosPares[numeroGerado];

            while (true)
            {

                Console.WriteLine("Número de tentivas: " + tentativas);
                Console.WriteLine("\nInsira um número inteiro par entre 0 e 20");
                var numeroInserido = int.Parse(Console.ReadLine());

                if(numeroInserido <= 20 && numeroInserido % 2 == 0)
                {
                    tentativas--;

                    var resultadoNumeroInserido = BuscaNaArvore(arvore, numeroInserido);

                    var resultadoNumeroSorteado = BuscaNaArvore(arvore, numeroSorteado);

                    if(resultadoNumeroInserido.Numero == resultadoNumeroSorteado.Numero || resultadoNumeroInserido.Contagem == 0 && resultadoNumeroSorteado.Contagem == 0)
                    {
                        Console.WriteLine("Acertou! o número é: " + numeroSorteado);
                        Console.ReadLine();
                        break;
                    }

                    // Ambos os números (Sorteado e inserido)  tem que ser maior ou menor que a raiz para garantir que estejam próximos
                    else if (resultadoNumeroInserido.Numero != resultadoNumeroSorteado.Numero)
                    {
                        if(numeroSorteado > resultadoNumeroSorteado.Raiz && numeroInserido > resultadoNumeroSorteado.Raiz)
                        {
                            var retorno = VerificaoDistancia(resultadoNumeroInserido, resultadoNumeroSorteado);

                            Console.WriteLine(retorno);

                        }
                        else if(numeroSorteado < resultadoNumeroSorteado.Raiz && numeroInserido < resultadoNumeroSorteado.Raiz)
                        {
                            var retorno = VerificaoDistancia(resultadoNumeroInserido, resultadoNumeroSorteado);

                            Console.WriteLine(retorno);
                        }
                        else
                        {
                            Console.WriteLine("Tá frio");
                        }
                    }
                        
                }
                else
                {
                    Console.WriteLine("Número invalido");
                    tentativas--;
                    Console.WriteLine("Número de tentivas: " + tentativas);
                }

                if (tentativas == 0)
                {
                    Console.WriteLine("Quantidade de tentativas atiginda, o número era: " + numeroSorteado);
                    Console.ReadLine();
                    break;
                }
                    
                            
            }

            Console.WriteLine("Fim do jogo");

        }

        // Cria árvore com os números pares
        public static No CriarArvore()
        {
            return new No(10, new(4, new(2, new(0)), new(6, new(), new(8))), new(16, new(14, new(12)), new(18, new(), new(20))));
        }

        // Busca valores na árvore e contagem quantos nós foram percorridos até encontrar o valor
        public static Retorno BuscaNaArvore(No arvore, int numero)
        {
            var raiz = arvore.Numero;
            var contagem = 0;
            while (true)
            {

                if(arvore.Numero == numero)
                {
                    return new Retorno(contagem, numero, raiz);
                }

                if (numero >= arvore.Numero)
                {
                    contagem++;
                    arvore = arvore.Direita;
                }
                else
                {
                    contagem++;
                    arvore = arvore.Esquerda;
                }
            }
        }

        public static string VerificaoDistancia(Retorno inserido, Retorno sorteado)
        {
            var result = inserido.Contagem - sorteado.Contagem;

            if (result == 1 || result == -1)
                return "Tá muito muito próximo";

            if (result == 2 || result == -2)
                return "Está próximo";

            if (result == 3 || result == -3)
                return "Um pouco próximo";
            

            return "Está longe";
        }
    }
}
