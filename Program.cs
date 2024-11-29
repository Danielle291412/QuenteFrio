﻿using System.Security.Cryptography;

Console.Clear();
Console.WriteLine("Adivinhe o número amiguinho!\n");
Console.Write(" Eu estou imaginando um número que está entre 1 e 100.");
Console.WriteLine(" Dúvido você vencer esse desafio!");

int palpite = 0;
int numeroSecreto = RandomNumberGenerator.GetInt32(1, 101);
int tentativa = 1;
bool acertou = false;

do
{
    Console.Write($"\nEscreva o seu palpite amiguinho! #{tentativa}? ");

    if (!Int32.TryParse(Console.ReadLine(), out palpite) || palpite < 1 || palpite > 100)
        continue;

    int erro = palpite - numeroSecreto;
    int distanciaErro = Math.Abs(erro);

    acertou = (palpite == numeroSecreto);

    if (!acertou)
    {
        tentativa++;

        if (distanciaErro <= 3)
            ExibeColorido("Tá pelando amiguinho! Tente mais um pouco e você consegue.\n", ConsoleColor.Red);
        else if (distanciaErro <= 10)
            ExibeColorido("Eitaaa, tá quente amigão!\n", ConsoleColor.DarkRed);
        else
        {
            if (distanciaErro >= 30)
                ExibeColorido("Vixi amiguinho, tá congelando!", ConsoleColor.Blue);
            else
                ExibeColorido("Tá frio amiguinho, tente um pouco mais!", ConsoleColor.DarkBlue);

            bool tentarMaisAlto = Math.Sign(erro) == -1;

            Console.Write(" Tente com algum número mais ");
            ExibeColorido(tentarMaisAlto ? "alto" : "baixo", tentarMaisAlto ? ConsoleColor.Magenta : ConsoleColor.Green);
            Console.WriteLine(".");
        }
    }
}
while (tentativa <= 7 && !acertou);

Console.Write("\nO número que eu estava imaginando era: ");
ExibeColorido(numeroSecreto.ToString(), ConsoleColor.Yellow);
Console.WriteLine(".\n");

ExibeColorido(acertou ? "Uau, parabéns! Você é muito esperto amiguinho!" : "Não foi dessa vez amiguinho. Tente de novo.", acertou ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed);

void ExibeColorido(string texto, ConsoleColor cor)
{
    Console.ForegroundColor = cor;
    Console.Write(texto);
    Console.ResetColor();
}