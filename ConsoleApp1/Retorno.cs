namespace ConsoleApp1
{
    // Retorno da busca na árvore
    internal class Retorno
    {

        public int Contagem { get; set; } = default!;

        public int Numero { get; set; } = 0;

        public int Raiz { get; set; } = 0;

        public Retorno(int contagem, int numero, int raiz)
        {
            Contagem = contagem;
            Numero = numero;
            Raiz = raiz;
        }
    }
}
