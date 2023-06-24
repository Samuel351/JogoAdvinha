// See https://aka.ms/new-console-template for more information


using ConsoleApp1;

Console.WriteLine("Bem-vindo ao jogo da advinhação!");

Thread.Sleep(2000);

Console.WriteLine("Você terá que advinhar um número par ou impar no intervalo de 0 a 20 números");

Thread.Sleep(2000);

Console.WriteLine("Você tem 3 tentativas");

Thread.Sleep(2000);

Console.WriteLine("Pressione qualquer tecla para iniciar...");
Console.ReadLine();

Console.Clear();

var random = new Random();

while (true)
{
    var qualArvore = random.Next(0, 2);
    if (qualArvore == 1 || qualArvore == 2)
    {
        ArvorePar.ParArvore();
    }
    else if(qualArvore == 0) 
    {
        ArvoreImpar.ImparArvore();
    }

    Console.Clear();

    Console.WriteLine("Deseja jogar novamente? Pressione qualquer tecla se a for sim..");
    Console.ReadLine();

}



