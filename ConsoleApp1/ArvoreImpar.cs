namespace ConsoleApp1
{
    internal static class ArvoreImpar
    {
        public static void ImparArvore()
        {
            var arvore = CriarArvore();
            var tentativas = 3;
            var random = new Random();
            var numeroGerado = random.Next(0, 10);

            // Lista de números imapres
            List<int> numerosImpares = new() { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19};

            // Escolhendo número
            var numeroSorteado = numerosImpares[numeroGerado];

            while (true)
            {

                Console.WriteLine("Número de tentivas: " + tentativas);
                Console.WriteLine("\nInsira um número inteiro ímpar entre 1 e 20");
                var numeroInserido = int.Parse(Console.ReadLine());

                if (numeroInserido <= 20 && numeroInserido % 2 != 0)
                {
                    tentativas--;

                    var resultadoNumeroInserido = BuscaNaArvore(arvore, numeroInserido);

                    var resultadoNumeroSorteado = BuscaNaArvore(arvore, numeroSorteado);

                    if (resultadoNumeroInserido.Numero == resultadoNumeroSorteado.Numero)
                    {
                        Console.WriteLine("Acertou! o número é: " + numeroSorteado);
                        Console.ReadLine();
                        break;
                    }
                    else if (resultadoNumeroInserido.Numero != resultadoNumeroSorteado.Numero)
                    {
                        // Ambos os números (Sorteado e inserido) tem que ser maior ou menor que a raiz para garantir que estejam próximos
                        if (numeroSorteado > resultadoNumeroSorteado.Raiz && numeroInserido > resultadoNumeroSorteado.Raiz)
                        {
                            var retorno = VerificaoDistancia(resultadoNumeroInserido, resultadoNumeroSorteado);

                            Console.WriteLine(retorno);

                        }
                        else if (numeroSorteado < resultadoNumeroSorteado.Raiz && numeroInserido < resultadoNumeroSorteado.Raiz)
                        {
                            var retorno = VerificaoDistancia(resultadoNumeroInserido, resultadoNumeroSorteado);

                            Console.WriteLine(retorno);
                        }
                        else
                        {
                            Console.WriteLine("Está muito distante");
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
        }

        // Cria árvore com os números pares
        public static No CriarArvore()
        {
            return new No(9, new(5, new(3, new(1)), new(7)), new(15, new(13, new(11)), new(17, new(), new(19))));
        }

        // Busca valores na árvore e contagem quantos nós foram percorridos até encontrar o valor
        public static Retorno BuscaNaArvore(No arvore, int numero)
        {
            var raiz = arvore.Numero;
            var contagem = 0;
            while (true)
            {

                if (arvore.Numero == numero)
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

        // Compara distância do número sorteado
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
